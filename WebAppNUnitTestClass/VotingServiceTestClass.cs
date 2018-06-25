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
    class VotingServiceTestClass
    {

        [Test]
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
