using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayrollMVC.Models;
namespace PayrollMVC.Controllers
{
    public class staffController : Controller
    {


        // GET: staff
        private payrollEntities payroll = new payrollEntities();

        public ActionResult Staff()
        {
            return View(payroll.Staffs.ToList());
        }

        // GET: staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Staff staffMember)
        {
            if (!ModelState.IsValid)
                return View();
            payroll.Staffs.Add(staffMember);
            payroll.SaveChanges();
            return RedirectToAction("Staff");
        }

        // GET: staff/Edit/5
        public ActionResult Edit(int id)
        {
            var staffToEdit = (from k in payroll.Staffs where k.id==id select k).First();
            return View(staffToEdit);
        }

        // POST: staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff staffId)
        {
            var staffToEdit = (from k in payroll.Staffs where k.id == staffId.id select k).First();
            if (!ModelState.IsValid)
                return View();
            payroll.Entry(staffToEdit).CurrentValues.SetValues(staffId);
            payroll.SaveChanges();
            return RedirectToAction("Staff");

        }

        // GET: staff/Delete/5
        public ActionResult Delete(Staff StaffId)
        {
            var del = payroll.Staffs.Where(x=>x.id== StaffId.id).FirstOrDefault();
            payroll.Staffs.Remove(del);
            payroll.SaveChanges();
            return RedirectToAction("Staff");

        }

        // POST: staff/Delete/5
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
