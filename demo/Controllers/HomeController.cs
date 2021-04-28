using demo.Model;
using System;
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
        public ActionResult addEmployees()
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

            return RedirectToAction("Index");
        }

        public ActionResult Display()
        {
            var res = obj.Employe_de.ToList();
            return View();
        }

        public ActionResult newdisplay()
        {
            var dis = obj.Employe_de.ToList<Employe_de>();
            return Json(new { data = dis }, JsonRequestBehavior.AllowGet);
        }
       public ActionResult update_info()
        {
            return View();
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
            var res = obj.Employe_de.Where(x => x.ID == id).First();
            obj.Employe_de.Remove(res);
            obj.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            //var res = obj.Employe_de.ToList();
            return RedirectToAction("Display");
        }
    }
}