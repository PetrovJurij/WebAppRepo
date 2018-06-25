using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Entities;
using DataAccess;
using VotingServices;

namespace DomainNUnitTests
{
    public class CompaniesServiceTestClass
    {

        [Test]
        public void TestGetCompaniesByBatchesBatch1CompaniesInBatch5()
        {
            int numberOfCompaniesInBatch = 5;
            int batchNumber = 1;

            var companyList = new List<Company>()
            {
                new Company() {CompanyId=6, CompanyDesc=" ", CompanyName="Com #6", Companyrating = 6.1M, NumberOfVotes = 110 },
                new Company() {CompanyId=3, CompanyDesc=" ", CompanyName="Com #3", Companyrating = 6.1M, NumberOfVotes = 110 },
                new Company() {CompanyId=1, CompanyDesc=" ", CompanyName="Com #1", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=4, CompanyDesc=" ", CompanyName="Com #4", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=2, CompanyDesc=" ", CompanyName="Com #2", Companyrating = 3.3M, NumberOfVotes = 11 },
                new Company() {CompanyId=5, CompanyDesc=" ", CompanyName="Com #5", Companyrating = 3.3M, NumberOfVotes = 11 } };

            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompaniesList(batchNumber, numberOfCompaniesInBatch)).Returns(new List<Company>()
            {
                new Company() {CompanyId=6, CompanyDesc=" ", CompanyName="Com #6", Companyrating = 6.1M, NumberOfVotes = 110 },
                new Company() {CompanyId=3, CompanyDesc=" ", CompanyName="Com #3", Companyrating = 6.1M, NumberOfVotes = 110 },
                new Company() {CompanyId=1, CompanyDesc=" ", CompanyName="Com #1", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=4, CompanyDesc=" ", CompanyName="Com #4", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=2, CompanyDesc=" ", CompanyName="Com #2", Companyrating = 3.3M, NumberOfVotes = 11 }
            });

            repoMock.Setup(x=>x.GetCompaniesCount()).Returns(companyList.Count);
            List<Company> finalCompanyList = repoMock.Object.GetCompaniesList(batchNumber, numberOfCompaniesInBatch);

            int companiesLeft = (repoMock.Object.GetCompaniesCount() - (batchNumber - 1) * numberOfCompaniesInBatch);
            int numberOfAwaitedCompanies = companiesLeft < numberOfCompaniesInBatch ? companiesLeft : numberOfCompaniesInBatch;

            Assert.AreEqual(numberOfAwaitedCompanies, finalCompanyList.Count);
        }



        [Test]
        public void TestCompaniesByBatchesLastBatchCompaniesInBatch6()
        {
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompaniesCount()).Returns(12);
            int numberOfCompaniesInBatch = 6;
            int batchNumber = repoMock.Object.GetCompaniesCount() / numberOfCompaniesInBatch;

            repoMock.Setup(x => x.GetCompaniesList(batchNumber, numberOfCompaniesInBatch)).Returns(new List<Company>()
            {
                new Company() {CompanyId=6, CompanyDesc=" ", CompanyName="Com #6", Companyrating = 6.1M, NumberOfVotes = 110 },
                new Company() {CompanyId=3, CompanyDesc=" ", CompanyName="Com #3", Companyrating = 6.1M, NumberOfVotes = 110 },
                new Company() {CompanyId=1, CompanyDesc=" ", CompanyName="Com #1", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=4, CompanyDesc=" ", CompanyName="Com #4", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=2, CompanyDesc=" ", CompanyName="Com #2", Companyrating = 3.3M, NumberOfVotes = 11 },
                new Company() {CompanyId=5, CompanyDesc=" ", CompanyName="Com #5", Companyrating = 3.3M, NumberOfVotes = 11 }
            });
            List<Company> companyList = repoMock.Object.GetCompaniesList(batchNumber, numberOfCompaniesInBatch);

            int companiesLeft = (repoMock.Object.GetCompaniesCount() - (batchNumber - 1) * numberOfCompaniesInBatch);
            int numberOfAwaitedCompanies = companiesLeft < numberOfCompaniesInBatch ? companiesLeft : numberOfCompaniesInBatch;

            Assert.AreEqual(numberOfAwaitedCompanies, companyList.Count);
        }


    }
}
