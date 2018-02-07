using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetsStructure.Common.Data.Interfaces;
using TweetsStructure.Web.Models;

namespace TweetsStructure.Web.Helpers.Interfaces
{
    public interface IFrontEndHelper : IRepository<FrontEndModel>
    {
    }
}
