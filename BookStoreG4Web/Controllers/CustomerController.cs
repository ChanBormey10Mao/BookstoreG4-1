using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BookStoreG4Web.Data;
using BookStoreG4Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace BookStoreG4Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;

        //Assess to database locally
        public CustomerController(AppDbContext db)
        {
            _db = db;
        }


        //Index is the login page
        public IActionResult Index()
        {
            return View();

        }
        //login 
        [HttpPost]
        public IActionResult login(string email, string pwd)
        {
            //If no input , redirect to error page
            if (email == null || pwd == null)
            {
                return RedirectToAction("Error", "Home");
            }
            //Grab the customer obj that matches with the email and password
            var MatchCustomerFromDb = _db.Customers.SingleOrDefault(cus => cus.Cus_Email == email && cus.Cus_Password == pwd);

            //if nothing match
            if (MatchCustomerFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }
            //if an obj match
            else
            {
                MatchCustomerFromDb.IsLogin = true;

                _db.SaveChanges();
                //Set Session for Cus who login
                HttpContext.Session.SetString("Cus_Id", MatchCustomerFromDb.Cus_Id);
                //This session is only for the welcome page
                HttpContext.Session.SetString("Cus_Name", MatchCustomerFromDb.Cus_Name);
                //Rediect to Book List Page
                return RedirectToAction("Index", "Book", new { cus_id = MatchCustomerFromDb.Cus_Id });
            }

        }

        //LogOut 
        public IActionResult LogOut(string email, string pwd)
        {
            HttpContext.Session.Clear(); // it will clear the session at the end of request
            HttpContext.Session.SetString("Cus_Id", "None");
            return RedirectToAction("Index", "Book");//Redirect to Book List page
        }
    }
}

