using Food_ordering_system_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Food_ordering_system_PROJECT.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Registration(int id = 0)
        {
            User user = new User();

            return View(user);
        }

        //Post:User
        [HttpPost]
        public ActionResult Registration(User user)
        {
            using (StoreEntities db = new StoreEntities())
            {
                if (db.Users.Any(x => x.e_mail == user.e_mail))
                {

                    ViewBag.DuplicateMessage = "User E-mail Already Exists.";
                    return View("Registration", user);
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessge = "Registration Successful";

            return View("Registration", new User());
        }
    }
}