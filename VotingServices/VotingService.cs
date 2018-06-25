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
        private ILog _logger;

        public VotingService(IVotingRepository votingRepository,ILog logger)
        {
            _votingRepository = votingRepository;
            _logger = logger;
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
