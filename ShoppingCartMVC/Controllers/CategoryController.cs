using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETCoffee.Models;
using System.Data;

namespace ETCoffee.Controllers
{
    public class CategoryController : Controller
    {
        CoffeeShopEntities db = new CoffeeShopEntities();

        
        /*Show all Subjects*/
        public ActionResult Index()
        {
            var query = db.tblCategories.ToList();

            return View(query);
        }



        /*Add New subject*/
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblCategories c)
        {
            if (ModelState.IsValid)
            {
                tblCategories cat = new tblCategories();
                cat.Name = c.Name;
                db.tblCategories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Not Inserted Category";
            }
            return View();
        }





        /*Edit Existing Subject*/
        public ActionResult Edit(int id)
        {
            var query = db.tblCategories.SingleOrDefault(m => m.CatId == id);
            return View(query);
        }

        [HttpPost]
        public ActionResult Edit(tblCategories c)
        {
            try
            {

                db.Entry(c).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index");
        }




        /*Delete Subject*/
        public ActionResult Delete(int id)
        {
            var query = db.tblCategories.SingleOrDefault(m => m.CatId == id);
            db.tblCategories.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}