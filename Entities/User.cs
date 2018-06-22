using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User() { }
        public User(User user)
        {
            User_Id = user.User_Id;
            User_Name = user.User_Name;
            User_IP = user.User_IP;
            User_hash = user.User_hash;
            User_Type = user.User_Type;
            User_Pass = user.User_Pass;
        }
        public int? User_Id { set; get; }
        public String User_Name { set; get; }
        public string User_IP { set; get; }
        public string User_hash { set; get; }
        public string User_Type{ set; get; }
        public String User_Pass { set; get; }

        

        public override bool Equals(object obj)
        {
            if(obj.GetType()!=GetType())
            {
                return false;
            }

            User newObj = (User)obj;

            if (newObj.User_hash != User_hash || newObj.User_Name != User_Name || newObj.User_Id != User_Id ||
                newObj.User_IP != User_IP || newObj.User_Pass != User_Pass || newObj.User_Type != User_Type)
                return false;

            return true;
        }
    }
}
