using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using graphics_pack.Models;

namespace graphics_pack.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
