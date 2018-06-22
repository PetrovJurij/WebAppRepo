using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vote
    {
        public int Vote_Id { set; get; }
        public string Vote_Commentary { set; get; }
        public decimal Vote_Weight { set; get; }
        public string Users_UserName { set; get; }
        public string User_IP { set; get; }
        public string User_hash { set; get; }        
        public int Company_Name { set; get; }

    }
}
