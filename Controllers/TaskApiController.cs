using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using ApiTask.DTOs;
using ApiTask.Models;
using ApiTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiTask.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskApiController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskApiController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/task
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = _taskRepository.GetTasks();
            return Ok(tasks);
        }

        // GET: api/task/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        //POST: api/task
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = new MyTask
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description
            };

            await _taskRepository.CreateTask(task);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            if (updateTaskDto == null)
            {
                return BadRequest("Task data is required.");
            }

            var existingTask = await _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound("Task not found.");
            }

            existingTask.Title = updateTaskDto.Title;
            existingTask.Description = updateTaskDto.Description;

            await _taskRepository.UpdateTask(existingTask);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var success = await _taskRepository.DeleteTask(id);

            if (!success)
            {
                return NotFound("Task not found.");
            }

            return NoContent();
        }
    }
}