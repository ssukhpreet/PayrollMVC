using PayrollMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult AdminSection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminCheck(Admin instance)
        {


            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataReader sqldr;

            sqlcon.ConnectionString = "Data Source=LAPTOP-NI9FNBTG\\SQLEXPRESS02;Initial Catalog=payroll;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "select * from Login where Name='" + instance.AdminName + "' and Password='" + instance.AdminPassword + "'";

            sqldr = sqlcmd.ExecuteReader();

            if (sqldr.Read())
            {
                sqlcon.Close();
                return View("Working");
            }
            else
            {
                sqlcon.Close();
                return View("Error");
            }


        }

    }
}