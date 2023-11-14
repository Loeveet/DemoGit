using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Numberverification
{
    public class ISBN
    {
        private readonly string _regexPattern = @"^(?:ISBN(?:-13)?:?\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)97[89][-\ ]?[0-9]{1,5}[-\ ]?[0-9]+[-\ ]?[0-9]+[-\ ]?[0-9]$";

        public string ISBNnumber { get; set; }

        public bool ValidateISBNformat() => Regex.IsMatch(ISBNnumber, _regexPattern);

    }
}
