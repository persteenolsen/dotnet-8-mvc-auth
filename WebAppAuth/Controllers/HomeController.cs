using System.Diagnostics;

// Used for protect controller / actions by Login
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppAuth.Models;

namespace WebAppAuth.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
    public IActionResult About()
    {
        return View();
    }
    
    
    public IActionResult Me()
    {
        return View();
    }
    
    
    public IActionResult Privacy()
    {
        return View();
    }

    // This Action calls the View only if the User is logged in
    [Authorize]
    public IActionResult Protected()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
