using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje1.Controllers
{

    public class ProductsController : Controller
    {
        EntityModelContext db = new EntityModelContext();
        // /products/index/12
        // GET: Products
        //[Route("products/{id}")]
        public ActionResult Index(int? id) // ? olmasının nedeni null olabilir demek
        {
            List<Product> productlist;
            if (id == null)
            {
                productlist = db.Products.Where(x => x.IsActive == true).OrderBy(x => x.CategoryID).ToList();
            }
            else
            {
                productlist = db.Products.Where(x => x.IsActive == true && x.CategoryID == id).ToList();
            }

            return View(productlist);
        }
        public ActionResult ProductDetail(int? id)
        {
            List<ProductImage> lstimage = db.ProductImages.Where(p => p.ProductID == id).ToList();

            var productdetail = db.Products.Find(id);
            //tuple view a model yollama 
            var tuple = Tuple.Create(productdetail, lstimage);

            return View(tuple);
        }
        public ActionResult Sepet(int id)
        {

            Product _product = db.Products.Find(id);

            if (Session["sepet"] == null)
            {
                List<Product> lstsepet = new List<Product>();

                lstsepet.Add(_product);
                Session["sepet"] = lstsepet;

            }
            else
            {
                List<Product> lstsepet = (List<Product>)Session["sepet"];
                lstsepet.Add(_product);

            }


            List<Product> sepet = (List<Product>)Session["sepet"];

            return RedirectToAction("ProductDetail", "products", new { id = RouteData.Values["id"] });
        }


        public int SepetInfo()
        {
            int count = 0;
            if (Session["sepet"] != null)
            {
                List<Product> sepet = (List<Product>)Session["sepet"];
                count = sepet.Count;
            }

            return count;
        }

        public ActionResult SepetDetay()
        {
            List<Product> lstproducts = new List<Product>();
            if (Session["sepet"]!=null)
            {
                lstproducts = (List < Product >) Session["sepet"];
            }
            return View(lstproducts);
        }
        public ActionResult Delete(int id)
        {
          
            List<Product> lstproducts = new List<Product>();

           List<Product> products =  (List<Product>)Session["sepet"];

            //products.Remove(product);
            foreach (var item in products)
            {
                if (item.ProductID!=id)
                {
                    Product product = db.Products.Find();
                  lstproducts.Add(product);
                }
            }

            products = null;

            Session["sepet"] = lstproducts;
            return RedirectToAction("SepetDetay");
        }

    }
}