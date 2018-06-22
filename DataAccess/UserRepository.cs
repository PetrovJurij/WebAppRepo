using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class UserRepository:IUserRepository
    {

        public User GetUserByUserName(string user_UserName)
        {
            User result = new User() { User_Name = user_UserName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = " " };
            return result;
        }
    }
}
