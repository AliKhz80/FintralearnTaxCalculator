using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Extentions.ValidationAttributes
{
    public static class StringValidation
    {
        public const string NamesExpression = "^[a-zA-Z0-9 ]*$";
        public const string AddressExpression = "^[a-zA-Z0-9 ,]*$";
        public const string phoneNumberExpression = "^[0-9+]*$";
        public const string NationalCodeExpression = "^[0-9]*$";
        public const string CommentExpression = "^[a-zA-Z0-9 ,-]*$";
        public const string CodeExpression = "^[0-9]*$";
        public const string SerialNumberExpression = "^[0-9-a-zA-Z]*$";
        public const string LicencePlateExpression = "^[0-9-a-zA-Z ]*$";
        public const string WordsExpression = "^[a-zA-Z]*$";

       
    }
}
