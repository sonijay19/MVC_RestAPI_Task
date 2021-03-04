using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;

namespace UserManageMentSerivces.Exceptions
{
    public class UpdateUserDetailsExceptions : Exception
    {
        public readonly ErrorCodes _errorConstants;
        public UpdateUserDetailsExceptions(ErrorCodes errorCodes) :
            base(errorCodes.ToString())
        {
            this._errorConstants = errorCodes;
        }
    }
}
