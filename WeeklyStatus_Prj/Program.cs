using System;
using System.Linq;
using System.Text;
using Atlassian.Jira;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using Google.GData.Client;
using Google.GData.Spreadsheets;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using JiraDailyStatus.Helper;

namespace WeeklyStatus_Prj
{


    class Program
    {
        public static string jiraUrl = AppSettings.Get<string>("jiraUrl");
        public static string FilterApi = AppSettings.Get<string>("FilterApi");
        public static string IssuesApi = AppSettings.Get<string>("IssuesApi");
        public static string JiraLogin = AppSettings.Get<string>("JiraLogin");
        public static string JiraPwd = AppSettings.Get<string>("JiraPwd");
        public static int DailyStatusFilterId = AppSettings.Get<int>("DailyStatusFilterId");
        public static int WeeklyStatusFilterId = AppSettings.Get<int>("WeeklyStatusFilterId");
        public static string emailFrom = AppSettings.Get<string>("emailFrom");
        public static string emailFromPwd = AppSettings.Get<string>("emailFromPwd");
        public static string emailTo = AppSettings.Get<string>("emailTo");
        public static string emailCc = AppSettings.Get<string>("emailCc");
        public static string SmtpHost = AppSettings.Get<string>("SmtpHost");
        public static int SmtpPort = AppSettings.Get<int>("SmtpPort");
        public static string GoogleClientId = AppSettings.Get<string>("GoogleClientId");
        public static string GoogleClientSecret = AppSettings.Get<string>("GoogleClientSecret");




        static void Main(string[] args)
        {
            string Daily_Weekly;
            if (args.Length == 0)
            {
                Console.WriteLine("Please Enter D or W for Daily or Weekly Report:");
                Daily_Weekly = Console.ReadLine();

                if (Daily_Weekly.Length == 0)
                    Daily_Weekly = "D";
            }
            else { Daily_Weekly = args.FirstOrDefault(); }
            string queryResult = "";
            var jira = Jira.CreateRestClient(jiraUrl, JiraLogin, JiraPwd);
            if (Daily_Weekly == "D")
            {
                queryResult = excuteQuery(FilterApi + DailyStatusFilterId);
            }
            else if (Daily_Weekly == "G")
            {
                googleConnect();
                return;
            }
            else

            { queryResult = excuteQuery(FilterApi + WeeklyStatusFilterId); }

            searchUrlprop searchUrlpropfe = JsonConvert.DeserializeObject<searchUrlprop>(queryResult);
            queryResult = excuteQuery(searchUrlpropfe.searchUrl + "&maxResults=1000");

            FilterKopf FilterKopf = JsonConvert.DeserializeObject<FilterKopf>(queryResult);
            if (FilterKopf.Issues.Count != 0)
            {
                if (Daily_Weekly == "D")
                {
                    var HtmlMsg = GetHtmlTable(FilterKopf);
                    SendMail(HtmlMsg);
                }
                else { generateCSV(FilterKopf); }
            }
        }

        private static void googleConnect()
        {
            var scopes = new[] { "https://spreadsheets.google.com/feeds https://docs.google.com/feeds" };
            SpreadsheetEntry mySpreadsheet = null;
            String CLIENT_ID = GoogleClientId; // found in Developer console
            String CLIENT_SECRET = GoogleClientSecret;// found in Developer console
            UserCredential credential =
                    GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                    {
                        ClientId = CLIENT_ID,
                        ClientSecret = CLIENT_SECRET
                    }
                    , scopes
                    , Environment.UserName
                    , CancellationToken.None
                    , new FileDataStore("GoogleSpreedSheets.Auth.Store")).Result;
            SpreadsheetsService spreadsheetsService = new SpreadsheetsService("Daily Status for May");
            var requestFactory = new GDataRequestFactory("Daily Status for May");
            requestFactory.CustomHeaders.Add(string.Format("Authorization: Bearer {0}", credential.Token.AccessToken));
            spreadsheetsService.RequestFactory = requestFactory;

            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = spreadsheetsService.Query(query);
            foreach (SpreadsheetEntry entry in feed.Entries)
            {
                if (entry.Title.Text == "Daily Status")
                {
                    mySpreadsheet = (SpreadsheetEntry)entry;
                };
            }
            AtomLink link = mySpreadsheet.Links.FindService(GDataSpreadsheetsNameTable.WorksheetRel, null);
            WorksheetQuery wQuery = new WorksheetQuery(link.HRef.ToString());
            WorksheetFeed wFeed = spreadsheetsService.Query(wQuery);

