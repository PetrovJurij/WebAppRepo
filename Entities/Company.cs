using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Company
    {

        public int CompanyId { set; get; }
        public string CompanyName { set; get; }
        public string CompanyDesc { set; get; }
        public decimal Companyrating { set; get; }
        public int NumberOfVotes { set; get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(CompanyId);
            sb.Append('\t');
            sb.Append(CompanyName);
            sb.Append('\t');
            sb.Append(Companyrating);
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

            if(newObj.CompanyId!=CompanyId||newObj.CompanyName!=CompanyName
                ||newObj.Companyrating!=Companyrating||newObj.CompanyDesc!=CompanyDesc
                ||newObj.NumberOfVotes!=NumberOfVotes)
            {
                return false;
            }

            return true;
        }
    }
}
