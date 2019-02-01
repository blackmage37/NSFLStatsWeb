using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace NSFL.Helpers
{
    public class DateTimeHelper
    {
        
        public static string GetDateTimeFromFile(string file)
        {
            string[] sDateTime = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath(file));
            return sDateTime[0];
        }

    }
}