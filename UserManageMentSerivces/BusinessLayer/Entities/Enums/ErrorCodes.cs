using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManageMentSerivces.BusinessLayer.Entities.Enums
{
    public enum ErrorCodes
    {
        INVALID_USER,
        INVALID_USER_EMAILID,
        INTERNAL_SERVER_ERROR,
        ERROR_FROM_VALIDATE,
        INVALID_SORTBYPARAMETER,
        INVALID_SORTBY_DIRECTION,
        INVALID_DATE,
        INVALID_USER_STATUS,
        INVALID_USER_ACCESSTYPE,
        INVALID_FROMDATE,
        USER_NOT_FOUND,
    }
}