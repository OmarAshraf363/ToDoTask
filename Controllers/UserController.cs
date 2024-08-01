using Microsoft.AspNetCore.Mvc;
using ToDoTask.Data;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    public class UserController : Controller
    {
        AppDbContext context=new AppDbContext();
        public IActionResult Index()
        {
            var users=context.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            return View();
        }
    }
}
