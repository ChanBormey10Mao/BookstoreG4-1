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
    public class BookController : Controller
    {
        private readonly AppDbContext _db;

        public BookController(AppDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Book> objBookList = _db.Books;
            return View(objBookList);
        }
    }
}

