using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreG4Web.Data;
using BookStoreG4Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreG4Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;

        public CustomerController(AppDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            //IEnumerable<Customer> objCustomerList = _db.Customers;
            //return View(objCustomerList);
            return View();

        }


        //GET
        
        public IActionResult login(string email, string pwd)
        {
            if (email == null || pwd == null)
            {
                return NotFound();
            }
            var MatchCustomerFromDb = _db.Customers.SingleOrDefault(cus => cus.Cus_Email == email && cus.Cus_Password == pwd);

            if (MatchCustomerFromDb == null)
            {
                return NotFound();
            }
            else
            {
                return View(MatchCustomerFromDb);
            }

        }
    }
}

