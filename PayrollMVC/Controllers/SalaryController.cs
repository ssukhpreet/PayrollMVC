using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayrollMVC.Models;
namespace PayrollMVC.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        private payrollEntities payroll = new payrollEntities();
        public ActionResult Salary()
        {

            return View(payroll.Salaries.ToList());
        }

        // GET: Salary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Salary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salary/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Salary staffMember)
        {
            if (!ModelState.IsValid)
                return View();
            payroll.Salaries.Add(staffMember);
            payroll.SaveChanges();
            return RedirectToAction("Salary");
        }

        // GET: Salary/Edit/5
        public ActionResult Edit(int id)
        {
            var staffToEdit = (from k in payroll.Salaries where k.ID == id select k).First();
            return View(staffToEdit);
        }

        // POST: Salary/Edit/5
        [HttpPost]
        public ActionResult Edit(Salary staffId)
        {
            var staffToEdit = (from k in payroll.Salaries where k.ID == staffId.ID select k).First();
            if (!ModelState.IsValid)
                return View();
            payroll.Entry(staffToEdit).CurrentValues.SetValues(staffId);
            payroll.SaveChanges();
            return RedirectToAction("Salary");

        }

        // GET: Salary/Delete/5
        public ActionResult Delete(Salary staffId)
        {
            var del = payroll.Salaries.Where(x => x.ID == staffId.ID).FirstOrDefault();
            payroll.Salaries.Remove(del);
            payroll.SaveChanges();
            return RedirectToAction("Salary");
        }

        // POST: Salary/Delete/5
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
