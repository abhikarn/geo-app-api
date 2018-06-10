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
                DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return dt;
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