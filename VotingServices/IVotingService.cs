using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingServices
{
    public interface IVotingService
    {
        bool Vote();

        bool AnonymousVote();
    }
}
