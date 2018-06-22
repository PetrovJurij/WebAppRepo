using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Company
    {

        public int Company_Id { set; get; }
        public string Company_Name { set; get; }
        public string Company_Desc { set; get; }
        public decimal Company_rating { set; get; }
        public int NumberOfVotes { set; get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Company_Id);
            sb.Append('\t');
            sb.Append(Company_Name);
            sb.Append('\t');
            sb.Append(Company_rating);
            sb.Append('\t');

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Company))
            {
                return false;
            }
            Company newObj = (Company)obj;

            if(newObj.Company_Id!=Company_Id||newObj.Company_Name!=Company_Name
                ||newObj.Company_rating!=Company_rating||newObj.Company_Desc!=Company_Desc
                ||newObj.NumberOfVotes!=NumberOfVotes)
            {
                return false;
            }

            return true;
        }
    }
}
