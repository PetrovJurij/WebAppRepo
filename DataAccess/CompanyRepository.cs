using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class CompanyRepository : ICompanyRepository
    {
        public List<Company> GetCompaniesList(int page,int num)
        {
            return new List<Company>
            {
                new Company() {Company_Id=2, Company_Desc=" ", Company_Name="Com #2", Company_rating = 3.3M, NumberOfVotes = 11 },
                new Company() {Company_Id=3, Company_Desc=" ", Company_Name="Com #3", Company_rating = 6.1M, NumberOfVotes = 110 }
            };
        }

        public Company GetCompany(int Id)
        {
            return new Company() { Company_Id = 3, Company_Desc = " ", Company_Name = "Com #3", Company_rating = 6.1M, NumberOfVotes = 110 };
        }

        public int GetCompanyCount()
        {
            return 2;
        }
    }
}
