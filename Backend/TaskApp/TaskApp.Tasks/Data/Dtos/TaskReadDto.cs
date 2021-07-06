using System;
using TaskApp.Tasks.Data.UserService;

namespace TaskApp.Tasks.Data.Dtos
{
    public class TaskReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public UserReadDto User { get; set; }

        public UserReadDto Assignee { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public bool IsDone { get; set; }
    }
}
