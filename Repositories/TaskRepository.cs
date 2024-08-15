using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTask.Context;
using ApiTask.DTOs;
using ApiTask.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTask.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MyTask>> GetTasks()
        {
            try
            {
                return await _context.Tasks.ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<MyTask> GetTaskById(Guid id)
        {
            try
            {
                return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task CreateTask(MyTask task)
        {
            try
            {
                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateTask(MyTask task)
        {
            try
            {
                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null)
                {
                    return false;
                }
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}