using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebLibrary.Models.Entity;

namespace WebLibrary.Controllers
{
    public class PanelController : Controller
    {
        WebLibraryEntities db = new WebLibraryEntities();
        // GET: Panel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login(tbl_Users users)
        {

            var userInDb = db.tbl_Users.FirstOrDefault(x => x.User_Mail == users.User_Mail && x.User_Password == users.User_Password && x.User_Type == 1);
            var userInDb2 = db.tbl_Users.FirstOrDefault(x => x.User_Mail == users.User_Mail && x.User_Password == users.User_Password && x.User_Type == 0);

            if (userInDb != null)
            {
                Session["username"] = userInDb.User_Name;
                Session["surname"] = userInDb.User_Surname;
                FormsAuthentication.SetAuthCookie(userInDb.User_Mail, false);
                return RedirectToAction("Index");

            }

            else if (userInDb2 != null)
            {

                Session["username"] = userInDb2.User_Name;
                Session["surname"] = userInDb2.User_Surname;
                return RedirectToAction("../Users/UserIndex");
            }
            else
                return RedirectToAction("../Home/Index");

        }

        public ActionResult LibraryList(tbl_Books books)
        {
            var model = db.tbl_Books.ToList();
            return View(model);
        }
        public ActionResult DeleteBook(int id)
        {
            var delbook = db.tbl_Books.Find(id);
            db.tbl_Books.Remove(delbook);
            db.SaveChanges();
            return RedirectToAction("LibraryList");
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(tbl_Books add)
        {
            db.tbl_Books.Add(add);
            db.SaveChanges();
            return RedirectToAction("LibraryList");
        }
        public ActionResult BookDetails(int id)
        {
            var bkdetails = db.tbl_Books.Find(id);

            return View("BookDetails", bkdetails);
        }

        public ActionResult BookUpdate(tbl_Books updt)
        {
            var bkupdate = db.tbl_Books.Find(updt.Book_ID);
            bkupdate.Book_ID = updt.Book_ID;
            bkupdate.Book_Name = updt.Book_Name;
            bkupdate.Book_Writer = updt.Book_Writer;
            bkupdate.Book_NumOfPages = updt.Book_NumOfPages;
            bkupdate.Book_Lang = updt.Book_Lang;
            bkupdate.Book_Description = updt.Book_Description;
            bkupdate.Book_Publisher = updt.Book_Publisher;
            bkupdate.Book_YearOfPrinting = updt.Book_YearOfPrinting;
            db.SaveChanges();
            return RedirectToAction("LibraryList");
        }
        public ActionResult PanelUserList(tbl_Users userlist)
        {
            var userlisttb = db.tbl_Users.ToList();
            return View(userlisttb);
        }
        public ActionResult DeleteUser(int id)
        {
            var deluser = db.tbl_Users.Find(id);
            db.tbl_Users.Remove(deluser);
            db.SaveChanges();
            return RedirectToAction("PanelUserList");
        }
        public ActionResult UpdateUser(tbl_Users updateusr)
        {
            var userupdate = db.tbl_Users.Find(updateusr.User_ID);
            userupdate.User_ID = updateusr.User_ID;
            userupdate.User_Name = updateusr.User_Name;
            userupdate.User_Surname = updateusr.User_Surname;
            userupdate.User_Mail = updateusr.User_Mail;
            userupdate.User_PhoneNumber = updateusr.User_PhoneNumber;
            userupdate.User_Adress = updateusr.User_Adress;
            userupdate.User_Type = updateusr.User_Type;
            db.SaveChanges();
            return RedirectToAction("PanelUserList");


        }
        public ActionResult UserDetails(int id)
        {
            var userdetails = db.tbl_Users.Find(id);
            return View("UserDetails", userdetails);
        }
        public ActionResult ReserveList(tbl_BookReserve reserved)
        {
           var rslist= db.tbl_BookReserve.ToList();
            return View(rslist);        
        }
        public ActionResult DeleteReserve(int id)
        {
            var rsrsil = db.tbl_BookReserve.Find(id);
            db.tbl_BookReserve.Remove(rsrsil);
            db.SaveChanges();
            return RedirectToAction("../Panel/ReserveList");
        }
        public ActionResult Deposit(int id)
        {
            
            return View();
        }
    }
}