            //retrieve the cells in a worksheet
            WorksheetEntry worksheetEntry = (WorksheetEntry)wFeed.Entries[wFeed.Entries.Count - 1];//to Get the Sheet
            AtomLink cLink = worksheetEntry.Links.FindService(GDataSpreadsheetsNameTable.CellRel, null);

            CellQuery cQuery = new CellQuery(cLink.HRef.ToString());
            CellFeed cFeed = spreadsheetsService.Query(cQuery);
            int LastValueCell = 1;
            DataTable dt = GenerateStructure();
            DataRow dr = null;
            foreach (CellEntry cCell in cFeed.Entries)
            {
                if (cCell.Cell.Row != 1)
                {
                    if (LastValueCell != cCell.Cell.Row)
                    {
                        if (dr != null) { dt.Rows.Add(dr); }
                        dr = dt.NewRow();
                    }
                    if (cCell.Cell.Column == 2) { dr["Id"] = cCell.Cell.Value; }
                    else if (cCell.Cell.Column == 3) { dr["Issue Type"] = cCell.Cell.Value; }
                    else if (cCell.Cell.Column == 4) { dr["Title"] = cCell.Cell.Value; }
                    else if (cCell.Cell.Column == 5) { dr["Assigned To"] = cCell.Cell.Value; }
                    else if (cCell.Cell.Column == 6) { dr["Spend hrs."] = cCell.Cell.Value; }//
                    else if (cCell.Cell.Column == 7) { dr["Status"] = cCell.Cell.Value; }
                    else if (cCell.Cell.Column == 8)
                    {
                        dr["Remark"] = cCell.Cell.Value;
                    }
                    LastValueCell = (Int32)cCell.Cell.Row;
                }
            }
            if (dr != null) { dt.Rows.Add(dr); }
            dt.DefaultView.Sort = "Assigned To";
            dt = dt.DefaultView.ToTable();
            var HtmlMsg = ConvertToHtml(dt);
            SendMail(HtmlMsg);
        }

