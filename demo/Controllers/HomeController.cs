﻿using demo.Model;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        STUDENTSEntities2 obj = new STUDENTSEntities2();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addEmployees(Employe_de id)
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employe_de model)
        {
            Employe_de data = new Employe_de();
            data.EmployeID = model.EmployeID;
            data.Name = model.Name;
            data.Salary = model.Salary;
            data.Grade = model.Grade;

            obj.Employe_de.Add(data);
            obj.SaveChanges();

            ModelState.Clear();

            return RedirectToAction("Display");
        }

        public ActionResult Display()
        {
           
            return View();
        }

        public ActionResult newdisplay()
        {
            var dis = obj.Employe_de.ToList<Employe_de>();
            return Json(new { data = dis }, JsonRequestBehavior.AllowGet);
        }
      

        public ActionResult Delete(int id)
        {
            var item = obj.Employe_de.Where(a => a.ID == id).FirstOrDefault();
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return HttpNotFound();
            }
           
        }

        [HttpPost]
        public ActionResult Delete_item(int id)
        {
            var res = obj.Employe_de.Where(x => x.ID == id).FirstOrDefault();
            obj.Employe_de.Remove(res);
            obj.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            //var res = obj.Employe_de.ToList();
            return RedirectToAction("Display");
        }

        public ActionResult update_info(int id)
        {
            var item = obj.Employe_de.Where(a => a.ID == id).FirstOrDefault();
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult update_from(Employe_de emp)
        {
            obj.Entry(emp).State =EntityState.Modified;
            obj.SaveChanges();
            return RedirectToAction("Display");
        }

        public ActionResult Display_moreinfo(int id)
        {
            var item = obj.Employe_de.Where(a => a.ID == id).FirstOrDefault();
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}