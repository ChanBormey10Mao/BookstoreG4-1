using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStoreG4Web.Models;
using Microsoft.AspNetCore.Http;
using BookStoreG4Web.Data;

namespace BookStoreG4Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
       
    }

    public IActionResult Index()
    {
        //Determine No customer has login
        HttpContext.Session.SetString("Cus_Id", "None");

        return RedirectToAction("Index", "Book");//Redirect to Book List page
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

