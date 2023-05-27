using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EntityLayer.Entity;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace MVC_Proje1.Areas.Panel.Controllers
{
    public class ProductsController : BaseController
    {
        private EntityModelContext db = new EntityModelContext();

        // GET: Panel/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductCategory);
            return View(products.ToList());
        }

        // GET: Panel/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Panel/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Panel/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Image img = Image.FromStream(image.InputStream);
                    Guid gd = Guid.NewGuid();
                    string uzanti = Path.GetExtension(image.FileName);
                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                    List<Image> lstimage = ir.Resize(img, 800, 350);

                    ir.saveJpeg(Server.MapPath("/uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);
                    ir.saveJpeg(Server.MapPath("/uploads/thumb/" + gd.ToString() + uzanti), lstimage[1], 100);

                    product.ImageUrl = "/uploads/image/" + gd.ToString() + uzanti;
                    product.ThumbUrl = "/uploads/thumb/" + gd.ToString() + uzanti;
                }
                product.ProductDate = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Panel/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Panel/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Image img = Image.FromStream(image.InputStream);
                    Guid gd = Guid.NewGuid();
                    string uzanti = Path.GetExtension(image.FileName);
                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                    List<Image> lstimage = ir.Resize(img, 800, 350);

                    ir.saveJpeg(Server.MapPath("/uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);
                    ir.saveJpeg(Server.MapPath("/uploads/thumb/" + gd.ToString() + uzanti), lstimage[1], 100);

                    product.ImageUrl = "/uploads/image/" + gd.ToString() + uzanti;
                    product.ThumbUrl = "/uploads/thumb/" + gd.ToString() + uzanti;
                }
                product.ProductDate = DateTime.Now;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Panel/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Panel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            product.IsActive = false;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Images(int id)
        {
            return View(db.ProductImages.Where(x => x.ProductID == id).ToList());
        }
        [HttpPost]
        public ActionResult Upload(int id) // çoklu resim ekleme
        {
            HttpFileCollectionBase files = Request.Files;

            List<ProductImage> lsteklenen  = new List<ProductImage>();

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];

                Image img = Image.FromStream(file.InputStream);
                Guid gd = Guid.NewGuid(); // benzersiz resim verdi.
                string uzanti = Path.GetExtension(file.FileName);
                WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                List<Image> lstimage = ir.Resize(img, 800, 350);

                ir.saveJpeg(Server.MapPath("/uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);
                ir.saveJpeg(Server.MapPath("/uploads/thumb/" + gd.ToString() + uzanti), lstimage[1], 100);

                string bimage = "/uploads/image/" + gd.ToString() + uzanti;
                string kimage = "/uploads/thumb/" + gd.ToString() + uzanti;
                ProductImage prdımage = new ProductImage() { ImageUrl = bimage, ThumbUrl = kimage, ProductID = id };
                db.ProductImages.Add(prdımage);
                db.SaveChanges();
                lsteklenen.Add(prdımage);

            }
            return Json(lsteklenen, JsonRequestBehavior.AllowGet);
        }


        
        public int DeleteImages(int id) // ajax la silme ımages viewa bak 
        {
            db.ProductImages.Remove(db.ProductImages.Find(id));
            db.SaveChanges ();
            return id;
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
