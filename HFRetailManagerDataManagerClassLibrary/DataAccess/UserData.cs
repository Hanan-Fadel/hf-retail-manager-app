using HFRetailManagerDataManagerClassLibrary.Internal.DataAccess;
using HFRetailManagerDataManagerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFRetailManagerDataManagerClassLibrary.DataAccess
{
    public class UserData
    {
        //Get infomation from User table
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id }; //Anonymous object

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "HFConnectionString");

            return output;
        }

    }
}
