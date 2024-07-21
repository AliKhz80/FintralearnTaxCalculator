using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions.ValidationAttributes
{
    public static class ValidationAttributesErrorMassages
    {
        public const string ReqularExpression = "Special characters should not be used in the sent information";

        public const string StringLength = "The length of the string exceeds the allowed limit";

        public const string NegativeDigits = "Negative numbers are not acceptable";

        public const string DateTime = "The submitted date is invalid";

        public const string RequiredProperty = "This field is required";

        public const string licencePlateNumberFormat = "Licence Plate Number format is not valid!";

        public const string NameFormat = "Name format is not valid!";

        public const string ColorFormat = "Color is not valid!";

    }
}
