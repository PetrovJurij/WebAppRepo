using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace VotingServices
{
    public class VotingService:IVotingService
    {
        private IVotingRepository _votingRepository;

        public VotingService(IVotingRepository votingRepository)
        {
            _votingRepository = votingRepository;
        }
        public bool Vote()
        {
            return _votingRepository.Vote();
        }

        public bool AnonymousVote()
        {

            return _votingRepository.Vote();
        }
    }
}
