using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Numberverification
{
    public class SocialSecurityNumber
    {
        private readonly string _regexPattern = @"^(19|20)?\d{6}[-+]?\d{4}$";

        public string Numbers { get; set; }

        public bool ValidateSocialSecurityNumberFormat()
        {
            if (Regex.IsMatch(Numbers, _regexPattern))
            {
                return IsValidDate();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private bool IsValidDate()
        {
            var year = int.Parse(Numbers.Substring(0, 4));
            var month = int.Parse(Numbers.Substring(4, 2));
            var day = int.Parse(Numbers.Substring(6, 2));

            if (year < 1753 || year > 9999)
                throw new InvalidOperationException();

            if (month < 1 || month > 12)
                throw new InvalidOperationException();

            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                throw new InvalidOperationException();

            return true;
        }
    }
    }

