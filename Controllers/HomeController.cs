using Food_ordering_system_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Food_ordering_system_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private StoreEntities db = new StoreEntities();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Product =db.Products.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(String searchCategory)
        {

            if (String.IsNullOrEmpty(searchCategory))
            {
                ViewBag.Product = db.Products.ToList();
            }
            else
            {

                var product = db.Products.Where(p => p.Category.name.Contains(searchCategory)).ToList();
                
                if (product.Count == 0 || product.Count.Equals(null))
                {
                    ViewBag.message = "No Result";
                }

                ViewBag.Product = product;

            }

            return View();
        }

     
        //<------------------------Add Product---------------------->//
        //HttpGet for Update:-----------------
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        //HttpPost for Update:-----------------
        [HttpPost]
        public object Add(Product product, HttpPostedFileBase upload)
        {


            if (ModelState.IsValid)
            {
                String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                product.image = upload.FileName;

                db.Products.Add(product);
                db.SaveChanges();
                var add = db.Categories.SingleOrDefault(m => m.id == product.category_id);
                add.number_of_products++;
                db.Entry(add).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return RedirectToAction("Index");
        }
        //=========================================
        
    }
    
}