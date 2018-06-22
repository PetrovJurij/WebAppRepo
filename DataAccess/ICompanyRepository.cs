using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public interface ICompanyRepository
    {
        List<Company> GetCompaniesList(int page, int num);
        int GetCompanyCount();
        Company GetCompany(int Id);
    }
}
