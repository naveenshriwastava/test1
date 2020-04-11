using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoProject.Models;
using DemoProject.DataLayer;

namespace DemoProject.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        DemoEntities dbContext = new DemoEntities();
        public ActionResult Index()
        {
            List<EmployeeModels> empList = ADOClient.GetAll();
            TempData["Value"] = empList;
            //return RedirectToAction("Test");
            return View(empList);
        }

        public ActionResult Test() {

            List<EmployeeModels> empList = TempData.Peek("Value") as List<EmployeeModels>;
            EmployeeModels em = new EmployeeModels();
            empList.Add(em);
            return View("Index", empList);
        }

        public ActionResult Test1()
        {
            List<EmployeeModels> empList = TempData["Value"] as List<EmployeeModels>;
            return RedirectToAction("Test1");
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Employee/Create

        public ActionResult Create(EmployeeModels models)
        {
            models.dpModels = ADOClient.GetAllDepartment();
            return View(models);
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                EmployeeModels models = new EmployeeModels();
                models.DepartmentId = Convert.ToInt32(collection["DepartmentId"]);
                models.RowStatus = Convert.ToInt32(collection["RowStatus"]);
                models.Salary = Convert.ToInt32(collection["Salary"]);
                models.EmpoyeeName = collection["EmpoyeeName"];
                ADOClient.Add(models);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
