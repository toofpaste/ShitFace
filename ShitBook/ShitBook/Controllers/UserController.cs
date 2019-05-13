using Microsoft.AspNetCore.Mvc;
using ShitBook.Models;
using System.Collections.Generic;
using System;

namespace ShitBook.Controllers
{
  public class UserController : Controller
  {
    [HttpGet("/user")]
        public ActionResult Index()
        {
            List<User> allUsers = User.GetAll();
            return View(allUsers);
        }

        [HttpGet("/user/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/user")]
        public ActionResult Create(string userName)
        {
            User newUser = new User(userName);
            newUser.Save();
            List<User> allUsers = User.GetAll();
            return View("Index", allUsers);
        }

        [HttpGet("/user/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            User selectedUser = User.Find(id);
            List<About> userAbout = selectedUser.GetItems();
            model.Add("user", selectedUser);
            model.Add("about", userAbout);
            return View(model);
        }

        [HttpPost("/user/{userId}/profile")]
        public ActionResult Create(DateTime newBirth, string newHome, string newName, int newAge, int userId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            User foundUser = User.Find(userId);
            About newItem = new About(itemDescription, shiftDate, userId, endShift, cutInfo, imgUrl, price);
            newItem.Save();
            foundUser.AddItem(newItem);
            List<About> userAbout = foundUser.GetItems();
            model.Add("profile", userAbout);
            model.Add("user", foundUser);
            return View("Show", model);
        }
  }
}
