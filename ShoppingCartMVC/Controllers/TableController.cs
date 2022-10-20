using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETCoffee.Models;

namespace ETCoffee.Controllers
{
    public class TableController : Controller
    {
        CoffeeShopEntities db = new CoffeeShopEntities();
        
        /* Showing tables */
        public ActionResult Index()
        {
            var query = db.tblTable.ToList();
            return View(query);
        }
        

        /*Create Table*/
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblTable table)
        {
            if (ModelState.IsValid)
            {
                tblTable tbl = new tblTable();
                tbl.area = table.area;
                tbl.numSeats = table.numSeats;
                db.tblTable.Add(tbl);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Didn't create table";
            }
            return View();
        }
        

        /*Edit table*/
        public ActionResult Edit(int id)
        {
            var query = db.tblTable.SingleOrDefault(m => m.tableId == id);
            return View(query);
        }

        [HttpPost]
        public ActionResult Edit(tblTable tbl)
        {
            try
            {
                var query = db.tblTable.SingleOrDefault(m => m.tableId == tbl.tableId);
                query.area = tbl.area;
                db.Entry(query).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index");
        }
        

        /*Delete table*/
        public ActionResult Delete(int id)
        {
            var query = db.tblTable.SingleOrDefault(m => m.tableId == id);
            db.tblTable.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}