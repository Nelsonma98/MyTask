using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace ApiTask.DTOs
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public required string Description { get; set; }
    }
}