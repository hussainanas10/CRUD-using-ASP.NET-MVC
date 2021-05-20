using demo.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo.Extensions;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        STUDENTSEntities3 obj= new STUDENTSEntities3();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addEmployees(Employede id)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employede model)
        {
            Employede data = new Employede();
            data.EmployeID = model.EmployeID;
            data.Name = model.Name;
            data.Salary = model.Salary;
            data.Grade = model.Grade;

            obj.Employedes.Add(data);
            obj.SaveChanges();
            //if
            //   ( model.Grade.Length>1)
            ModelState.Clear();
            this.Flash("Data added ", NotificationType.SUCCESS);
            return RedirectToAction("Display");
        }

        public ActionResult Display()
        {
           
            return View();
        }

        public ActionResult newdisplay()
        {
            var dis = obj.Employedes.ToList<Employede>();
            return Json(new { data = dis }, JsonRequestBehavior.AllowGet);
        }
      

        public ActionResult Delete(int id)
        {
            var item = obj.Employedes.Where(a => a.ID == id).FirstOrDefault();
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
            var res = obj.Employedes.Where(x => x.ID == id).FirstOrDefault();
            obj.Employedes.Remove(res);
            obj.SaveChanges();
            this.Flash("Record Delete Successfully", NotificationType.SUCCESS);
            
            //var res = obj.Employede.ToList();
            return RedirectToAction("Display");
        }

        public ActionResult update_info(int id)
        {
            var item = obj.Employedes.Where(a => a.ID == id).FirstOrDefault();
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
        public ActionResult update_from(Employede emp)
        {
            if(emp.Grade.Length>1)

            { this.Flash("grade must be single char", NotificationType.WARNING); }
            
                if (ModelState.IsValid) {
               
                obj.Entry(emp).State = EntityState.Modified;

                obj.SaveChanges();
                this.Flash(emp.Name + "'s Details Updated Successfully ", NotificationType.SUCCESS);
                return RedirectToAction("Display");

            }
            return RedirectToAction("Index");
        }

        public ActionResult Display_moreinfo(int id)
        {
            var item = obj.Employedes.Where(a => a.ID == id).FirstOrDefault();
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