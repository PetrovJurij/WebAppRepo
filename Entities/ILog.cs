﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Entities
{
    public interface ILog
    {
        void Info(string message);
        void Error(Exception ex, string message);
    }
}
