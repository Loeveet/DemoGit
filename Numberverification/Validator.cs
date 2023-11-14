using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Numberverification
{

    public class Validator
    {
        public bool IsValidIsbn10(string s)
        {
            s = s.Replace("-", "").Replace(" ", "");
            if (s.Length != 10 )
                return false;

            for (int i = 0; i < 10; i++)
                if (!char.IsDigit(s[i])) return false;

            int checksum = 0;

            for (int i = 0; i<10; i++)
            {
                int digit = int.Parse(s[i].ToString());

                checksum += digit * (10 - i);
            }

            return checksum % 11 == 0;
        }
        public bool IsValidIsbn13(string s)
        {
            s = s.Replace("-", "").Replace(" ", "");
            if (s.Length != 13)
                return false;


            int checksum = 0;

            for (int i = 0; i < 13; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    int digit = int.Parse(s[i].ToString());

                    int multiplier = (i % 2 == 0) ? 1 : 3;
                    checksum += digit * multiplier;
                }
                else if (i == 12 && (s[i] == 'X' || s[i] == 'x'))
                {
                    checksum += 10;
                }
                else
                {
                    return false; 
                }

            }

            return checksum % 10 == 0;
        }
        public bool IsValidSsn(string s)
        {
            // https://sv.wikipedia.org/wiki/Personnummer_i_Sverige  
            return false;
        }
        public bool IsValidPassword(string s)
        {
            // Hitta på dina egna valideringsregler (tester först!)
            return false;
        }
    }
}

