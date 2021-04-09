using AutoMapper;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManagement.DTO.AutoMapper
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            //source=> Target
            CreateMap<Task, TaskReturnDTO>();
            CreateMap<ICollection<Task>, ICollection<TaskReturnDTO>>();

            //TaskIssue
            CreateMap<TaskIssue, TaskIssueReturnDTO>();
            CreateMap<ICollection<TaskIssue>, ICollection<TaskIssueReturnAllDTO>>();
            CreateMap<CreateTaskIssueDTO, TaskIssue>();
        }
    }
}
