using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetsStructure.Common.Configuration.Interfaces;

namespace TweetsStructure.Common.Configuration.Classes
{
    public abstract class Configuration : IConfiguration
    {
        public abstract string ConnectionString { get; }
    }
}
