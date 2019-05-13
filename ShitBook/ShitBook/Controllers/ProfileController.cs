using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ShitBook.Models;

namespace ShitBook.Controllers
{
  public class ProfilesController : Controller
  {
    [HttpGet("/user/{userId}/profile/new")]
        public ActionResult New(int userId)
        {
            User user = User.Find(userId);
            return View(user);
        }

        [HttpGet("/user/{userId}/profile/{profileId}")]
        public ActionResult Show(int userId, int profileId)
        {
            About about = About.Find(profileId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            User user = User.Find(userId);
            model.Add("about", about);
            model.Add("user", user);
            return View(model);
        }

        [HttpPost("/profile/delete")]
        public ActionResult DeleteAll()
        {
            About.ClearAll();
            return View();
        }

        [HttpGet("/user/{userId}/profile/{profileId}/edit")]
        public ActionResult Edit(int userId, int profileId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            User User = User.Find(userId);
            model.Add("user", User);
            About about = About.Find(profileId);
            model.Add("about", about);
            return View(model);
        }

        [HttpPost("/user/{userId}/profile/{profileId}")]
        public ActionResult Update(DateTime newBirth, string newHome, string newName, int newAge, int userId, int profileId)
        {
            About about = About.Find(profileId);
            About.Edit(newBirth, newHome, newName,newAge);
            Dictionary<string, object> model = new Dictionary<string, object>();
            User user = User.Find(userId);
            model.Add("user", user);
            model.Add("about", about);
            return View("Show", model);
        }

  }
}
