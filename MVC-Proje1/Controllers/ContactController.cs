using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        EntityModelContext db = new EntityModelContext();
        public ActionResult Index()
        {
            return View (db.Contacts.ToList());
        }
    }
}