using MrDigitizerV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MrDigitizerV2.Helpers
{
    public static class ApplicationHelper
    {

        #region "Website Value Helper"
        public const string Cookie_Admin_Area_Authentication = "Cookie_Admin_Area_Authentication";
        public const string Cookie_Admin_Authentication = "Cookie_Admin_Authentication";
        public const string Cookie_Admin_Authentication_Scheme = "Cookie_Admin_Authentication_Scheme";
        public const string Cookie_Admin_Area_Authentication_Scheme = "Cookie_Admin_Area_Authentication_Scheme";
        public const string Cookie_Admin_Area_Email_Address = "Cookie_Admin_Area_Email_Address";
        public const string Cookie_Admin_Area_Password = "Cookie_Admin_Area_Password";
        public const string Session_Admin_Area_User_Login = "Session_Admin_Area_User_Login";
        public const string Cookie_Member_Login = "Cookie_Member_Login";
        public const string Session_Member_Login = "Session_Member_Login";
        public const string jQuery_Date_Format = "DD/MM/YYYY";
        public const string jQuery_Date_Time_Format = "DD/MM/YYYY HH:mm:ss";
        public const string Website_Date_Format = "dd/MM/yyyy";
        public const string Website_Date_Format_With_Month_Letter = "dd/MMM/yyyy";
        public const string Website_Date_Format_With_Month_Only_Letter = "MMMM, yyyy";
        public const string Website_Date_Time_Format = "dd/MM/yyyy HH:mm:ss";
        public const string EncryptKey = "Jobport1";
        public static string[] allowedImageExtensions = { ".jpg", ".png", ".gif", ".jpeg" };
        public static string[] allowedExcelExtensions = { ".xls", ".xlsx" };
        public static string[] allowedCVExtensions = { ".pdf", ".doc", ".docx" };
        public static string[] DayNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public static Dictionary<int, string> DayDictionary = new Dictionary<int, string>() { { 1, "Monday" }, { 2, "Tuesday" }, { 3, "Wednesday" }, { 4, "Thursday" }, { 5, "Friday" }, { 6, "Saturday" }, { 7, "Sunday" } };
        public static string[] JQueryDayNamesIndex = { "1", "2", "3", "4", "5", "6", "0" };
        public static string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        #endregion
        #region "Setting Keys"
        public const string Website_Name_Key = "Website Name";
        public const string Website_URL_Key = "Website URL";
        public const string Website_DateTime_Zone_key = "Website DateTime Zone";
        public const string Website_Email_Sender_Key = "Website Email Sender";
        public const string Website_Email_Server_Detail_Key = "Website Email Server Detail";
        public const string Website_Email_Encrypted_Password = "Website Email Encrypted Password";
        public static string WebsiteURL = "";

        public static string SMS_API_KEY = "SMS API KEY";
        public static string SMS_API_SECRET = "SMS API SECRET";
        public static string SMS_GET_RIDER_KEY = "Get Rider";


        #endregion
        #region "Redirect Page Helper"
        public static List<string> AllowedLink()
        {
            List<string> PageList = new List<string>();
            PageList.Add("dashboard");
            PageList.Add("dashboard/logout");
            PageList.Add("dashboard/profile");
            PageList.Add("dashboard/accessunauthorized");
            PageList.Add("dashboard/changepassword");
            return PageList;
        }
        #endregion
        #region "Enum Helper"

        public static class EnumRoleTypes
        {
            public const string Member = "member";
            public const string Designer = "designer";
            public const string Admin = "super administrator";
        }
     
        public static class EnumClaimTypes
        {
            public const string SubscriptionId = "SubscriptionId";
            public const string EmployerId = "EmployerId";
            public const string CandidateId = "CandidateId";
            public const string Token = "Token";
            public const string LoginType = "LoginType";
            public const string ProfileImage = "ProfileImage";
            public const string VerificationDateTime = "VerificationDateTime";
        }

        public static class EnumFileUploadFolder
        {
            public const string ProfileImage = "uploads\\ProfileImages";
            public const string Documents = "uploads\\Documents";
        }
        public static class EnumPlatform
        {
            public const string SMS = "SMS";
            public const string Email = "Email";
            public const string Push_Notification = "Notification";
        }
        public static class EnumMenuType
        {
            public const string Parent = "P";
            public const string Children = "C";
        }

        public static class EnumSMSStatusCode
        {
            public const string OK = "300";
        }
        public static class EnumEmployerType
        {
            public const string Get_Rider = "GetRider";
            public const string Access_E_Job = "Access E Job";
        }

        public static class EnumNotificationAction
        {
            public const string SHORTLISTED = "SHORTLISTED";
            public const string REVIEWED = "REVIEWED";
            public const string APPROVED = "APPROVED";
            public const string REJECTED = "REJECTED";
        }
        public static class EnumStaticId
        {
            public const string IndustryId = "ff8496e4-6877-4c1e-b402-ec6908a757e9";
            public const string FunctionalAreaId = "ba33631d-5b31-4980-a9ae-7b592f479ac3";
        }


        public static class EnumBackendMenuType
        {
            public const string Admin = "Admin";
            public const string Member = "Member";
            public const string Both = "Both";
        }

        public static class EnumHeaderType
        {
            public const string Candidate = "Candidate";
            public const string Employer = "Employer";
            public const string Public = "Public";
        }

        public static class EnumBackendMenuDetailType
        {
            public const string None = "none";
            public const string All = "all";
            public const string Add = "add";
            public const string Edit = "edit";
            public const string View = "view";
            public const string Delete = "delete";
        }
        public static class EnumYesNo
        {
            public const string No = "No";
            public const string Yes = "Yes";
        }

        public static class EnumRegistrationFrom
        {
            public const string Mobile = "Mobile";
            public const string Desktop = "Desktop";
        }

        public static class EnumAccountType
        {
            public const string SuperAdmin = "SuperAdmin";
            public const string Employer = "Employer";
            public const string Candidate = "Candidate";
        }

        public static class EnumAdResolution
        {
            public const string Banner = "Width: 1920px Height: 257px";
            public const string Footer = "Width: 430px Height: 257px";
            public const string Popup = "Width: 430px Height: 257px";
            public const string Sidebar = "Width: 210px Height: 540px";
        }
        public static class EnumStatus
        {
            public const string Enable = "Enable";
            public const string Disable = "Disable";
            public const string Unassigned = "Unassigned";
            public const string Assigned = "Assigned";
            public const string Completed = "Completed";
        }
        public static class EnumWebsiteStatus
        {
            public const string Online = "Online";
            public const string Offline = "Offline";
        }
        public static class EnumOrderType
        {
            public const string Digitizing = "Digitizing";
            public const string Vector = "Vector";
        }
        public static class EnumCalendarUnits
        {
            public const string Day = "Day";
            public const string Month = "Month";
            public const string Year = "Year";
        }
        public static class EnumJQueryResponseType
        {
            public const string DataOnly = "D";
            public const string MessageOnly = "M";
            public const string RedirectOnly = "T";
            public const string RefreshOnly = "R";
            public const string ReloadOnly = "RL";
            public const string MessageAndRedirect = "M-T";
            public const string MessageAndRedirectWithDelay = "M-TD";
            public const string MessageAndRefresh = "M-R";
            public const string MessageRefreshRedirect = "M-R-T";
            public const string MessageRefreshRedirectWithDelay = "M-R-TD";
            public const string RefreshAndRedirect = "R-T";
            public const string RefreshAndRedirectWithDelay = "R-TD";
            public const string RedirectWithDelay = "TD";
            public const string MessageAndReloadWithDelay = "M-RLD";
        }
        public static class EnumPageType
        {
            public const string Index = "Index";
            public const string Add = "Add";
            public const string Edit = "Edit";
            public const string View = "View";
            public const string Sorting = "Sorting";
        }
        public static class EnumRole
        {
            public static Guid SuperAdmin = Guid.Parse("72a5aa2d-62cc-4e40-bf7b-1af6d64c46d6");
            public static Guid Candidate = Guid.Parse("f817f318-95e4-47a7-8e5c-f5385c59a24e");
            public static Guid Employer = Guid.Parse("6a39121a-1c99-45e9-895d-eb86b706c3f5");
            public static Guid EmployerUser = Guid.Parse("0fd333ae-6516-4547-b830-9ae78981058a");
        }

        public static class EnumAppliedJobStatus
        {
            public const string Shortlisted = "Shortlisted";
            public const string Reviewed = "Reviewed";
            public const string Pending = "Pending";
            public const string Applied = "Applied";
            public const string Interviewed = "Interviewed";
            public const string NextInterview = "Another Interview";
            public const string Rescheduled = "Interview Reschedule";
            public const string Hired = "Hired";
            public const string Passed = "Passed";
        }

        public static class EnumLoginWith
        {
            public const string LinkedIn = "LinkedIn";
            public const string Web = "Web";
            public const string Facebook = "Facebook";
            public const string Google = "Google";
        }
        public static class EnumRegisterWith
        {
            public const string LinkedIn = "LinkedIn";
            public const string Web = "Web";
            public const string Rider = "Rider";
            public const string Facebook = "Facebook";
            public const string Google = "Google";
            public const string Employer = "Employer";
            public const string SuperAdmin = "Employer";
            public const string Fulcrum = "Fulcrum";
        }

        //public class IdentityUser
        //{
        //    public static Guid UserId = Guid.Parse("72a5aa2d-62cc-4e40-bf7b-1af6d64c46d6");
        //    public static string Username = "";
        //    public static string EmailAddress = "";
        //    public static string Designation = "";
        //    public static string Location = "";
        //    public static string ProfileImage = "";
        //}

        #endregion
        #region "Core Functions"

        public static List<string> AllowedUrlList()
        {
            List<string> PageList = new List<string>();
            PageList.Add("");
            PageList.Add("candidates");
            PageList.Add("employer-login");
            PageList.Add("candidate-login");
            PageList.Add("employer-login/logout");
            PageList.Add("employer/profile");
            PageList.Add("changepassword");
            PageList.Add("accountverifications/accountverification");
            PageList.Add("accountverifications/emailnotverified");
            PageList.Add("findjobs");
            PageList.Add("findjobs/jobdetail");
            PageList.Add("candidate-login/logout");
            PageList.Add("candidate/profile");
            PageList.Add("candidate/accountverification");
            PageList.Add("dashboard");
            PageList.Add("dashboard/profile");
            PageList.Add("dashboard/logout");
            PageList.Add("home/accessunauthorized");
            PageList.Add("resetpassword");
            return PageList;
        }

        public static Dictionary<string, string> GetExperiences()
        {
            Dictionary<string, string> experience = new Dictionary<string, string>();
            experience.Add("1 - 2", "1 - 2 Years");
            experience.Add("2 - 3", "2 - 3 Years");
            experience.Add("3 - 4", "3 - 4 Years");
            experience.Add("4 - 5", "4 - 5 Years");
            experience.Add("5 - 6", "5 - 6 Years");
            experience.Add("6 - 7", "6 - 7 Years");
            experience.Add("7 - 8", "7 - 8 Years");
            experience.Add("8 - 9", "8 - 9 Years");
            experience.Add("9 - 10", "9 - 10 Years");
            experience.Add("10 - 11", "10 - 11 Years");
            experience.Add("11 - 12", "11 - 12 Years");
            experience.Add("12 - 13", "12 - 13 Years");
            experience.Add("13 - 14", "13 - 14 Years");
            experience.Add("14 - 15", "14 - 15 Years");
            experience.Add("16 - 16", "More than 15 Years");
            return experience;
        }

        public static Dictionary<int, string> GetCandidateExperiences()
        {
            Dictionary<int, string> experience = new Dictionary<int, string>();
            experience.Add(0, "Fresh");
            experience.Add(1, "1 Years");
            experience.Add(2, "2 Years");
            experience.Add(3, "3 Years");
            experience.Add(4, "4 Years");
            experience.Add(5, "5 Years");
            experience.Add(6, "6 Years");
            experience.Add(7, "7 Years");
            experience.Add(8, "8 Years");
            experience.Add(9, "9 Years");
            experience.Add(10, "10 Years");
            experience.Add(11, "11 Years");
            experience.Add(12, "12 Years");
            experience.Add(13, "13 Years");
            experience.Add(14, "14 Years");
            experience.Add(15, "15 Years");
            experience.Add(16, "More than 15 Years");
            return experience;
        }
        public static int GetNumberFromString(string a)
        {
            string b = string.Empty;
            int val = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);
            return val;
        }
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }



        public static string GenerateRandomOTP(int iOTPLength)
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
        public static string GetTimeDuration(TimeSpan? Starttime, TimeSpan? Endtime)
        {
            string results = string.Empty;

            DateTime dt = new DateTime() + Starttime.Value;
            results = dt.ToString("h tt", DateTimeFormatInfo.InvariantInfo);

            dt = new DateTime() + Endtime.Value;
            results += " - " + dt.ToString("h tt", DateTimeFormatInfo.InvariantInfo);

            return results;
        }
        public static List<DateTime> GetMonthsBetween(DateTime from, DateTime to)
        {
            if (from > to) return GetMonthsBetween(to, from);

            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                monthDiff -= 1;
            }

            List<DateTime> results = new List<DateTime>();
            for (int i = monthDiff; i >= 1; i--)
            {
                results.Add(to.AddMonths(-i));
            }

            return results;
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public static IEnumerable<DateTime> DateRange(DateTime fromDate, DateTime toDate)
        {
            var dateRange = Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                             .Select(d => fromDate.AddDays(d));

            return dateRange;
        }
        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                   // Days: 1, 2 ... 31 etc.
                   .Select(day => new DateTime(year, month, day))
                    // Map each day to a date
                    .ToList(); // Load dates into a list
        }
        public static List<DateTime> GetWorkingDaysOfMonth(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                   .Select(day => new DateTime(year, month, day))
                    .ToList().Where(data => data.DayOfWeek.ToString() != "Sunday" && data.DayOfWeek.ToString() != "Saturday").ToList(); // Load dates into a list
        }
        public static List<DateTime> GetDateRangeBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d)).ToList();
        }

        public static int GetDatesOfYear(DateTime dateTime)
        {
            return dateTime.DayOfYear;
        }
        public class AjaxResponse
        {
            public bool Success { get; set; }
            public string Type { get; set; }
            public string FieldName { get; set; }
            public string Message { get; set; }
            public string TargetURL { get; set; }
            public object Data { get; set; }
        }

        public class APIResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
        }
        public static string GetViewName(string _viewName)
        {
            return "~/Views/" + _viewName + ".cshtml";
        }
        public static DateTime GetDateTime(MrdigitizerV2Context Database = null, string timeZoneId = "", bool isDefault = true)
        {
            if (isDefault)
            {
                timeZoneId = "Pakistan Standard Time";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(timeZoneId))
                {
                    timeZoneId = GetSettingContentByName(Database, Website_DateTime_Zone_key);
                }
            }

            TimeZoneInfo time_zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, time_zone);
        }
        public static DateTime GetUtcDateTime()
        {
            //TimeZoneInfo time_zone = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            //return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, time_zone);
            return DateTime.UtcNow;
        }
        public static string TextToSlug(string _value)
        {
            Regex rgx = new Regex(@"[^-a-zA-Z0-9\d\s]");
            // Replace Special Charater and space with emptystring 
            string finalOutput = rgx.Replace(_value, "");
            Regex rgx1 = new Regex("\\s+");
            // Replace space with underscore 
            finalOutput = rgx1.Replace(finalOutput, "-");
            if (finalOutput.StartsWith("-") || finalOutput.StartsWith(" "))
            {
                finalOutput = finalOutput.TrimStart(finalOutput[0]);
            }
            if (finalOutput.EndsWith("-") || finalOutput.EndsWith(" "))
            {
                finalOutput = finalOutput.TrimEnd(finalOutput[finalOutput.Length - 1]);
            }
            return finalOutput.ToLower();
        }
        public static string TrimCharacters(string _value, int _length = 1)
        {
            if (string.IsNullOrWhiteSpace(_value))
            {
                return _value;
            }
            else
            {
                return _value.TrimEnd(_value[_value.Length - _length]);
            }
        }
        public static string StripHtmlTags(string _value)
        {
            return Regex.Replace(_value, "<.*?>|&.*?;", string.Empty);
        }
        public static string CreateFileName(string fileName)
        {
            string[] strGUID = Guid.NewGuid().ToString().Split(new char[] { '-' });
            return fileName + "-" + strGUID[0];
        }
        public static string UpperCaseFirstLetter(string _value)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(_value))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(_value[0]) + _value.Substring(1);
        }
        public static string UpperCaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
        public static int CountStringOccurrences(string _value, string _pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = _value.IndexOf(_pattern, i)) != -1)
            {
                i += _pattern.Length;
                count++;
            }
            return count;
        }
        public static double Round(double d)
        {
            var absoluteValue = Math.Abs(d);
            var integralPart = (long)absoluteValue;
            var decimalPart = absoluteValue - integralPart;
            var sign = Math.Sign(d);

            double roundedNumber;

            if (decimalPart > 0.5)
            {
                roundedNumber = integralPart + 1;
            }
            else if (decimalPart == 0)
            {
                roundedNumber = absoluteValue;
            }
            else
            {
                roundedNumber = integralPart + 0.5;
            }

            return sign * roundedNumber;
        }
        public static List<string> GetTimeZoneList()
        {
            List<string> timeList = new List<string>();
            var tzone = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo tzi in tzone)
            {
                timeList.Add(tzi.Id);
            }
            return timeList;
        }



        #endregion
        #region "Mail Helper"
        public class MailObject
        {
            public MrdigitizerV2Context Database { get; set; }
            public string MailTo { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
        }

        public class EmailSettings
        {
            public const string Host = "smtp.gmail.com";
            public const string Port = "58";
            public const string Username = "sameerullah@meridiantdigitial.com";
            public const string Password = "M@r!d!@n12()";
            public const bool SSLSecurity = true;

        }
        public static void SendEmail(MailObject mailer)
        {
            string FromMail = mailer.Database.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Sender_Key)).Content;
            if (!string.IsNullOrWhiteSpace(FromMail) && !string.IsNullOrWhiteSpace(mailer.MailTo) && !string.IsNullOrWhiteSpace(mailer.Subject) && !string.IsNullOrWhiteSpace(mailer.Message))
            {
                if (IsEmailAddressValid(FromMail))
                {
                    mailer.Message = mailer.Message.Replace("{Current Year}", GetUtcDateTime().Year.ToString());
                    string[] mail_to_array = mailer.MailTo.Split(',');
                    //string[] emailServerDetail = GetSettingContentByName(mailer.Database, Website_Email_Server_Detail_Key).Split(new char[] { ',' });
                    foreach (string mail_to in mail_to_array)
                    {
                        var emailTo = mail_to.Trim();
                        if (!string.IsNullOrWhiteSpace(emailTo))
                        {
                            if (IsEmailAddressValid(emailTo))
                            {                               
                                string Server = mailer.Database.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Server_Detail_Key)).Content;
                                string Password = Decrypt(mailer.Database.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Encrypted_Password)).Content);
                                MailMessage mm = new MailMessage(FromMail, emailTo);
                                mm.Subject = mailer.Subject;
                                mm.Body = mailer.Message;
                                mm.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = Server;
                                smtp.EnableSsl = false;
                                NetworkCredential NetworkCred = new NetworkCredential(FromMail, Password);
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 8889;
                                smtp.Send(mm);                             
                            }
                        }
                    }
                }
            }
        }
        public static void SendEmail(MrdigitizerV2Context context, string subject, string body, string emailTo)
        {
            string FromMail = context.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Sender_Key)).Content;
            string Server = context.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Server_Detail_Key)).Content;
            string Password = Decrypt(context.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Encrypted_Password)).Content);
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(Server);
            SmtpServer.EnableSsl = false;
            SmtpServer.UseDefaultCredentials = false;
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(FromMail, Password);
            SmtpServer.Send(mail);
        }

        public static void SendEmail(MrdigitizerV2Context context, string subject, string body, string[] emails)
        {
            string FromMail = context.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Sender_Key)).Content;
            string Server = context.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Server_Detail_Key)).Content;
            string Password = Decrypt(context.Settings.FirstOrDefault(x => x.Title.Equals(Website_Email_Encrypted_Password)).Content);
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(Server);
            SmtpServer.EnableSsl = false;
            SmtpServer.UseDefaultCredentials = false;
            mail.From = new MailAddress(FromMail);
            foreach (var email in emails)
            {
                mail.To.Add(email);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            //LinkedResource facebook = new LinkedResource(_hosting.WebRootPath + "\\images\\icon-fb.png", MediaTypeNames.Image.Jpeg);
            //facebook.ContentId = "facebook";
            //AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            //altView.LinkedResources.Add(facebook);
            //mail.AlternateViews.Add(altView);
            //mail.BodyEncoding = Encoding.Default;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(FromMail, Password);
            SmtpServer.Send(mail);
        }
        #endregion
        #region "Setting Table Helper"
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
        public static string GetSettingContentByName(MrdigitizerV2Context dbContext, string _Title)
        {
            string ReturnContent = "#";
            var SettingRecord = dbContext.Settings.FirstOrDefault(o => o.Title.Equals(_Title));
            if (SettingRecord != null)
            {
                ReturnContent = SettingRecord.Content;
            }
            return ReturnContent;
        }


        public static string GetSettingContentByID(MrdigitizerV2Context dbContext, Guid _Key)
        {
            string ReturnContent = "#";
            var SettingRecord = dbContext.Settings.FirstOrDefault(o => o.Id == _Key);
            if (SettingRecord != null)
            {
                ReturnContent = SettingRecord.Content;
            }
            return ReturnContent;
        }
        #endregion
        #region "Limit Helper"
        public static string LimitLength(string paragraph, int maximumLenght)
        {
            //null check
            if (paragraph == null) return null;
            //less than maximum length, return as it is
            if (paragraph.Length <= maximumLenght) return paragraph;
            //split the paragraph into indvidual words 
            string[] words = paragraph.Split(' ');
            //initialize return variable 
            string paragraphToReturn = string.Empty;
            //construct the return word 
            foreach (string word in words)
            {
                //check if adding 3 to current length and next word is more than maximum length. 
                if ((paragraphToReturn.Length + word.Length + 3) > maximumLenght)
                {
                    //append "..."
                    paragraphToReturn = paragraphToReturn.Trim() + "...";
                    //exit foreach loop
                    break;
                }
                //add next word and continue
                paragraphToReturn += word + " ";
            }
            return paragraphToReturn;
        }
        public static string LimitCharacterLength(string paragraph, int maximumLenght)
        {
            //null check
            if (paragraph == null) return null;
            //less than maximum length, return as it is
            if (paragraph.Length <= maximumLenght) return paragraph;
            return paragraph.Substring(0, maximumLenght);
        }
        public static string LimitWordLength(string paragraph, int maximumLenght)
        {
            //null check
            if (paragraph == null) return null;
            //split the paragraph into indvidual words 
            string[] words = paragraph.Split(' ');
            //initialize return variable 
            string paragraphToReturn = string.Empty;
            if (words.Length <= maximumLenght)
            {
                return paragraph;
            }
            int w_counter = 1;
            //construct the return word 
            foreach (string word in words)
            {
                //check if adding 3 to current length and next word is more than maximum length. 
                if (w_counter == maximumLenght)
                {
                    //append "..."
                    paragraphToReturn = paragraphToReturn.Trim() + "...";
                    //exit foreach loop
                    break;
                }
                //add next word and continue
                paragraphToReturn += word + " ";
                w_counter += 1;
            }
            return paragraphToReturn;
        }
        #endregion    
        #region "Default Values Helper"
        public static int ParseInt(object value)
        {
            int parseVal;
            return ((value == null) || (value == DBNull.Value)) ? 0 : int.TryParse(value.ToString(), out parseVal) ? parseVal : 0;
        }
        public static decimal ParseDecimal(object value)
        {
            decimal parseVal;
            return ((value == null) || (value == DBNull.Value)) ? 0 : decimal.TryParse(value.ToString(), out parseVal) ? parseVal : 0;
        }
        public static double ParseDouble(object value)
        {
            double parseVal;
            return ((value == null) || (value == DBNull.Value)) ? 0 : double.TryParse(value.ToString(), out parseVal) ? parseVal : 0;
        }
        public static DateTime ParseDateTime(object value)
        {
            DateTime parseVal;
            return ((value == null) || (value == DBNull.Value)) ? new DateTime(1900, 1, 1) : DateTime.TryParse(value.ToString(), out parseVal) ? parseVal : new DateTime(1900, 1, 1);
        }
        public static DateTime ParseExactDateTime(object value)
        {
            DateTime parseVal;
            CultureInfo ci = CultureInfo.CreateSpecificCulture("ur-PK");
            return ((value == null) || (value == DBNull.Value)) ? new DateTime(1900, 1, 1) : DateTime.TryParseExact(value.ToString(), Website_Date_Format, ci, DateTimeStyles.None, out parseVal) ? parseVal : new DateTime(1900, 1, 1);
        }
        public static DateTime ParsePickerDateTime(object value)
        {
            DateTime parseVal;
            CultureInfo ci = CultureInfo.CreateSpecificCulture("ur-PK");
            return ((value == null) || (value == DBNull.Value)) ? new DateTime(1900, 1, 1) : DateTime.TryParse(value.ToString(), ci.DateTimeFormat, DateTimeStyles.None, out parseVal) ? parseVal : new DateTime(1900, 1, 1);
        }
        public static string ParseString(object value)
        {
            return ((value == null) || (value == DBNull.Value)) ? string.Empty : value.ToString();
        }
        public static bool ParseBoolean(object value)
        {
            bool parseVal;
            return ((value == null) || (value == DBNull.Value)) ? false : bool.TryParse(value.ToString(), out parseVal) ? parseVal : false;
        }
        public static bool IsEmailAddressValid(string EmailAddress)
        {
            string pattern = @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(EmailAddress);
        }
        #endregion
        #region "Encrypt Decrypt Helper"
        public static byte[] GetKey
        {
            get
            {
                return ASCIIEncoding.ASCII.GetBytes(EncryptKey);
            }
        }
        public static string Encrypt(string _value)
        {
            string ReturnValue = string.Empty;
            if (!string.IsNullOrWhiteSpace(_value))
            {
                ReturnValue = EncryptString(_value, GetKey);
            }
            return ReturnValue;
        }
        private static string EncryptString(string _value, byte[] _bytes)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(_bytes, _bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(_value);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        public static string Decrypt(string _value)
        {
            string ReturnValue = string.Empty;
            if (!string.IsNullOrWhiteSpace(_value))
            {
                ReturnValue = DecryptString(_value, GetKey);
            }
            return ReturnValue;
        }
        private static string DecryptString(string _value, byte[] _bytes)
        {
            _value = Regex.Replace(_value, "[ ]", "+");
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(_value));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(_bytes, _bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        public static string CreatePassword(int _length)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder ReturnValue = new StringBuilder();
            Random rnd = new Random();
            while (0 < _length--)
            {
                ReturnValue.Append(characters[rnd.Next(characters.Length)]);
            }
            return ReturnValue.ToString();
        }
        public static string CreateTokenURL()
        {
            Random rnd = new Random();
            string str = rnd.Next(0, 10000) + GetUtcDateTime().ToString();
            ASCIIEncoding AE = new ASCIIEncoding();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(AE.GetBytes(str));
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion
        #region "Session Helper"
        public static void AddSession(Controller _controller, string _key, string _value)
        {
            _controller.HttpContext.Session.SetString(_key, _value);
        }
        public static string GetSession(Controller _controller, string _key)
        {
            string ReturnObject = string.Empty;
            var SessionObject = _controller.HttpContext.Session.GetString(_key);
            if (SessionObject != null)
            {
                ReturnObject = SessionObject;
            }
            return ReturnObject;
        }
        public static void RemoveSession(Controller _controller, string _key)
        {
            var SessionObject = _controller.HttpContext.Session.GetString(_key);
            if (SessionObject != null)
            {
                _controller.HttpContext.Session.Remove(_key);
            }
        }

        public static void SetLoginSession(string response, Controller _controller)
        {
            AddSession(_controller, "context", response);
        }
        #endregion
        #region "Session Objects Helper"
        public static bool IsAdminLogin(Controller _controller)
        {
            return _controller.User.Identity.IsAuthenticated;
        }
        public static bool IsUserLogin(Controller _controller)
        {
            bool ReturnValue = false;
            if (!string.IsNullOrWhiteSpace(GetCookie(_controller, Cookie_Admin_Authentication)))
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

        public static Users GetUserData(Controller _controller)
        {
            Users UserRecord = null;
            if (IsAdminLogin(_controller))
            {
                UserRecord = JsonConvert.DeserializeObject<Users>(GetSession(_controller, Session_Admin_Area_User_Login).ToString());
            }
            return UserRecord;
        }
        public static bool IsMemberLogin(Controller _controller)
        {
            bool ReturnValue = false;
            if (!string.IsNullOrWhiteSpace(GetSession(_controller, Session_Member_Login)))
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }

        public static MemberModel GetMemberData(Controller _controller)
        {
            MemberModel MemberRecord = null;
            if (IsMemberLogin(_controller))
            {
                MemberRecord = JsonConvert.DeserializeObject<MemberModel>(GetSession(_controller, Session_Member_Login).ToString());
            }
            return MemberRecord;
        }
        #endregion
        #region ConvertListToDataTable
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static string ToStringAsXml(DataSet ds)
        {
            StringWriter sw = new StringWriter();
            ds.WriteXml(sw, XmlWriteMode.IgnoreSchema);
            string s = sw.ToString();
            return s;
        }
        #endregion
        #region "Extra Functions"
        public static string ToTimeSpanReadableString(this TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? string.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} hour{1}, ", span.Hours, span.Hours == 1 ? string.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1}, ", span.Minutes, span.Minutes == 1 ? string.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} second{1}", span.Seconds, span.Seconds == 1 ? string.Empty : "s") : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }
        public static bool CheckAnchorTag(string text)
        {
            var regex = new Regex(@"(?i)<a\b[^>]*?>(?<text>.*?)</a>", RegexOptions.Singleline);
            var e = regex.Match(text).Value;
            return e.Count() < 1 ? false : true;
        }


        public static string FileToBase64(IFormFile file)
        {
            string base64 = string.Empty;
            if (file != null)
            {
                if (file.Length > 0)
                {

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        base64 = Convert.ToBase64String(fileBytes);
                    }
                }
            }
            return base64;
        }

        public static string UploadFileToFolder(IFormFile file, string Folder)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(Folder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }


        public static Guid ToGuid(this Guid? source)
        {
            return source ?? Guid.Empty;
        }

        // more general implementation 
        public static T ValueOrDefault<T>(this Nullable<T> source) where T : struct
        {
            return source ?? default(T);
        }

        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

                if (viewResult.Success == false)
                {
                    return $"A view with the name {viewName} could not be found";
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }


        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
        #region DateTime Duration
        public struct DateTimeSpan
        {
            public int Years { get; }
            public int Months { get; }
            public int Days { get; }
            public int Hours { get; }
            public int Minutes { get; }
            public int Seconds { get; }
            public int Milliseconds { get; }

            public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
            {
                Years = years;
                Months = months;
                Days = days;
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
                Milliseconds = milliseconds;
            }

            enum Phase { Years, Months, Days, Done }

            public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
            {
                if (date2 < date1)
                {
                    var sub = date1;
                    date1 = date2;
                    date2 = sub;
                }

                DateTime current = date1;
                int years = 0;
                int months = 0;
                int days = 0;

                Phase phase = Phase.Years;
                DateTimeSpan span = new DateTimeSpan();
                int officialDay = current.Day;

                while (phase != Phase.Done)
                {
                    switch (phase)
                    {
                        case Phase.Years:
                            if (current.AddYears(years + 1) > date2)
                            {
                                phase = Phase.Months;
                                current = current.AddYears(years);
                            }
                            else
                            {
                                years++;
                            }
                            break;
                        case Phase.Months:
                            if (current.AddMonths(months + 1) > date2)
                            {
                                phase = Phase.Days;
                                current = current.AddMonths(months);
                                if (current.Day < officialDay && officialDay <= DateTime.DaysInMonth(current.Year, current.Month))
                                    current = current.AddDays(officialDay - current.Day);
                            }
                            else
                            {
                                months++;
                            }
                            break;
                        case Phase.Days:
                            if (current.AddDays(days + 1) > date2)
                            {
                                current = current.AddDays(days);
                                var timespan = date2 - current;
                                span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                                phase = Phase.Done;
                            }
                            else
                            {
                                days++;
                            }
                            break;
                    }
                }

                return span;
            }
        }
        public static string CountTotalDurationString(DateTime now, DateTime compareTo)
        {
            var dateSpan = DateTimeSpan.CompareDates(compareTo, now);
            string TotalExperience = "";
            if (dateSpan.Years != 0)
                TotalExperience = dateSpan.Years + " Year(s) ";
            if (dateSpan.Months != 0)
                TotalExperience += dateSpan.Months + " Month(s) ";
            if (dateSpan.Days != 0)
                TotalExperience += dateSpan.Days + " Day(s)";
            return TotalExperience;
        }

        public static int CountTotalYears(DateTime now, DateTime compareTo)
        {
            var dateSpan = DateTimeSpan.CompareDates(compareTo, now);
            int TotalExperience = 0;
            if (dateSpan.Years != 0)
                TotalExperience = dateSpan.Years;
            return TotalExperience;
        }



        public static double CountExperience(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).TotalDays;
        }
        public static int CalculateAge(DateTime? dateOfBirth)
        {
            int age = 0;
            if (dateOfBirth != null)
            {
                age = DateTime.Now.Year - Convert.ToDateTime(dateOfBirth).Year;
                if (DateTime.Now.DayOfYear < Convert.ToDateTime(dateOfBirth).DayOfYear)
                    age = age - 1;
            }

            return age;
        }
        #endregion
        #region "Cookie Helper"
        public static void SetCookie(Controller controller, string timeZoneId, string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = GetDateTime(null, timeZoneId).AddMinutes(expireTime.Value);
            else
                option.Expires = GetDateTime(null, timeZoneId).AddDays(-1);

            controller.Response.Cookies.Append(key, value, option);
        }
        public static void RemoveCookie(Controller controller, string key)
        {
            controller.Response.Cookies.Delete(key);
        }
        public static string GetCookie(Controller controller, string _key)
        {
            return ParseString(controller.HttpContext.Request.Cookies[_key]);
        }
        #endregion
        #region Custom functions




        public static string ConvertToWebURL(MrdigitizerV2Context context, string _value)
        {
            if (!string.IsNullOrWhiteSpace(_value) && !_value.Equals("#"))
            {
                if (_value.IndexOf("www.") == -1 && _value.IndexOf("http") == -1 && _value.IndexOf("https") == -1)
                {
                    if (_value.ToLower().Equals("home"))
                    {
                        _value = GetSettingContentByName(context, "Website URL");
                    }
                    else if (_value.Equals("/"))
                    {
                        _value = GetSettingContentByName(context, "Website URL");
                    }
                    else
                    {
                        _value = GetSettingContentByName(context, "Website URL") + _value;
                    }
                }
            }
            else
            {
                _value = "#";
            }
            return _value;
        }
        public static string GetProfileStatus(Controller controller)
        {
            return GetCookie(controller, "ProfileStatus");
        }

        public static string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException("extension");
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            string mime;
            return _mappings.TryGetValue(extension, out mime) ? "data:" + mime + ";base64, " : "application/octet-stream";
        }
        private static IDictionary<string, string> _mappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {

        #region list of mime types
        {".323", "text/h323"},
        {".3g2", "video/3gpp2"},
        {".3gp", "video/3gpp"},
        {".3gp2", "video/3gpp2"},
        {".3gpp", "video/3gpp"},
        {".7z", "application/x-7z-compressed"},
        {".aa", "audio/audible"},
        {".AAC", "audio/aac"},
        {".aaf", "application/octet-stream"},
        {".aax", "audio/vnd.audible.aax"},
        {".ac3", "audio/ac3"},
        {".aca", "application/octet-stream"},
        {".accda", "application/msaccess.addin"},
        {".accdb", "application/msaccess"},
        {".accdc", "application/msaccess.cab"},
        {".accde", "application/msaccess"},
        {".accdr", "application/msaccess.runtime"},
        {".accdt", "application/msaccess"},
        {".accdw", "application/msaccess.webapplication"},
        {".accft", "application/msaccess.ftemplate"},
        {".acx", "application/internet-property-stream"},
        {".AddIn", "text/xml"},
        {".ade", "application/msaccess"},
        {".adobebridge", "application/x-bridge-url"},
        {".adp", "application/msaccess"},
        {".ADT", "audio/vnd.dlna.adts"},
        {".ADTS", "audio/aac"},
        {".afm", "application/octet-stream"},
        {".ai", "application/postscript"},
        {".aif", "audio/x-aiff"},
        {".aifc", "audio/aiff"},
        {".aiff", "audio/aiff"},
        {".air", "application/vnd.adobe.air-application-installer-package+zip"},
        {".amc", "application/x-mpeg"},
        {".application", "application/x-ms-application"},
        {".art", "image/x-jg"},
        {".asa", "application/xml"},
        {".asax", "application/xml"},
        {".ascx", "application/xml"},
        {".asd", "application/octet-stream"},
        {".asf", "video/x-ms-asf"},
        {".ashx", "application/xml"},
        {".asi", "application/octet-stream"},
        {".asm", "text/plain"},
        {".asmx", "application/xml"},
        {".aspx", "application/xml"},
        {".asr", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".atom", "application/atom+xml"},
        {".au", "audio/basic"},
        {".avi", "video/x-msvideo"},
        {".axs", "application/olescript"},
        {".bas", "text/plain"},
        {".bcpio", "application/x-bcpio"},
        {".bin", "application/octet-stream"},
        {".bmp", "image/bmp"},
        {".c", "text/plain"},
        {".cab", "application/octet-stream"},
        {".caf", "audio/x-caf"},
        {".calx", "application/vnd.ms-office.calx"},
        {".cat", "application/vnd.ms-pki.seccat"},
        {".cc", "text/plain"},
        {".cd", "text/plain"},
        {".cdda", "audio/aiff"},
        {".cdf", "application/x-cdf"},
        {".cer", "application/x-x509-ca-cert"},
        {".chm", "application/octet-stream"},
        {".class", "application/x-java-applet"},
        {".clp", "application/x-msclip"},
        {".cmx", "image/x-cmx"},
        {".cnf", "text/plain"},
        {".cod", "image/cis-cod"},
        {".config", "application/xml"},
        {".contact", "text/x-ms-contact"},
        {".coverage", "application/xml"},
        {".cpio", "application/x-cpio"},
        {".cpp", "text/plain"},
        {".crd", "application/x-mscardfile"},
        {".crl", "application/pkix-crl"},
        {".crt", "application/x-x509-ca-cert"},
        {".cs", "text/plain"},
        {".csdproj", "text/plain"},
        {".csh", "application/x-csh"},
        {".csproj", "text/plain"},
        {".css", "text/css"},
        {".csv", "text/csv"},
        {".cur", "application/octet-stream"},
        {".cxx", "text/plain"},
        {".dat", "application/octet-stream"},
        {".datasource", "application/xml"},
        {".dbproj", "text/plain"},
        {".dcr", "application/x-director"},
        {".def", "text/plain"},
        {".deploy", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dgml", "application/xml"},
        {".dib", "image/bmp"},
        {".dif", "video/x-dv"},
        {".dir", "application/x-director"},
        {".disco", "text/xml"},
        {".dll", "application/x-msdownload"},
        {".dll.config", "text/xml"},
        {".dlm", "text/dlm"},
        {".doc", "application/msword"},
        {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
        {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
        {".dot", "application/msword"},
        {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
        {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
        {".dsp", "application/octet-stream"},
        {".dsw", "text/plain"},
        {".dtd", "text/xml"},
        {".dtsConfig", "text/xml"},
        {".dv", "video/x-dv"},
        {".dvi", "application/x-dvi"},
        {".dwf", "drawing/x-dwf"},
        {".dwp", "application/octet-stream"},
        {".dxr", "application/x-director"},
        {".eml", "message/rfc822"},
        {".emz", "application/octet-stream"},
        {".eot", "application/octet-stream"},
        {".eps", "application/postscript"},
        {".etl", "application/etl"},
        {".etx", "text/x-setext"},
        {".evy", "application/envoy"},
        {".exe", "application/octet-stream"},
        {".exe.config", "text/xml"},
        {".fdf", "application/vnd.fdf"},
        {".fif", "application/fractals"},
        {".filters", "Application/xml"},
        {".fla", "application/octet-stream"},
        {".flr", "x-world/x-vrml"},
        {".flv", "video/x-flv"},
        {".fsscript", "application/fsharp-script"},
        {".fsx", "application/fsharp-script"},
        {".generictest", "application/xml"},
        {".gif", "image/gif"},
        {".group", "text/x-ms-group"},
        {".gsm", "audio/x-gsm"},
        {".gtar", "application/x-gtar"},
        {".gz", "application/x-gzip"},
        {".h", "text/plain"},
        {".hdf", "application/x-hdf"},
        {".hdml", "text/x-hdml"},
        {".hhc", "application/x-oleobject"},
        {".hhk", "application/octet-stream"},
        {".hhp", "application/octet-stream"},
        {".hlp", "application/winhlp"},
        {".hpp", "text/plain"},
        {".hqx", "application/mac-binhex40"},
        {".hta", "application/hta"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".htt", "text/webviewhtml"},
        {".hxa", "application/xml"},
        {".hxc", "application/xml"},
        {".hxd", "application/octet-stream"},
        {".hxe", "application/xml"},
        {".hxf", "application/xml"},
        {".hxh", "application/octet-stream"},
        {".hxi", "application/octet-stream"},
        {".hxk", "application/xml"},
        {".hxq", "application/octet-stream"},
        {".hxr", "application/octet-stream"},
        {".hxs", "application/octet-stream"},
        {".hxt", "text/html"},
        {".hxv", "application/xml"},
        {".hxw", "application/octet-stream"},
        {".hxx", "text/plain"},
        {".i", "text/plain"},
        {".ico", "image/x-icon"},
        {".ics", "application/octet-stream"},
        {".idl", "text/plain"},
        {".ief", "image/ief"},
        {".iii", "application/x-iphone"},
        {".inc", "text/plain"},
        {".inf", "application/octet-stream"},
        {".inl", "text/plain"},
        {".ins", "application/x-internet-signup"},
        {".ipa", "application/x-itunes-ipa"},
        {".ipg", "application/x-itunes-ipg"},
        {".ipproj", "text/plain"},
        {".ipsw", "application/x-itunes-ipsw"},
        {".iqy", "text/x-ms-iqy"},
        {".isp", "application/x-internet-signup"},
        {".ite", "application/x-itunes-ite"},
        {".itlp", "application/x-itunes-itlp"},
        {".itms", "application/x-itunes-itms"},
        {".itpc", "application/x-itunes-itpc"},
        {".IVF", "video/x-ivf"},
        {".jar", "application/java-archive"},
        {".java", "application/octet-stream"},
        {".jck", "application/liquidmotion"},
        {".jcz", "application/liquidmotion"},
        {".jfif", "image/pjpeg"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpb", "application/octet-stream"},
        {".jpe", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".json", "application/json"},
        {".jsx", "text/jscript"},
        {".jsxbin", "text/plain"},
        {".latex", "application/x-latex"},
        {".library-ms", "application/windows-library+xml"},
        {".lit", "application/x-ms-reader"},
        {".loadtest", "application/xml"},
        {".lpk", "application/octet-stream"},
        {".lsf", "video/x-la-asf"},
        {".lst", "text/plain"},
        {".lsx", "video/x-la-asf"},
        {".lzh", "application/octet-stream"},
        {".m13", "application/x-msmediaview"},
        {".m14", "application/x-msmediaview"},
        {".m1v", "video/mpeg"},
        {".m2t", "video/vnd.dlna.mpeg-tts"},
        {".m2ts", "video/vnd.dlna.mpeg-tts"},
        {".m2v", "video/mpeg"},
        {".m3u", "audio/x-mpegurl"},
        {".m3u8", "audio/x-mpegurl"},
        {".m4a", "audio/m4a"},
        {".m4b", "audio/m4b"},
        {".m4p", "audio/m4p"},
        {".m4r", "audio/x-m4r"},
        {".m4v", "video/x-m4v"},
        {".mac", "image/x-macpaint"},
        {".mak", "text/plain"},
        {".man", "application/x-troff-man"},
        {".manifest", "application/x-ms-manifest"},
        {".map", "text/plain"},
        {".master", "application/xml"},
        {".mda", "application/msaccess"},
        {".mdb", "application/x-msaccess"},
        {".mde", "application/msaccess"},
        {".mdp", "application/octet-stream"},
        {".me", "application/x-troff-me"},
        {".mfp", "application/x-shockwave-flash"},
        {".mht", "message/rfc822"},
        {".mhtml", "message/rfc822"},
        {".mid", "audio/mid"},
        {".midi", "audio/mid"},
        {".mix", "application/octet-stream"},
        {".mk", "text/plain"},
        {".mmf", "application/x-smaf"},
        {".mno", "text/xml"},
        {".mny", "application/x-msmoney"},
        {".mod", "video/mpeg"},
        {".mov", "video/quicktime"},
        {".movie", "video/x-sgi-movie"},
        {".mp2", "video/mpeg"},
        {".mp2v", "video/mpeg"},
        {".mp3", "audio/mpeg"},
        {".mp4", "video/mp4"},
        {".mp4v", "video/mp4"},
        {".mpa", "video/mpeg"},
        {".mpe", "video/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpf", "application/vnd.ms-mediapackage"},
        {".mpg", "video/mpeg"},
        {".mpp", "application/vnd.ms-project"},
        {".mpv2", "video/mpeg"},
        {".mqv", "video/quicktime"},
        {".ms", "application/x-troff-ms"},
        {".msi", "application/octet-stream"},
        {".mso", "application/octet-stream"},
        {".mts", "video/vnd.dlna.mpeg-tts"},
        {".mtx", "application/xml"},
        {".mvb", "application/x-msmediaview"},
        {".mvc", "application/x-miva-compiled"},
        {".mxp", "application/x-mmxp"},
        {".nc", "application/x-netcdf"},
        {".nsc", "video/x-ms-asf"},
        {".nws", "message/rfc822"},
        {".ocx", "application/octet-stream"},
        {".oda", "application/oda"},
        {".odc", "text/x-ms-odc"},
        {".odh", "text/plain"},
        {".odl", "text/plain"},
        {".odp", "application/vnd.oasis.opendocument.presentation"},
        {".ods", "application/oleobject"},
        {".odt", "application/vnd.oasis.opendocument.text"},
        {".one", "application/onenote"},
        {".onea", "application/onenote"},
        {".onepkg", "application/onenote"},
        {".onetmp", "application/onenote"},
        {".onetoc", "application/onenote"},
        {".onetoc2", "application/onenote"},
        {".orderedtest", "application/xml"},
        {".osdx", "application/opensearchdescription+xml"},
        {".p10", "application/pkcs10"},
        {".p12", "application/x-pkcs12"},
        {".p7b", "application/x-pkcs7-certificates"},
        {".p7c", "application/pkcs7-mime"},
        {".p7m", "application/pkcs7-mime"},
        {".p7r", "application/x-pkcs7-certreqresp"},
        {".p7s", "application/pkcs7-signature"},
        {".pbm", "image/x-portable-bitmap"},
        {".pcast", "application/x-podcast"},
        {".pct", "image/pict"},
        {".pcx", "application/octet-stream"},
        {".pcz", "application/octet-stream"},
        {".pdf", "application/pdf"},
        {".pfb", "application/octet-stream"},
        {".pfm", "application/octet-stream"},
        {".pfx", "application/x-pkcs12"},
        {".pgm", "image/x-portable-graymap"},
        {".pic", "image/pict"},
        {".pict", "image/pict"},
        {".pkgdef", "text/plain"},
        {".pkgundef", "text/plain"},
        {".pko", "application/vnd.ms-pki.pko"},
        {".pls", "audio/scpls"},
        {".pma", "application/x-perfmon"},
        {".pmc", "application/x-perfmon"},
        {".pml", "application/x-perfmon"},
        {".pmr", "application/x-perfmon"},
        {".pmw", "application/x-perfmon"},
        {".png", "image/png"},
        {".pnm", "image/x-portable-anymap"},
        {".pnt", "image/x-macpaint"},
        {".pntg", "image/x-macpaint"},
        {".pnz", "image/png"},
        {".pot", "application/vnd.ms-powerpoint"},
        {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
        {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
        {".ppa", "application/vnd.ms-powerpoint"},
        {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
        {".ppm", "image/x-portable-pixmap"},
        {".pps", "application/vnd.ms-powerpoint"},
        {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
        {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
        {".ppt", "application/vnd.ms-powerpoint"},
        {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
        {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
        {".prf", "application/pics-rules"},
        {".prm", "application/octet-stream"},
        {".prx", "application/octet-stream"},
        {".ps", "application/postscript"},
        {".psc1", "application/PowerShell"},
        {".psd", "application/octet-stream"},
        {".psess", "application/xml"},
        {".psm", "application/octet-stream"},
        {".psp", "application/octet-stream"},
        {".pub", "application/x-mspublisher"},
        {".pwz", "application/vnd.ms-powerpoint"},
        {".qht", "text/x-html-insertion"},
        {".qhtm", "text/x-html-insertion"},
        {".qt", "video/quicktime"},
        {".qti", "image/x-quicktime"},
        {".qtif", "image/x-quicktime"},
        {".qtl", "application/x-quicktimeplayer"},
        {".qxd", "application/octet-stream"},
        {".ra", "audio/x-pn-realaudio"},
        {".ram", "audio/x-pn-realaudio"},
        {".rar", "application/octet-stream"},
        {".ras", "image/x-cmu-raster"},
        {".rat", "application/rat-file"},
        {".rc", "text/plain"},
        {".rc2", "text/plain"},
        {".rct", "text/plain"},
        {".rdlc", "application/xml"},
        {".resx", "application/xml"},
        {".rf", "image/vnd.rn-realflash"},
        {".rgb", "image/x-rgb"},
        {".rgs", "text/plain"},
        {".rm", "application/vnd.rn-realmedia"},
        {".rmi", "audio/mid"},
        {".rmp", "application/vnd.rn-rn_music_package"},
        {".roff", "application/x-troff"},
        {".rpm", "audio/x-pn-realaudio-plugin"},
        {".rqy", "text/x-ms-rqy"},
        {".rtf", "application/rtf"},
        {".rtx", "text/richtext"},
        {".ruleset", "application/xml"},
        {".s", "text/plain"},
        {".safariextz", "application/x-safari-safariextz"},
        {".scd", "application/x-msschedule"},
        {".sct", "text/scriptlet"},
        {".sd2", "audio/x-sd2"},
        {".sdp", "application/sdp"},
        {".sea", "application/octet-stream"},
        {".searchConnector-ms", "application/windows-search-connector+xml"},
        {".setpay", "application/set-payment-initiation"},
        {".setreg", "application/set-registration-initiation"},
        {".settings", "application/xml"},
        {".sgimb", "application/x-sgimb"},
        {".sgml", "text/sgml"},
        {".sh", "application/x-sh"},
        {".shar", "application/x-shar"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".sitemap", "application/xml"},
        {".skin", "application/xml"},
        {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
        {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
        {".slk", "application/vnd.ms-excel"},
        {".sln", "text/plain"},
        {".slupkg-ms", "application/x-ms-license"},
        {".smd", "audio/x-smd"},
        {".smi", "application/octet-stream"},
        {".smx", "audio/x-smd"},
        {".smz", "audio/x-smd"},
        {".snd", "audio/basic"},
        {".snippet", "application/xml"},
        {".snp", "application/octet-stream"},
        {".sol", "text/plain"},
        {".sor", "text/plain"},
        {".spc", "application/x-pkcs7-certificates"},
        {".spl", "application/futuresplash"},
        {".src", "application/x-wais-source"},
        {".srf", "text/plain"},
        {".SSISDeploymentManifest", "text/xml"},
        {".ssm", "application/streamingmedia"},
        {".sst", "application/vnd.ms-pki.certstore"},
        {".stl", "application/vnd.ms-pki.stl"},
        {".sv4cpio", "application/x-sv4cpio"},
        {".sv4crc", "application/x-sv4crc"},
        {".svc", "application/xml"},
        {".swf", "application/x-shockwave-flash"},
        {".t", "application/x-troff"},
        {".tar", "application/x-tar"},
        {".tcl", "application/x-tcl"},
        {".testrunconfig", "application/xml"},
        {".testsettings", "application/xml"},
        {".tex", "application/x-tex"},
        {".texi", "application/x-texinfo"},
        {".texinfo", "application/x-texinfo"},
        {".tgz", "application/x-compressed"},
        {".thmx", "application/vnd.ms-officetheme"},
        {".thn", "application/octet-stream"},
        {".tif", "image/tiff"},
        {".tiff", "image/tiff"},
        {".tlh", "text/plain"},
        {".tli", "text/plain"},
        {".toc", "application/octet-stream"},
        {".tr", "application/x-troff"},
        {".trm", "application/x-msterminal"},
        {".trx", "application/xml"},
        {".ts", "video/vnd.dlna.mpeg-tts"},
        {".tsv", "text/tab-separated-values"},
        {".ttf", "application/octet-stream"},
        {".tts", "video/vnd.dlna.mpeg-tts"},
        {".txt", "text/plain"},
        {".u32", "application/octet-stream"},
        {".uls", "text/iuls"},
        {".user", "text/plain"},
        {".ustar", "application/x-ustar"},
        {".vb", "text/plain"},
        {".vbdproj", "text/plain"},
        {".vbk", "video/mpeg"},
        {".vbproj", "text/plain"},
        {".vbs", "text/vbscript"},
        {".vcf", "text/x-vcard"},
        {".vcproj", "Application/xml"},
        {".vcs", "text/plain"},
        {".vcxproj", "Application/xml"},
        {".vddproj", "text/plain"},
        {".vdp", "text/plain"},
        {".vdproj", "text/plain"},
        {".vdx", "application/vnd.ms-visio.viewer"},
        {".vml", "text/xml"},
        {".vscontent", "application/xml"},
        {".vsct", "text/xml"},
        {".vsd", "application/vnd.visio"},
        {".vsi", "application/ms-vsi"},
        {".vsix", "application/vsix"},
        {".vsixlangpack", "text/xml"},
        {".vsixmanifest", "text/xml"},
        {".vsmdi", "application/xml"},
        {".vspscc", "text/plain"},
        {".vss", "application/vnd.visio"},
        {".vsscc", "text/plain"},
        {".vssettings", "text/xml"},
        {".vssscc", "text/plain"},
        {".vst", "application/vnd.visio"},
        {".vstemplate", "text/xml"},
        {".vsto", "application/x-ms-vsto"},
        {".vsw", "application/vnd.visio"},
        {".vsx", "application/vnd.visio"},
        {".vtx", "application/vnd.visio"},
        {".wav", "audio/wav"},
        {".wave", "audio/wav"},
        {".wax", "audio/x-ms-wax"},
        {".wbk", "application/msword"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wcm", "application/vnd.ms-works"},
        {".wdb", "application/vnd.ms-works"},
        {".wdp", "image/vnd.ms-photo"},
        {".webarchive", "application/x-safari-webarchive"},
        {".webtest", "application/xml"},
        {".wiq", "application/xml"},
        {".wiz", "application/msword"},
        {".wks", "application/vnd.ms-works"},
        {".WLMP", "application/wlmoviemaker"},
        {".wlpginstall", "application/x-wlpg-detect"},
        {".wlpginstall3", "application/x-wlpg3-detect"},
        {".wm", "video/x-ms-wm"},
        {".wma", "audio/x-ms-wma"},
        {".wmd", "application/x-ms-wmd"},
        {".wmf", "application/x-msmetafile"},
        {".wml", "text/vnd.wap.wml"},
        {".wmlc", "application/vnd.wap.wmlc"},
        {".wmls", "text/vnd.wap.wmlscript"},
        {".wmlsc", "application/vnd.wap.wmlscriptc"},
        {".wmp", "video/x-ms-wmp"},
        {".wmv", "video/x-ms-wmv"},
        {".wmx", "video/x-ms-wmx"},
        {".wmz", "application/x-ms-wmz"},
        {".wpl", "application/vnd.ms-wpl"},
        {".wps", "application/vnd.ms-works"},
        {".wri", "application/x-mswrite"},
        {".wrl", "x-world/x-vrml"},
        {".wrz", "x-world/x-vrml"},
        {".wsc", "text/scriptlet"},
        {".wsdl", "text/xml"},
        {".wvx", "video/x-ms-wvx"},
        {".x", "application/directx"},
        {".xaf", "x-world/x-vrml"},
        {".xaml", "application/xaml+xml"},
        {".xap", "application/x-silverlight-app"},
        {".xbap", "application/x-ms-xbap"},
        {".xbm", "image/x-xbitmap"},
        {".xdr", "text/plain"},
        {".xht", "application/xhtml+xml"},
        {".xhtml", "application/xhtml+xml"},
        {".xla", "application/vnd.ms-excel"},
        {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
        {".xlc", "application/vnd.ms-excel"},
        {".xld", "application/vnd.ms-excel"},
        {".xlk", "application/vnd.ms-excel"},
        {".xll", "application/vnd.ms-excel"},
        {".xlm", "application/vnd.ms-excel"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
        {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".xlt", "application/vnd.ms-excel"},
        {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
        {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
        {".xlw", "application/vnd.ms-excel"},
        {".xml", "text/xml"},
        {".xmta", "application/xml"},
        {".xof", "x-world/x-vrml"},
        {".XOML", "text/plain"},
        {".xpm", "image/x-xpixmap"},
        {".xps", "application/vnd.ms-xpsdocument"},
        {".xrm-ms", "text/xml"},
        {".xsc", "application/xml"},
        {".xsd", "text/xml"},
        {".xsf", "text/xml"},
        {".xsl", "text/xml"},
        {".xslt", "text/xml"},
        {".xsn", "application/octet-stream"},
        {".xss", "application/xml"},
        {".xtp", "application/octet-stream"},
        {".xwd", "image/x-xwindowdump"},
        {".z", "application/x-compress"},
        {".zip", "application/x-zip-compressed"},
        #endregion
        
        };
        #endregion
    }
}
