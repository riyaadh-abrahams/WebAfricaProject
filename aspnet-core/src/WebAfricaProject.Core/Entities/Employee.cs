﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAfricaProject.Entities
{
    public class Employee : Entity
    {
        public Employee(string name, string surname, int? jobTitleId)
        {
            Name = name;
            Surname = surname;
            JobTitleId = jobTitleId;
        }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string Surname { get; set; }

        public int? JobTitleId { get; set; }

        [Required]
        public JobTitle JobTitle { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }

    [AutoMap(typeof(Employee))]
    public class EmployeeDto : EntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }

    [AutoMap(typeof(Employee))]
    public class CreateOrUpdateEmployeeDto : EntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? JobTitleId { get; set; }
    }
}