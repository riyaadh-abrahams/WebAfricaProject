using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAfricaProject.Entities
{
    public class Project : Entity
	{
        public Project(string name, DateTime startdate, DateTime? enddate, double cost)
        {
            Name = name;
            Startdate = startdate;
            Enddate = enddate;
            Cost = cost;
        }

        [Required]
		[Column(TypeName = "VARCHAR(150)")]
		public string Name { get; set; }

		[Required]
		public DateTime Startdate { get; set; }

		public DateTime? Enddate { get; set; }

		[Required]
		[Column(TypeName = "decimal(18, 2)")]
		public double Cost { get; set; }

		public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
	}

	[AutoMap(typeof(Project))]
	public class ProjectDto : EntityDto
	{
		public string Name { get; set; }
		public DateTime Startdate { get; set; }
		public DateTime Enddate { get; set; }
		public double Cost { get; set; }

		public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
	}

	[AutoMap(typeof(Project))]
	public class CreateOrUpdateJobTitleDtoProjectDto : EntityDto
	{
		public string Name { get; set; }
		public DateTime Startdate { get; set; }
		public DateTime Enddate { get; set; }
		public double Cost { get; set; }
	}
}
