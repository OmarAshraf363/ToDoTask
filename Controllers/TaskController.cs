using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ToDoTask.Data;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    public class TaskController : Controller
    {
        AppDbContext context = new AppDbContext();
        public IActionResult Index()
        {
            ViewBag.name = Request.Cookies["Name"];

            string? phone = Request.Cookies["Phone"];


            if (phone != null)
            {
                var user = context.Users.Where(e => e.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    var userTasks = context.Tasks.Include(e=>e.Comments).Where(e => e.UserId == user.Id).ToList();
                    ViewBag.UserId = user.Id;
                    return View(userTasks);
                }
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public IActionResult Create()
        {

            string? phone = Request.Cookies["Phone"];
            if (phone != null)
            {
                var user = context.Users.Where(e => e.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    ViewBag.UserId = user.Id;
                    ViewBag.types = Enum.GetValues(typeof(ToDoTask.Models.Task.Type)).Cast<ToDoTask.Models.Task.Type>().ToList();
                    return View();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(ToDoTask.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Add(task);
                context.SaveChanges();
                TempData["success"] = "Task is Added Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                string? phone = Request.Cookies["Phone"];

                var user = context.Users.Where(e => e.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    ViewBag.UserId = user.Id;
                    ViewBag.types = Enum.GetValues(typeof(ToDoTask.Models.Task.Type)).Cast<ToDoTask.Models.Task.Type>().ToList();



                    return View(task);
                }
                else
                {
                    return NotFound();
                }


            }


        }
        public IActionResult Edit(int id)
        {
            var task = context.Tasks.Find(id);
            if (task != null)
            {
                
                ViewBag.types = Enum.GetValues(typeof(ToDoTask.Models.Task.Type)).Cast<ToDoTask.Models.Task.Type>().ToList();
                return View(task);

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Edit(ToDoTask.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Update(task);
                context.SaveChanges();
                TempData["success"] = "Task is Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.types = Enum.GetValues(typeof(ToDoTask.Models.Task.Type)).Cast<ToDoTask.Models.Task.Type>().ToList();
                return View(task);
            }
        }
        public IActionResult Delete(int id)
        {
            var task = context.Tasks.Find(id);
            if (task == null)
            {
                return BadRequest();
            }
            else
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
                TempData["success"] = "Task is Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
        public IActionResult filterDate(DateTime id)
        {
            ViewBag.name = Request.Cookies["Name"];
            string? phone = Request.Cookies["Phone"];
            if (phone != null)
            {
                var user = context.Users.Where(e => e.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    var tasks = context.Tasks.ToList();
                    if (DateTime.Today.AddDays(7) == id)
                    {
                        tasks = context.Tasks.Include(e=>e.Comments).Where(e => e.Deadline <= id && e.UserId == user.Id).ToList();
                    }
                    else
                    {
                        tasks = context.Tasks.Include(e=>e.Comments).Where(e => e.Deadline == id && e.UserId == user.Id).ToList();
                    }
                    return View("Index", tasks);
                }
                else
                {
                    TempData["success"] = "Not Found";
                    return View("Index");
                }
            }
            else
            {
                return NotFound();
            }
        }

    }
}
