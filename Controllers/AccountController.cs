using Microsoft.AspNetCore.Mvc;
using ToDoTask.Data;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext context=new AppDbContext();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.FirstOrDefault(e => e.Name == model.Name && e.Phone == model.Phone);
                if (user == null)
                {
                    ModelState.AddModelError("","Wrong Email or Password");
                    return View(model);
                }
                else
                {
                    CookieOptions options = new CookieOptions()
                    {
                        Expires = DateTime.Now.AddDays(1)
                    };
                    Response.Cookies.Append("Name", user.Name, options);
                    Response.Cookies.Append("Phone", user.Phone, options);
                    return RedirectToAction("Index", "Task");

                }
            }
            else
            {
                return View(model);
            }

        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Name");
            Response.Cookies.Delete("Phone");
            return RedirectToAction("Login");
        }
        //Add User In Data Base
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.FirstOrDefault(e => e.Name == model.Name || e.Phone == model.Phone);
                if (user == null)
                {
                    context.Users.Add(model);
                    context.SaveChanges();
                    TempData["success"] = "All is Done";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Name or Phone Allready Existed");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

    }
}
