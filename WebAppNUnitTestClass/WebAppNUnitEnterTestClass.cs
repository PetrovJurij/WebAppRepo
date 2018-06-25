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
    [TestFixture]
    public class WebAppNUnitEnterTestClass
    {
        private ILog logger;
        private Mock<IUserService> userServiceMock;
        private Mock<ICompaniesService> companyServiceMock;
        private Mock<IVotingService> votingServiceMock;
        private String userName;
        private String password;

        [SetUp]
        public void SetUpMethod()
        {
            logger = new Log();
            userServiceMock= new Mock<IUserService>();
            companyServiceMock = new Mock<ICompaniesService>();
            votingServiceMock = new Mock<IVotingService>();
            userName = "UserName";
            password = " ";
        }

        [Test]
        public void LoginServiceTrueTest()
        {
            userServiceMock.Setup(x => x.LogIn(userName, password)).Returns(true);
            userServiceMock.Setup(x => x.GetUserByUserName(userName)).Returns(
                new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = " " });
            
            var controller = new HomeController(logger,
                companyServiceMock.Object,
                votingServiceMock.Object,
                userServiceMock.Object);



            var resultView = controller.Enter(userName,password) as ViewResult;
            var resultModelIsUser = (User)resultView.Model;
            var waitedIsUser = new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = password };
            
            Assert.AreEqual(waitedIsUser, resultModelIsUser);
        }

        [Test]
        public void LogInServiceFalseTest()
        {
            userServiceMock.Setup(x => x.LogIn(userName, password)).Returns(false);
            userServiceMock.Setup(x => x.GetUserByUserName(userName)).Returns(
                new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = " " });

            var controller = new HomeController(logger,
                companyServiceMock.Object,
                votingServiceMock.Object,
                userServiceMock.Object);

            var resultView = controller.Enter(userName,password) as ViewResult;
            var resultModel = (User)resultView.Model;

            Assert.IsNull(resultModel);
        }

        [Test]
        public void LogInNullUser()
        {
            userName = null;

            userServiceMock.Setup(x => x.LogIn(userName, password)).Returns(false);
            userServiceMock.Setup(x => x.GetUserByUserName(userName)).Returns(
                new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = " " });


            var controller = new HomeController(logger,
                companyServiceMock.Object,
                votingServiceMock.Object,
                userServiceMock.Object);



            var resultView = controller.Enter(userName, password) as ViewResult;
            var resultModel = (User)resultView.Model;

            Assert.IsNull(resultModel);
        }


        [Test]
        public void LogInNullPass()
        {
            password = null;

            userServiceMock.Setup(x => x.LogIn(userName, password)).Returns(false);
            userServiceMock.Setup(x => x.GetUserByUserName(userName)).Returns(
                new User() { User_Name = userName, User_IP = " ", User_Id = 1, User_Type = " ", User_hash = " ", User_Pass = " " });


            var controller = new HomeController(logger,
                companyServiceMock.Object,
                votingServiceMock.Object,
                userServiceMock.Object);



            var resultView = controller.Enter(userName, password) as ViewResult;
            var resultModel = (User)resultView.Model;

            Assert.IsNull(resultModel);
        }


    }
}
