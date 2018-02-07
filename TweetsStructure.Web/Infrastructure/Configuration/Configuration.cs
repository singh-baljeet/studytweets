using System.Configuration;

namespace TweetsStructure.Web.Infrastructure.Configuration
{
    public class Configuration : TweetsStructure.Common.Configuration.Classes.Configuration
    {
        public override string ConnectionString => ConfigurationManager.ConnectionStrings["ServerDb"].ConnectionString;
    }
}
