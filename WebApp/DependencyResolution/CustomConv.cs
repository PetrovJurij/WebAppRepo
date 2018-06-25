using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DependencyResolution
{
    public class CustomConv : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            
        }
    }
}