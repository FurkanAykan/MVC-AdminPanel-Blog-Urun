using EntityLayer.Entity;
using MVC_Proje1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Controllers
{
    public class NavbarController : Controller
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Navbar
        public ActionResult Index()
        {
            NavbarViewModel nv = new NavbarViewModel();
            nv.Pages = db.Pages.ToList();
            nv.Products = db.ProductCategories.ToList();

            return PartialView("_navbar",nv);
        }
    }
}