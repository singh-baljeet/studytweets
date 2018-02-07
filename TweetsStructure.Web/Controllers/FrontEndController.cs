using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetsStructure.Web.Helpers.Interfaces;
using TweetsStructure.Web.Models;

namespace TweetsStructure.Web.Controllers
{
    public class FrontEndController : Controller
    {
        private readonly IFrontEndHelper _frontendHelper;

        public FrontEndController(IFrontEndHelper frontendHelper)
        {
            _frontendHelper = frontendHelper;
        }

        
        [HttpGet]
        public ActionResult Index()
        {
            var getAllRecords = _frontendHelper.Find(x => x.Deleted == 0);
            return View(getAllRecords);
        }

        [HttpGet]
        public ActionResult Create(FrontEndModel frontendModel)
        {
                return View("Create", frontendModel);
        }

        [HttpPost]
        public ActionResult OnEdit(FrontEndModel frontendModel)
        {
            if (frontendModel.Id > 0)
                _frontendHelper.Update(frontendModel);
            else
                _frontendHelper.Create(frontendModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FindOne(int Id)
        {
            FrontEndModel frontendModel = _frontendHelper.FindOne(x => x.Id == Id && x.Deleted == 0);
            return View("Create", frontendModel);
        }

    }
}