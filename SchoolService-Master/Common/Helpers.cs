using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SchoolService_Master.Common
{
    public class Helpers
    {
        public string GetToken(HttpRequestMessage Request)
        {
            string token = string.Empty;
            var headers = Request.Headers;
            if (headers.Contains("auth-token"))
            {
                headers.GetValues("auth-token").First();
            }
            return token;
        }

        public static string GenerateClientId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static DateTime StringToDate(string date)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return dt;
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }

    }
}