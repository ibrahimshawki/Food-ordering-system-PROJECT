using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Food_ordering_system_PROJECT.Models;

namespace Food_ordering_system_PROJECT.Controllers
{
    public class HomePageController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

  
    }
}
