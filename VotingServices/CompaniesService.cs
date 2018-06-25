using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess;

namespace VotingServices
{
    public class CompaniesService:ICompaniesService
    {
        private ICompanyRepository _companyRepository;
        private ILog _logger;

        public CompaniesService(ICompanyRepository companyRepository,ILog logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public List<Company> GetCompaniesList(int page,int num)
        {
            List<Company> companies = new List<Company>();
            companies = _companyRepository.GetCompaniesList(page, num).ToList();

            return companies;
        }

        public int GetCompaniesCount()
        {
            return _companyRepository.GetCompanyCount();
        }

        public Company GetCompanyById(int Id)
        {
            return _companyRepository.GetCompany(Id);
        }
    }
}
