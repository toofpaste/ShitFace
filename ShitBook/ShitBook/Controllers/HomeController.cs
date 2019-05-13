using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShitBook.Controllers;
using ShitBook.Models;

namespace ShitBook.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}
