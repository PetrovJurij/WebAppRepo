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
    class WebAppNUnitCompanyWithVotingTestClass
    {

        [Test]
        public void CompanyChoosingTest()
        {
            int Company_Id = 12;
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompanyById(Company_Id)).Returns(
                new Company() { CompanyId = 12, CompanyDesc = " ", CompanyName = "Com #12", Companyrating = 4.4M, NumberOfVotes = 100 });
            ILog logger = new Log();
            var controller = new HomeController(logger,
                repoMock.Object,
                new VotingService(votingRepository: new VotingRepository(), logger: logger),
                new UserService(userRepository: new UserRepository(), logger: logger));

            var resultView = controller.CompanyWithVoting(12) as ViewResult;
            var resultModel = (Company)resultView.Model;
            var waited = repoMock.Object.GetCompanyById(Company_Id);

            Assert.AreEqual(waited, resultModel);
        }



        [Test]
        public void AnonymousVoteTest()
        {
            var firstAnonMock = new Mock<IVotingService>();
            firstAnonMock.Setup(x => x.AnonymousVote()).Returns(true);
            ILog logger = new Log();
            var controller = new HomeController(logger,
                new CompaniesService(companyRepository: new CompanyRepository(), logger: logger),
                firstAnonMock.Object,
                new UserService(userRepository: new UserRepository(), logger: logger));

            VotingFormModel votingFormModel = new VotingFormModel() { Company_Id = 1, Comment = " ", Evaluation = 5 };
            var resultView = controller.Vote(votingFormModel) as ViewResult;
            var resultModel = (Vote)resultView.Model;
            var waited = new Vote();

            firstAnonMock.Setup(x => x.AnonymousVote()).Returns(false);

        }

        [Test]
        public void NonAnonymousVoteTest()
        {
            var firstAnonMock = new Mock<IVotingService>();
            firstAnonMock.Setup(x => x.AnonymousVote()).Returns(true);
            ILog logger = new Log();
            var controller = new HomeController(logger,
                new CompaniesService(companyRepository: new CompanyRepository(), logger: logger),
                firstAnonMock.Object,
                new UserService(userRepository: new UserRepository(), logger: logger));

            VotingFormModel votingFormModel = new VotingFormModel() { Company_Id = 1, Comment = " ", Evaluation = 5 };
            var resultView = controller.Vote(votingFormModel) as ViewResult;
            var resultModel = (Vote)resultView.Model;
            var waited = new Vote();
            

            firstAnonMock.Setup(x => x.Vote()).Returns(false);

        }

    }
}
