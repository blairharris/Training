using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        private readonly List<Task> _tasks = new List<Task>();

        public TaskController()
        {
            Task task1 = new Task() { Id = 1, Description = "Shower", DueDate = DateTime.Today, Complete = false };
            _tasks.Add(task1);

            Task task2 = new Task() { Id = 2, Description = "Dress", DueDate = DateTime.Today, Complete = false };
            Task subTask21 = new Task() { Id = 21, Description = "Put pants on", DueDate = DateTime.Today, Complete = false };
            Task subTask22 = new Task() { Id = 22, Description = "Put shirt on", DueDate = DateTime.Today, Complete = false };
            task2.SubTasks = new List<Task>();
            task2.SubTasks.Add(subTask21);
            task2.SubTasks.Add(subTask22);
            _tasks.Add(task2);
        }

        [Route("Tasks")]
        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        [Route("Task/{id}")]
        public IHttpActionResult GetTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [Route("Task/{taskId}/SubTasks")]
        public IHttpActionResult GetAllSubTasks(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return NotFound();
            }
            Task subTask21 = new Task() { Id = 21, Description = "Put pants on", DueDate = DateTime.Today, Complete = false };
            Task subTask22 = new Task() { Id = 22, Description = "Put shirt on", DueDate = DateTime.Today, Complete = false };
            List<Task> subTasks = new List<Task>() { subTask21, subTask22 };
            return Ok(subTasks);
        }
    }
}
