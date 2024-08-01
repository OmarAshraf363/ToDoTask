using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoTask.Models
{
    public class Task
    {
       public enum Type
        {
            imbortant,
            normal,test
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Title { get; set; }=string.Empty;
        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Description { get; set; }=string.Empty;
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public Type type { get; set; }
        //Related
        [ForeignKey(nameof(UserId))]
        [Required]
        public int UserId {  get; set; }
        [ValidateNever]
        public User User { get; set; }
        [ValidateNever]
        public List<Comment> Comments { get; set; }
        

    }
}               
