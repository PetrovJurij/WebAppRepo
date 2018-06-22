using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp;
using WebApp.Controllers;
using Entities;
using Moq;
using System.Collections.Generic;
using DataAccess;
using System.Web.Mvc;
using VotingServices;
using WebApp.Models;


namespace WebAppTests
{
    [TestClass]
    public class WebAppTests
    {
        [TestMethod]
        public void CompanyListTest()
        {
            int pageNumber = 1;
            int companiesOnPage = 10;
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompaniesList(pageNumber,companiesOnPage)).Returns(new List<Company>() {
                new Company() {Company_Id=1, Company_Desc=" ", Company_Name="Com #1", Company_rating = 4.4M, NumberOfVotes = 100 },
                new Company() {Company_Id=2, Company_Desc=" ", Company_Name="Com #2", Company_rating = 3.3M, NumberOfVotes = 11 },
                new Company() {Company_Id=3, Company_Desc=" ", Company_Name="Com #3", Company_rating = 6.1M, NumberOfVotes = 110 }
            });
            var controller = new HomeController(new ResLogger(),repoMock.Object,
                new VotingService(votingRepository: new VotingRepository()),new UserService(userRepository:new UserRepository()));


            var resultView = controller.Index(1) as ViewResult;
            var resultModel= (ComaniesViewModel)resultView.Model;
            var waited = repoMock.Object.GetCompaniesList(pageNumber, companiesOnPage);

            for(int i=0;i<waited.Count;i++)
            {
                Assert.AreEqual(waited[i],resultModel.Companies[i]);
            }

        }

        [TestMethod]
        public void CompanyChoosingTest()
        {
            int Company_Id = 12;
            var repoMock = new Mock<ICompaniesService>();
            repoMock.Setup(x => x.GetCompanyById(Company_Id)).Returns(
                new Company() { Company_Id = 12, Company_Desc = " ", Company_Name = "Com #12", Company_rating = 4.4M, NumberOfVotes = 100 });
            var controller = new HomeController(new ResLogger(), repoMock.Object, 
                new VotingService(votingRepository: new VotingRepository()), new UserService(userRepository: new UserRepository()));

            var resultView = controller.CompanyWithVoting(12) as ViewResult;
            var resultModel = (Company)resultView.Model;
            var waited = repoMock.Object.GetCompanyById(Company_Id);

            Assert.AreEqual(waited, resultModel );
        }

        [TestMethod]
        public void EnterTest()
        {
            string userName = "UserName";
            string password = " ";
            var repoMock = new Mock<IUserService>();
            repoMock.Setup(x => x.LogIn(userName, password)).Returns(true);
            repoMock.Setup(x => x.GetUserByUserName(userName)).Returns(
                new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = " "}   );
            var controller = new HomeController(new ResLogger(), new CompaniesService(companyRepository:new CompanyRepository()),
                new VotingService(votingRepository: new VotingRepository()), repoMock.Object);



            UserModel model = new UserModel() { UserName=userName,Password=password};
            var resultView=controller.Enter(model) as ViewResult;
            var resultModel = (User)resultView.Model;
            var waited = new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass =password};

            Assert.AreEqual(waited,resultModel);
        }

        [TestMethod]
        public void AnonymousVoteTest()
        {
            var firstAnonMock = new Mock<IVotingService>();
            firstAnonMock.Setup(x => x.AnonymousVote()).Returns(true);

            var controller = new HomeController(new ResLogger(), new CompaniesService(companyRepository:new CompanyRepository()),
                firstAnonMock.Object,new UserService(userRepository:new UserRepository()));

            VotingFormModel votingFormModel = new VotingFormModel() { Company_Id = 1, Comment = " ", Evaluation = 5 };
            var resultView = controller.Vote(votingFormModel) as ViewResult;
            var resultModel = (Vote)resultView.Model;
            var waited=new Vote

            firstAnonMock.Setup(x => x.AnonymousVote()).Returns(false);

        }
    }

}
