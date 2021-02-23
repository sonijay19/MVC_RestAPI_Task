using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace UserManageMentSerivces.DAO.propeties
{
    public class GetQueryByProperties
    //FirstName LastName UserEmail UserTypeId CreatedDate StatusCode
    {
        public string GetDetailQuery(string fileName,string propertyName)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(@"G:\Training\2_21_2021\UserManageMentSerivces\DAO\propeties\sql.ini");
            string useFullScreenStr = data[fileName][propertyName];
            return useFullScreenStr;
        }
    }
}
