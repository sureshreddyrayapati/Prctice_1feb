using Prctice_1feb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prctice_1feb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        static List<Employee> empList = new List<Employee>()
        {
            new Employee(){Eid=1,EName="Suresh",EDesignation="Mannager",Esal=6500},
            new Employee(){Eid=2,EName="Narendra",EDesignation="Devloper",Esal=8500},
            new Employee(){Eid=3,EName="Surendra",EDesignation="Tester",Esal=7500}
        };
        public ActionResult Index()
        {
            ViewBag.meg = "Welcome To Employee Mannagement";
            ViewBag.noEmo = empList.Count;
            return View(empList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["msg"] = "Employee Registration";
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult Create(Employee em)
        {
            {
                if (ModelState.IsValid)
                {
                    empList.Add(em);
                    TempData["tempmsg"] = "New Employee Registration Successfull";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(em);
                }
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee em = empList.SingleOrDefault(e => e.Eid == id);
            return View(em);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Employee em=empList.SingleOrDefault(e=>e.Eid == id);
            if (em != null)
            {
                empList.Remove(em);
            }
            return RedirectToAction("Index");
        }
    }
}