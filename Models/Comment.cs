using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTask.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        [ForeignKey(nameof(TaskId))]
        public int TaskId { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public Task Task { get; set; }
        public User User { get; set; }
    }
}
