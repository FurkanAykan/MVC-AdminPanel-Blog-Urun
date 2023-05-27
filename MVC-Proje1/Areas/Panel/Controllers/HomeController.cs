using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Areas.Panel.Controllers
{
    
    public class HomeController : BaseController
    {
        // GET: Panel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}