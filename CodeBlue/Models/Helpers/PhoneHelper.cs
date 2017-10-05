using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CodeBlue.Models.Helpers
{
    public class PhoneHelper
    {
        public static string DisplayNumber(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
        }
    }
}