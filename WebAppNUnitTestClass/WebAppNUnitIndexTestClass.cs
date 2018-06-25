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
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Controllers;

namespace WebAppNUnitTestClass
{
    class WebAppNUnitIndexTestClass
    {

        
        [Test]
        public void CompanyListTest()
        {
            //arrange
            int pageNumber = 1;
            int companiesOnPage = 10;
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompaniesList(pageNumber, companiesOnPage)).Returns(new List<Company>() {
                new Company() {CompanyId=1, CompanyDesc=" ", CompanyName="Com #1", Companyrating = 4.4M, NumberOfVotes = 100 },
                new Company() {CompanyId=2, CompanyDesc=" ", CompanyName="Com #2", Companyrating = 3.3M, NumberOfVotes = 11 },
                new Company() {CompanyId=3, CompanyDesc=" ", CompanyName="Com #3", Companyrating = 6.1M, NumberOfVotes = 110 }
            });
            ILog logger = new Log();
            var controller = new HomeController(logger,
                repoMock.Object,
                new VotingService(votingRepository: new VotingRepository(), logger: logger),
                new UserService(userRepository: new UserRepository(), logger: logger));


            var resultView = controller.Index(1) as ViewResult;
            var resultModel = (ComaniesViewModel)resultView.Model;
            var expected = repoMock.Object.GetCompaniesList(pageNumber, companiesOnPage);

            //Assert

            // --------------------------------------------------
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], resultModel.Companies[i]);
            }
            //------------------------------------------------------------
        }
    }
}
