using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Areas.Panel.Controllers
{
   
    public class PagecategoriesController : BaseController
    {
        // GET: Panel/Pagecategories
        EntityModelContext db = new EntityModelContext();
        public ActionResult Index()
        {
            return View(db.PageCategories.ToList());
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(PageCategory p, HttpPostedFileBase Resim) // resmi dosya yoluyla alma işlemi httppostedfile base ile view de ki name de yazan Resim ile burada yazan Resim aynı olmalı
        {
          
            if (ModelState.IsValid)
            {
                if (Resim!=null)
                {
                    Guid gd = Guid.NewGuid(); // bir daha bilgisayar bu isimde bir dosya yüklemicek.dosyaları benzersiz isimle yazacak
                    string uzanti = Path.GetExtension(Resim.FileName); // yüklenen dosyaların uzantısı ile kaydedecek
                    Resim.SaveAs(Server.MapPath("/Uploads/" + gd.ToString() + uzanti)); // kaydedilen resmi projede bir klasöre kaydet dedik
                    string resimurl = "/Uploads/" + gd.ToString() + uzanti;
                    p.ImageUrl = resimurl;
                }
              
                db.PageCategories.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            return View(db.PageCategories.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PageCategory p, HttpPostedFileBase Resim)
        {
           
            if (ModelState.IsValid)
            {
                if (Resim!=null)
                {
                    Guid gd = Guid.NewGuid(); // bir daha bilgisayar bu isimde bir dosya yüklemicek.dosyaları benzersiz isimle yazacak
                    string uzanti = Path.GetExtension(Resim.FileName); // yüklenen dosyaların uzantısı ile kaydedecek
                    Resim.SaveAs(Server.MapPath("/Uploads/" + gd.ToString() + uzanti)); // kaydedilen resmi projede bir klasöre kaydet dedik
                    string resimurl = "/Uploads/" + gd.ToString() + uzanti;
                    p.ImageUrl = resimurl;
                }
                
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
                

               
            }
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            PageCategory pg = db.PageCategories.Find(id);
            pg.IsActive = false;
            db.Entry(pg).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}