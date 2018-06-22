using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public interface IUserRepository
    {
        User GetUserByUserName(string user_UserName);

    }
}
