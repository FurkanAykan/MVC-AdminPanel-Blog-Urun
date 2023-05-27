using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Controllers
{
    public class PagesController : Controller
    {
        EntityModelContext db = new EntityModelContext();
       
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index", "hata");
            }
            else
            {
                ViewBag.title = db.PageCategories.Find(id).CategoryName;
                return View(db.Pages.Where(x => x.CategoryID == id).OrderByDescending(x=>x.PageID).ToList());
            }

        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Hata");
            }
            else
            {
                return View(db.Pages.Find(id));
            }


        }
    }
}