using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VotedSecondTimeException : Exception
    {
        public VotedSecondTimeException()
        {
        }

        public VotedSecondTimeException(string message) : base(message)
        {
        }

        public VotedSecondTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VotedSecondTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
