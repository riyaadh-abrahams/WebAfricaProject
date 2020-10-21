using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAfricaProject.Entities
{
    public class ProjectEmployee : Entity
    {
        public ProjectEmployee(int? projectId, int? employeeId)
        {
            ProjectId = projectId;
            EmployeeId = employeeId;
        }

        public int? ProjectId { get; set; }

        [Required]
        public Project Project { get; set; }

        public int? EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }
    }

    [AutoMap(typeof(ProjectEmployee))]
    public class ProjectEmployeeDto : EntityDto
    {
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    [AutoMap(typeof(ProjectEmployee))]
    public class CreateOrUpdateProjectEmployeeDto : EntityDto
    {
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
