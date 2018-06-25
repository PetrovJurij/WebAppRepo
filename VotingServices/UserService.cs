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
        private ILog _logger;

        public UserService(IUserRepository userRepository,ILog logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public bool LogIn(string userName, string password)
        {
            User plausibleUser = _userRepository.GetUserByUserName(userName);
            if (plausibleUser == null)
            {
                throw new UserDoesNotExistException();
            }
            else
            {
                if (plausibleUser.User_Pass != password)
                {
                    throw new WrongPasswordException();
                }
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
