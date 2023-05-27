using EntityLayer.Entity;
using MVC_Proje1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Controllers
{
    public class HomeController : Controller
    {
        EntityModelContext db = new EntityModelContext();
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Sliders = db.Sliders.ToList();
            model.ProductCategories = db.ProductCategories.ToList();
            return View(model);
        }

    
        public ActionResult BlogHome()
        {
            List<Page> lstpage = db.Pages.Where(x => x.CategoryID == 7 && x.IsActive == true).OrderByDescending(x => x.PageID).Take(3).ToList();
            return PartialView("_blog", lstpage);
        }
    
       public ActionResult Footer()
        {
            FooterViewModel fw = new FooterViewModel();
           
            fw.Contact=db.Contacts.Take(1).FirstOrDefault();

            fw.LastPages = db.Pages.Where(x=>x.CategoryID==7 && x.IsActive==true).OrderByDescending(p=>p.PageID).Take(3).ToList();

            fw.Socials = db.Socials.Take(1).FirstOrDefault();

            return PartialView("_footer",fw);
        }
    }
}