        private static void generateCSV(FilterKopf issues)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Issue Type");
            dt.Columns.Add("Key");
            dt.Columns.Add("Summary");
            dt.Columns.Add("Creator");
            dt.Columns.Add("Assignee");
            dt.Columns.Add("Reporter");
            dt.Columns.Add("Priority");
            dt.Columns.Add("Status");
            dt.Columns.Add("Resolution");
            dt.Columns.Add("Created");
            dt.Columns.Add("Updated");
            dt.Columns.Add("Due Date");
            dt.Columns.Add("Resolved");
            dt.Columns.Add("Time Spent");
            dt.Columns.Add("Story Points");
            for (var i = 0; i < issues.Issues.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Issue Type"] = issues.Issues[i].Fields.IssueType.name;
                dr["Key"] = issues.Issues[i].key;
                dr["Summary"] = issues.Issues[i].Fields.summary;
                dr["Creator"] = issues.Issues[i].Fields.creator.name;
                dr["Assignee"] = issues.Issues[i].Fields.Assignee.name;
                dr["Reporter"] = issues.Issues[i].Fields.reporter.name;
                dr["Priority"] = issues.Issues[i].Fields.priority.name;
                dr["Status"] = issues.Issues[i].Fields.Status.name;
                //dr["Resolution"] = issues.Issues[i].Fields.resolution;
                dr["Created"] = issues.Issues[i].Fields.created;
                dr["Updated"] = issues.Issues[i].Fields.updated;
                dr["Due Date"] = issues.Issues[i].Fields.duedate;
                dr["Resolved"] = "";
                dr["Time Spent"] = issues.Issues[i].Fields.timespent;
                dr["Story Points"] = "";
                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "Updated";
            dt = dt.DefaultView.ToTable();
            ExportToExcel(dt, null);

        }
        private static string GetHtmlTable(FilterKopf issues)
        {
            string workLogResult = "";
            DataTable dt = GenerateStructure();
            for (var i = 0; i < issues.Issues.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = issues.Issues[i].key;
                dr["Issue Type"] = issues.Issues[i].Fields.IssueType.name;
                dr["Title"] = issues.Issues[i].Fields.summary;
                dr["Assigned To"] = issues.Issues[i].Fields.Assignee.displayName;
                workLogResult = excuteQuery(IssuesApi + issues.Issues[i].key + "/worklog/");
                FilterKopf workLogs = JsonConvert.DeserializeObject<FilterKopf>(workLogResult);
                var LogTime = from str in workLogs.WorkLogs where str.started >= DateTime.Today select str;
                if (LogTime.FirstOrDefault() != null)
                {
                    dr["Spend hrs."] = LogTime.FirstOrDefault().timeSpent;
                    dr["Status"] = issues.Issues[i].Fields.Status.name;
                    dr["Remark"] = LogTime.FirstOrDefault().comment;
                }
                else
                {
                    dr["Spend hrs."] = "NA";
                    dr["Status"] = issues.Issues[i].Fields.Status.name;
                    dr["Remark"] = "Status Changed/Comments added for this ticket";
                }
                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "Assigned To";
            dt = dt.DefaultView.ToTable();
            return ConvertToHtml(dt);
        }

        private static string ConvertToHtml(DataTable dt)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table style='background-color:#ccc; width: 900px; font-size: 14px;' border ='0' cell-spacing='1' >");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("<th style='background-color:#eaeaea; font-size: 14px; padding: 5px; font-family: Arial; san-serif; color: #333;' align ='left'>{0}</th>", dc.ColumnName);
            }
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<td style='background-color:#fff; font-size: 14px; padding: 5px; font-family: Arial; san-serif; color: #666'>{0}</td>", cellValue);
                }
                sb.AppendLine("</ tr >");
            }
            sb.AppendLine("</table >");
            sb.AppendLine("</body >");
            sb.AppendLine("</html >");

            return sb.ToString();
        }
        private static void ExportToExcel(DataTable tbl, string excelFilePath = null)
        {
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                Excel._Worksheet workSheet = excelApp.ActiveSheet;
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else
                {
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        private static void SendMail(string msg)
        {
            string Regards = emailFrom.Substring(0, emailFrom.IndexOf('@'));
            string FirstName = Regards.Substring(0, Regards.IndexOf('.'));
            FirstName = FirstName.First().ToString().ToUpper() + FirstName.Substring(1);
            string LastName = Regards.Substring(Regards.IndexOf('.') + 1);
            LastName = LastName.First().ToString().ToUpper() + LastName.Substring(1);
            Regards = "</br></br>Thanks,</br>Regards </br>" + FirstName + " " + LastName;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.CC.Add(emailCc);
            string dt = DateTime.Today.ToString("dd/MMMM/yyyy");
            dt = dt.Replace('/', '-');
            mail.Subject = "Daily Status :" + ' ' + dt;
            mail.Body = "Hi All,</br> Please find the status for today. </br></br>" + msg + Regards;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = SmtpHost;
            smtp.Port = SmtpPort;
            smtp.Credentials = new NetworkCredential(
                emailFrom, emailFromPwd);
            smtp.EnableSsl = true;
            Console.WriteLine("Sending email...");
            smtp.Send(mail);
        }
        private static string excuteQuery(string url)
        {
            string data = null;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }
            string base64Credentials = GetEncodedCredentials();
            request.Headers.Add("Authorization", "Basic " + base64Credentials);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        private static string excuteQueryGoogleSheet(string url)
        {
            string data = null;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }
            string base64Credentials = GetEncodedCredentials();
            request.Headers.Add("Authorization", "Bearer ya29.GlsVBZhSrfWdI800bgqgmjmcs1L-wkgLeOr2Ww29u5xXPeIW5XpSAI09Eg24PkOibrt05WJHNAymNtWHViAfkJjApgNlkBzuMd5wS1Xpyky5PsiRMk2zOr107n02");
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string result = string.Empty;
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        private static string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", JiraLogin, JiraPwd);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
        private static DataTable GenerateStructure()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Issue Type");
            dt.Columns.Add("Title");
            dt.Columns.Add("Assigned To");
            dt.Columns.Add("Spend hrs.");
            dt.Columns.Add("Status");
            dt.Columns.Add("Remark");
            return dt;
        }
    }
}
