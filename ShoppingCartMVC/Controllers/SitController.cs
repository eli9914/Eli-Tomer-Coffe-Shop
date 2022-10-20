using ETCoffee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETCoffee.Controllers
{
    public class SitController : Controller
    {
        CoffeeShopEntities db = new CoffeeShopEntities();

        /*Showing Sits*/
        public ActionResult Index()
        {
            var query = db.getAllTableSits.ToList();
            return View(query);
        }

        /*Creating sits*/
        public ActionResult Create()
        {
            List<tblTable> list = db.tblTable.ToList();
            ViewBag.TableList = new SelectList(list, "tableId","tableId");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblTable tbl)
        {
            List<tblTable> list = db.tblTable.ToList();
            ViewBag.TableList = new SelectList(list, "tableId", "tableId");
            if (ModelState.IsValid)
            {
                tblSit s = new tblSit();
                s.available = 1;
                s.tableId = tbl.tableId;
                db.tblSit.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Didn't create table";
            }
            return View();
        }
        


        /* Remove Sit*/
        public ActionResult Deleted(int id)
        {
            var query = db.tblSit.SingleOrDefault(m => m.sitId == id);
            db.tblSit.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}