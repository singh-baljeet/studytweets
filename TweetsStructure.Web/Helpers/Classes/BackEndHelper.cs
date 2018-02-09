
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
    public class BackEndHelper : Repository<BackEndModel> , IBackEndHelper
    {
        private readonly IRepository<BackEndModel> _backendRepo;

        public BackEndHelper(ISessionHelper session, IRepository<BackEndModel> backendRepo) : base(session)
        {
            _backendRepo = backendRepo;
        }
    }
}