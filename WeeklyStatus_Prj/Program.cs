using System;
using System.Linq;
using System.Text;
using Atlassian.Jira;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;

namespace WeeklyStatus_Prj
{

    class Program
    {
        public static string jiraUrl = ConfigurationManager.AppSettings.Get("JiraUrl");
        public static string FilterApi = ConfigurationManager.AppSettings.Get("FilterApi");
        public static string IssuesApi = ConfigurationManager.AppSettings.Get("IssuesApi");
        public static string JiraLogin = ConfigurationManager.AppSettings.Get("JiraLogin");
        public static string JiraPwd = ConfigurationManager.AppSettings.Get("JiraPwd");
        public static int DailyStatusFilterId = int.Parse(ConfigurationManager.AppSettings.Get("DailyStatusFilterId"));
        public static int WeeklyStatusFilterId = int.Parse(ConfigurationManager.AppSettings.Get("WeeklyStatusFilterId"));
        public static string emailFrom = ConfigurationManager.AppSettings.Get("EmailFrom");
        public static string emailFromPwd = ConfigurationManager.AppSettings.Get("EmailFromPwd");
        public static string emailTo = ConfigurationManager.AppSettings.Get("EmailTo");
        public static string emailCc = ConfigurationManager.AppSettings.Get("EmailCc");
        public static string SmtpHost = ConfigurationManager.AppSettings.Get("SmtpHost");
        public static int SmtpPort = int.Parse(ConfigurationManager.AppSettings.Get("SmtpPort"));


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
            else { queryResult = excuteQuery(FilterApi + WeeklyStatusFilterId); }

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
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Issue Type");
            dt.Columns.Add("Title");
            dt.Columns.Add("Assigned To");
            dt.Columns.Add("Spend hrs.");
            dt.Columns.Add("Status");
            dt.Columns.Add("Remark");
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
        private static string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", JiraLogin, JiraPwd);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
    }
}
