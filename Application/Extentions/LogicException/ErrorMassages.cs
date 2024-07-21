using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions.ServiceException
{
    public static class ErrorMassages
    {
        public const string BindDataError = "There was a problem loading the data";

        public const string InsertDataError = "There is a problem in registering information";

        public const string UpdateDatatError = "There is a problem editing information";

        public const string DataFormat = "The format of the information sent is incorrect";

        public const string IncompleteData = "The information sent is incomplete";
    }
}
