using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManageMentSerivces.BusinessLayer.Entities.Enums
{
    public enum UserStatus
    {
        Active,
        Deleted,
        All,
    }

    public enum UserAccessType
    {
        FullAccess,
        StandardAccess,
        ViewOnlyAccess
    }
}
