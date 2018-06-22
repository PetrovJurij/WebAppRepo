using System;
using System.Collections.Generic;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingServices;
using DataAccess;
using Moq;

namespace ServicesTests
{
    [TestClass]
    public class ServiceClassTest
    {
        [TestMethod]
        public void TestGetCompaniesByBatchesBatch1CompaniesInBatch10()
        {
            int numberOfCompaniesInBatch = 10;
            int batchNumber = 1;
            
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompaniesList(batchNumber,numberOfCompaniesInBatch)).Returns(new List<Company>() { });
            List<Company> companyList=repoMock.Object.GetCompaniesList(batchNumber, numberOfCompaniesInBatch);
            
            int companiesLeft= (repoMock.Object.GetCompaniesCount() - (batchNumber - 1) * numberOfCompaniesInBatch);
            int numberOfAwaitedCompanies = companiesLeft < numberOfCompaniesInBatch ? companiesLeft : numberOfCompaniesInBatch;

            Assert.AreEqual(numberOfAwaitedCompanies, companyList.Count);
        }

        

        [TestMethod]
        public void TestCompaniesByBatchesLastBatchCompaniesInBatch6()
        {
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompaniesCount()).Returns(12);
            int numberOfCompaniesInBatch = 6;
            int batchNumber = repoMock.Object.GetCompaniesCount()/ numberOfCompaniesInBatch;
            
            repoMock.Setup(x => x.GetCompaniesList(batchNumber, numberOfCompaniesInBatch)).Returns(new List<Company>()
            {
                new Company() {Company_Id=6, Company_Desc=" ", Company_Name="Com #6", Company_rating = 6.1M, NumberOfVotes = 110 },
                new Company() {Company_Id=3, Company_Desc=" ", Company_Name="Com #3", Company_rating = 6.1M, NumberOfVotes = 110 },
                new Company() {Company_Id=1, Company_Desc=" ", Company_Name="Com #1", Company_rating = 4.4M, NumberOfVotes = 100 },
                new Company() {Company_Id=4, Company_Desc=" ", Company_Name="Com #4", Company_rating = 4.4M, NumberOfVotes = 100 },
                new Company() {Company_Id=2, Company_Desc=" ", Company_Name="Com #2", Company_rating = 3.3M, NumberOfVotes = 11 },
                new Company() {Company_Id=5, Company_Desc=" ", Company_Name="Com #5", Company_rating = 3.3M, NumberOfVotes = 11 }
            });
            List<Company> companyList = repoMock.Object.GetCompaniesList(batchNumber, numberOfCompaniesInBatch);

            int companiesLeft = (repoMock.Object.GetCompaniesCount() - (batchNumber - 1) * numberOfCompaniesInBatch);
            int numberOfAwaitedCompanies = companiesLeft < numberOfCompaniesInBatch ? companiesLeft : numberOfCompaniesInBatch;

            Assert.AreEqual(numberOfAwaitedCompanies, companyList.Count);
        }

        [TestMethod]
        public void TestVoting()
        {
            var repoMock = new Mock<IVotingService>();
            repoMock.Setup(x => x.Vote()).Returns(false);
            int companyId = 1;
            User user = new User();
            string voteComment = "Comment";
            decimal voteWeight = 6.42M;
            user.User_Id = null;
            user.User_IP = "196.12.33.65";
            user.User_hash = "askjfsa";
            user.User_Type = "Anonymous";
            user.User_Pass = null;
            user.User_Name = null;


            repoMock.Object.Vote();
        }
    }
}
