using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreG4Web.Data;
using BookStoreG4Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreG4Web.Controllers
{
    public class BookController : Controller
    {
        //Local db obj;
        private readonly AppDbContext _db;

        //Assess to database locally
        public BookController(AppDbContext db)
        {
            _db = db;
        }
        //Reserve Book 
        public IActionResult Reserve(string? book_id)
        {
            //Find the book that match book id
            Book MatchBookFromDb = _db.Books.SingleOrDefault(b => b.Id == book_id);
            //Find the customer that match customer id (from session, customer who logged in)
            Customer MatchCustomerFromDb = _db.Customers.SingleOrDefault(cus => cus.Cus_Id == HttpContext.Session.GetString("Cus_Id"));
            //If none of customer log in
            if (HttpContext.Session.GetString("Cus_Id") == "None")
            {
                //redirect to Login Page
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                //if customer is loggied in
                //Add new reservation obj to databse obj
                _db.Reservations.Add(new Reservation
                {
                    Cus_Id = MatchCustomerFromDb.Cus_Id,
                    Book_Id = MatchBookFromDb.Id
                });
                //Channg book matched, its IsReserved to be true
                MatchBookFromDb.IsReserved = true;
                //save changes to database
                _db.SaveChanges();
                //Redirect to Book List page with updated reservations
                return RedirectToAction("Index", "Book", new { cus_id = MatchCustomerFromDb.Cus_Id });

            }
          
        }
        //Reservation List Made by Current Customer
        public IActionResult ReturnList()
        {
            //if customer is not logged in
            if (HttpContext.Session.GetString("Cus_Id") == "None")
            {
                //redirect to log in page
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                //if customer is logged in
                //Get list of all reservations made by current customer
                List<Reservation> MatchReservationsFromDbList = _db.Reservations.Where(r => r.Cus_Id == HttpContext.Session.GetString("Cus_Id") && r.IsReturn == false).ToList();
                //Get List of all books
                IEnumerable<Book> objBookList = _db.Books;
                //New list of all the books reserved by current customer
                List<Book> booksMatch = new List<Book>();
                //Adding books to the "all the books reserved by current customer" list 
                foreach (var bookReserved in MatchReservationsFromDbList)
                {
                    foreach (var b in objBookList)
                        if (bookReserved.Book_Id == b.Id)
                        {
                            //Adding Obj
                            booksMatch.Add(b);
                        }
                }
                //Return "all the books reserved by current customer" (ReturnList Page)
                return View(booksMatch);
            }
        }
        //Return Book  (Book id is the id that get from return page for a specific book needs to be returned)
        public IActionResult Return(string? book_id)
        {
            //if customer is not logged in
            if (HttpContext.Session.GetString("Cus_Id") == "None")
            {
                //redirect to log in page
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ///if customer is logged in
                
                // Get the Reservation that
                // --made by current customer
                // --match the book id
                // ---is not returned yet
                Reservation MatchReservationFromDb = _db.Reservations.SingleOrDefault(r => r.Cus_Id == HttpContext.Session.GetString("Cus_Id") && r.IsReturn == false && r.Book_Id == book_id);
                //Update Reservation Satus to be returned
                MatchReservationFromDb.IsReturn = true;
                //Record Returned Time for that reservation
                MatchReservationFromDb.ReturnedTime = DateTime.Now;


                // Get the Book that match book id 
                Book MatchBookFromDb = _db.Books.SingleOrDefault(b => b.Id == book_id);
                //Update Book Reservation Status to be false
                MatchBookFromDb.IsReserved = false; 

                //Save changes to databse
                _db.SaveChanges();
                //Redirect to Reservation List Made by Current Customer
                return RedirectToAction("ReturnList", "Book");


            }
        }
        //Search 
        public IActionResult Index(string searchString)
        {
            //if no search
            if(searchString == null)
            {
                //return all the books 
                IEnumerable<Book> objBookList = _db.Books;
                return View(objBookList);
            }
            //If None of the book exists in database
            if (_db.Books == null)
            {
                //Return Problem Page
                return Problem("No Books created");
            }
            //If searched
            //Get all the book 
            IEnumerable<Book> books = from b in _db.Books
                         select b;
            //get only books matched the search from db
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            //Return books matched the search from db to Book List Page
            return View(books);
        }

    }
}

