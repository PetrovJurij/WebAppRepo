using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Entities
{
    public class ResLogger : ILog
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Error(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

    }
}
