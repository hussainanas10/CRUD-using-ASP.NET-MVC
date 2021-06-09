using demo.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class tableController : Controller
    {
        STUDENTSEntities3 obj = new STUDENTSEntities3();
        // GET: table
        public ActionResult Index()
        {
            //var data = obj.Employedes.ToList();
            return View();
        }
        //search
        public ActionResult Search(string product)
        {
            
            List<Employede> D;
            if (!string.IsNullOrEmpty(product))
            {
                D = obj.Employedes.Where(x => x.Name.Contains(product) || x.Grade.Contains(product)).ToList();
            }
            else
            {
                D = obj.Employedes.ToList();
            }
            return View("Index", D);
        }
    }
}