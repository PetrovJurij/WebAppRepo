using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace VotingServices
{
    public interface IUserService
    {
        bool LogIn(string userName, string password);
        User GetUserByUserName(string UserName);
    }
}
