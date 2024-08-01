using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoTask.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }=string.Empty;
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string Phone { get; set; } = string.Empty;
        [ValidateNever]
        public List<Task> Tasks { get; set; }
        
    }
}
