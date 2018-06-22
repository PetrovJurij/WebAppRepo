using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess;

namespace VotingServices
{
    public class UserService:IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool LogIn(string userName, string password)
        {
            User plausibleUser = _userRepository.GetUserByUserName(userName);
            if (plausibleUser == null)
                return false;
            else
            {
                if (plausibleUser.User_Pass != password)
                    return false;
            }

            return true;
        }

        public User GetUserByUserName(string UserName)
        {
            User result = _userRepository.GetUserByUserName(UserName);
            return result;
        }
    }
}
