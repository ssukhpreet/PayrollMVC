using PayrollMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollMVC.Controllers
{
    public class AttendenceController : Controller
    {
        // GET: Attendence
        private payrollEntities payroll = new payrollEntities();
        public ActionResult Attendence()
        {
            return View(payroll.Attendences.ToList());
        }

        // GET: Attendence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Attendence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendence/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Attendence staffMember)
        {

            if (!ModelState.IsValid)
                return View();
            payroll.Attendences.Add(staffMember);
            payroll.SaveChanges();
            return RedirectToAction("Attendence");
        }

        // GET: Attendence/Edit/5
        public ActionResult Edit(int id)
        {
            var staffToEdit = (from k in payroll.Attendences where k.id == id select k).First();
            return View(staffToEdit);
        }

        // POST: Attendence/Edit/5
        [HttpPost]
        public ActionResult Edit(Attendence staffId)
        {
            var staffToEdit = (from k in payroll.Attendences where k.id == staffId.id select k).First();
            if (!ModelState.IsValid)
                return View();
            payroll.Entry(staffToEdit).CurrentValues.SetValues(staffId);
            payroll.SaveChanges();
            return RedirectToAction("Attendence");
        }

        // GET: Attendence/Delete/5
        public ActionResult Delete(Attendence staffId)
        {
            var del = payroll.Attendences.Where(x => x.id == staffId.id).FirstOrDefault();
            payroll.Attendences.Remove(del);
            payroll.SaveChanges();
            return RedirectToAction("Attendence");
          
        }

        // POST: Attendence/Delete/5
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
