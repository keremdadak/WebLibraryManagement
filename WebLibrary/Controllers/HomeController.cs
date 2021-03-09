using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibrary.Models.Entity;
using System.Web.Security;

namespace WebLibrary.Controllers
{
    public class HomeController : Controller
    {
        WebLibraryEntities db = new WebLibraryEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_Users register)
        {
            db.tbl_Users.Add(register);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(tbl_Users users)
        {

            return View();
        }
        public ActionResult HomeLibraryList(tbl_Books books)
        {
            var model=db.tbl_Books.ToList();
            return View(model);
        }
    }
}