using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Areas.Panel.Controllers
{
    public class UsersController : BaseController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Panel/Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            if (ModelState.IsValid)
            {
                string passwordHash= WebLibrary.CryptoClass.ToSHA1Hash(u.Password);
                u.Password = passwordHash;
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(u);

            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View(db.Users.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(User u)
        {
            if(ModelState.IsValid)
            {
                string passwordHash = WebLibrary.CryptoClass.ToSHA1Hash(u.Password);
                u.Password = passwordHash;
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u);
        }
        public ActionResult Delete(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}