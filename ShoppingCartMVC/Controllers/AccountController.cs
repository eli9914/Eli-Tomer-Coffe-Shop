using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ETCoffee.Models;

namespace ETCoffee.Controllers
{
    public class AccountController : Controller
    {

        CoffeeShopEntities db = new CoffeeShopEntities();

  
        /*register as regular customer*/
        public ActionResult Register()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Register(tblUser t)
        {
            tblUser u = new tblUser();
            if (ModelState.IsValid)
            {
                u.Name = t.Name;
                u.Email = t.Email;
                u.Password = t.Password;
                u.RoleType = 3;
                db.tblUser.Add(u);
                db.SaveChanges();

                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["msg"] = "Not Register!!";
            }
            return View();
        }

        /*register as vip customer*/
        public ActionResult RegisterAsVip()
        {
            return View();
        }



        [HttpPost]
        public ActionResult RegisterAsVip(tblUser t)
        {
            tblUser u = new tblUser();
            if (ModelState.IsValid)
            {
                u.Name = t.Name;
                u.Email = t.Email;
                u.Password = t.Password;
                u.RoleType = 4;
                db.tblUser.Add(u);
                db.SaveChanges();

                return RedirectToAction("Login", "Account");
            }
            else
            {
                TempData["msg"] = "Not Register!!";
            }
            return View();
        }




        /*Log in*/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblUser t)
        {
            var query = db.tblUser.SingleOrDefault(m => m.Email == t.Email && m.Password == t.Password);
            if (query != null)
            {
                if (query.RoleType == 2 || query.RoleType == 1)
                {
                    Session["uid"] = query.UserId;
                    FormsAuthentication.SetAuthCookie(query.Email, false);
                    Session["User"] = query.Name;
                    return RedirectToAction("Index", "Home");
                }
                else if (query.RoleType == 3|| query.RoleType==4)
                {
                    Session["uid"] = query.UserId;
                    FormsAuthentication.SetAuthCookie(query.Email, false);
                    Session["User"] = query.Name;
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                TempData["msg"] = "Invalid Username or Password";
            }
            return View();
        }

        /*Sign Out*/
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
