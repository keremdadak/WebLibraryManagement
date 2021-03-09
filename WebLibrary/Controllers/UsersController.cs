using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibrary.Controllers;
using WebLibrary.Models.Entity;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class UsersController : Controller
    {
        WebLibraryEntities db = new WebLibraryEntities();
        // GET: Users
        public ActionResult UserIndex()
        {
            
            return View();
        }
        public ActionResult Disconnect()
        {
            Session.Abandon();
            return RedirectToAction("../Home/Index");
        }
       public ActionResult UserLibraryList(tbl_Books booklist)
        {
            var bklist=db.tbl_Books.ToList();
            return View(bklist);
        }
        public ActionResult Reserve(int id)
        {
            DateTime time = DateTime.Now;
            string username= Session["username"].ToString();
            var book = (from i in db.tbl_Books where i.Book_ID == id select i).First();
            int userID = (from i in db.tbl_Users where i.User_Name.Equals(username) select  i.User_ID).SingleOrDefault();
            var userName = (from i in db.tbl_Users where i.User_Name.Equals(username) select i.User_Name).SingleOrDefault();
            tbl_BookReserve bk = new tbl_BookReserve(); {
                bk.Book_Name = book.Book_Name;
                bk.Book_ID = book.Book_ID;
                bk.User_ID =userID;
                bk.Reserver_Date = time;
                bk.User_Name = userName;
                
             
            }
                      
           
            db.tbl_BookReserve.Add(bk);
            db.SaveChanges();
            
            return RedirectToAction("../Users/UserLibraryList");
        }
      
       
    }
}