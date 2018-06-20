using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using SchoolService_Master.Models;
using SchoolService_Master.ViewModels;

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
                if (!string.IsNullOrWhiteSpace(date))
                {
                    Char[] splitChars = new char[] { '/', '-' };
                    if (date.IndexOfAny(splitChars) > -1)
                    {
                        DateTime formatDate = DateTime.Parse(string.Concat(date.Split(splitChars)[2], "-", date.Split(splitChars)[0], "-", date.Split(splitChars)[1]));
                        return formatDate;
                    }
                }
                //DateTime dt = DateTime.ParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                return new DateTime();
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }



        //public static object MapModelViewModel<T>(T param) where T : class
        //{
        //}

    }
}