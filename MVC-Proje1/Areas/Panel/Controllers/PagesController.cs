using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Entity;
using Microsoft.Ajax.Utilities;

namespace MVC_Proje1.Areas.Panel.Controllers
{
   
    public class PagesController : BaseController
    {
        private EntityModelContext db = new EntityModelContext();

        // GET: Panel/Pages
        public ActionResult Index()
        {
            var pages = db.Pages.Include(p => p.PageCategory);
            return View(pages.ToList());
        }

        // GET: Panel/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Panel/Pages/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.PageCategories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Panel/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // html kodlarını kontrol etmez
        public ActionResult Create(Page page, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                #region RESİM EKLEME
                if (image != null)
                {
                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                    Image ımg = Image.FromStream(image.InputStream);
                    string uzanti = Path.GetExtension(image.FileName);
                    Guid gd = Guid.NewGuid(); //rastgele resim yolu oluşturacak benzersiz olacak şekilde
                    List<Image> lstimage = ir.Resize(ımg, 800, 350);
                    ir.saveJpeg(Server.MapPath("/Uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);
                    ir.saveJpeg(Server.MapPath("/Uploads/thumb/" + gd.ToString() + uzanti), lstimage[1], 100);
                    page.ImageUrl = "/Uploads/image/" + gd.ToString() + uzanti;
                    page.Thumbrl = "/Uploads/thumb/" + gd.ToString() + uzanti;
                }
                #endregion
                page.PageDate = DateTime.Now; // kategori tarihi otamatik eklendiği günün tarihini alacak

                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.PageCategories, "CategoryID", "CategoryName", page.CategoryID);
            return View(page);
        }

        // GET: Panel/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.PageCategories, "CategoryID", "CategoryName", page.CategoryID);
            return View(page);
        }

        // POST: Panel/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // html kodlarını kontrol etmez
        public ActionResult Edit(Page page, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                #region RESİM EKLEME
                if (image != null)
                {
                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                    Image ımg = Image.FromStream(image.InputStream);
                    string uzanti = Path.GetExtension(image.FileName);
                    Guid gd = Guid.NewGuid(); //rastgele resim yolu oluşturacak benzersiz olacak şekilde
                    List<Image> lstimage = ir.Resize(ımg, 800, 350);
                    ir.saveJpeg(Server.MapPath("/Uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);
                    ir.saveJpeg(Server.MapPath("/Uploads/thumb/" + gd.ToString() + uzanti), lstimage[1], 100);
                    page.ImageUrl = "/Uploads/image/" + gd.ToString() + uzanti;
                    page.Thumbrl = "/Uploads/thumb/" + gd.ToString() + uzanti;
                }
                #endregion
                page.PageDate = DateTime.Now; // kategori tarihi otamatik eklendiği günün tarihini alacak
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.PageCategories, "CategoryID", "CategoryName", page.CategoryID);
            return View(page);
        }

        // GET: Panel/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Panel/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            page.IsActive = false;
            db.Entry(page).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
