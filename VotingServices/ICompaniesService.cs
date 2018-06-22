using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace VotingServices
{
    public interface ICompaniesService
    {
        List<Company> GetCompaniesList(int page,int num);

        int GetCompaniesCount();

        Company GetCompanyById(int Id);
    }
}
