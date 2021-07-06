using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TaskApp.Tasks.Data.Commands;
using TaskApp.Tasks.Data.Dtos;
using Task = TaskApp.Tasks.Data.Models.Task;

namespace TaskApp.Tasks.Utilities.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTask, Task>();
            CreateMap<Task, TaskReadDto>();
            CreateMap<EditTask, Task>();
        }
    }
}
