using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetsStructure.Web.Helpers.Interfaces;
using TweetsStructure.Web.Models;

namespace TweetsStructure.Web.Controllers
{
    public class BackEndController : Controller
    {
        private readonly IBackEndHelper _backendHelper;

        public BackEndController(IBackEndHelper backendHelper)
        {
            _backendHelper = backendHelper;
        }

        
        [HttpGet]
        public ActionResult Index()
        {
            var getAllRecords = _backendHelper.Find(x => x.Deleted == 0);
            return View(getAllRecords);
        }

        [HttpGet]
        public ActionResult Create(BackEndModel backendModel)
        {
                return View("Create", backendModel);
        }

        [HttpPost]
        public ActionResult OnEdit(BackEndModel backendModel)
        {
            if (backendModel.Id > 0)
                _backendHelper.Update(backendModel);
            else
                _backendHelper.Create(backendModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FindOne(int Id)
        {
            BackEndModel backendModel = _backendHelper.FindOne(x => x.Id == Id && x.Deleted == 0);
            return View("Create", backendModel);
        }

    }
}