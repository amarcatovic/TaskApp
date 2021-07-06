using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Tasks.Data.Models
{
    public class Task
    {
        /// <summary>
        /// Task id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Task title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// User id who reported the task
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User id who was assigned to this task
        /// </summary>
        public int AssigneeId { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Expected finish date
        /// </summary>
        public DateTime FinishDate { get; set; }

        /// <summary>
        /// Is task done
        /// </summary>
        public bool IsDone { get; set; }

        public Task()
        {
            StartDate = DateTime.Now;
            IsDone = false;
        }
    }
}
