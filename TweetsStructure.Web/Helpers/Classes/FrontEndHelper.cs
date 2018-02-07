
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetsStructure.Common.Data.Classes;
using TweetsStructure.Common.Data.Interfaces;
using TweetsStructure.Common.Nhibernate.Interfaces;
using TweetsStructure.Web.Helpers.Interfaces;
using TweetsStructure.Web.Models;

namespace TweetsStructure.Web.Helpers.Classes
{
    public class FrontEndHelper : Repository<FrontEndModel> , IFrontEndHelper
    {
        private readonly IRepository<FrontEndModel> _frontendRepo;

        public FrontEndHelper(ISessionHelper session, IRepository<FrontEndModel> frontendRepo): base(session)
        {
            _frontendRepo = frontendRepo;
        }
    }
}