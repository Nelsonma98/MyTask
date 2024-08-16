using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiTask.Models
{
    public class MyTask
    {
        /// <summary>
        /// The unique identifier of the task.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The title of the task. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "The title cannot exceed 100 characters.")]
        public required string Title { get; set; }

        /// <summary>
        /// The description of the task. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Description is required.")]
        public required string Description { get; set; }
    }
}