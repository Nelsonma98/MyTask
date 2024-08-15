using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTask.Repositories
{
    public interface ITaskRepository
    {
        Task<List<MyTask>> GetTasks();
        Task<MyTask> GetTaskById(Guid id);
        Task CreateTask(MyTask task);
        Task UpdateTask(MyTask task);
        Task<bool> DeleteTask(Guid id);
    }
}