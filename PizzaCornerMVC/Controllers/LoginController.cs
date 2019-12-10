using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using PizzaCornerMVC.Models;

namespace PizzaCornerMVC.Controllers
{
    public class LoginController : Controller
    {

        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataReader sqldr;


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }




        [HttpPost]
        public ActionResult LoginCheck(Login instance)
        {
            sqlcon.ConnectionString = "Data Source=LAPTOP-RFTA97Q7\\SQLEXPRESS01;Initial Catalog=PizzaCorner;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "select * from LoginTable where Name='" + instance.Name + "' and Password='" + instance.Password + "'";

            sqldr = sqlcmd.ExecuteReader();

            if (sqldr.Read())
            {
                sqlcon.Close();
                return View("DashBoard");
            }
            else
            {
                sqlcon.Close();
                return View("Invalid");
            }


        }



    }
}