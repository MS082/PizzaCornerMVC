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
    public class HomeController : Controller
    {
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataReader sqldr;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {

            return View();

            
        }


        [HttpPost]
        public ActionResult sendMsg(Contact instance)
        {
            sqlcon.ConnectionString = "Data Source=LAPTOP-RFTA97Q7\\SQLEXPRESS01;Initial Catalog=PizzaCorner;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "insert into FeedBackTable(Name,Email,Phone,Message) values('" + instance.FName + "','" + instance.FEmail + "','" + instance.FContact + "','" + instance.FMsg + "')";
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            return View("FeedBackAnswer");


        }
    }
}