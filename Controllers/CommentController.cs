using Microsoft.AspNetCore.Mvc;
using ToDoTask.Data;
using ToDoTask.Models;

namespace ToDoTask.Controllers
{
    public class CommentController : Controller
    {
        AppDbContext context=new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
           context.Comments.Add(comment);
            context.SaveChanges();
            TempData["success"] = "Comment Added Successfully";
            return RedirectToAction("Index","Task");
        }
        public IActionResult Delete(int id)
        {
            var comment=context.Comments.Find(id);
            if (comment!=null)
            {
                context.Comments.Remove(comment);
                context.SaveChanges();
                TempData["success"] = "Comment Deleted Successfully";
                return RedirectToAction("Index","Task");
            }
            return NotFound();
        }
    }
}
