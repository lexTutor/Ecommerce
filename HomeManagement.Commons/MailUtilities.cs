using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HomeManagement.Commons
{
    public class MailUtilities
    {
        public static bool VerifyMails(string email, Dictionary<string, string> response)
        {
            string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            return false;
            
        }
    }
}
