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
    public class JobTitle : Entity
    {
        public JobTitle(string jobTitleLabel)
        {
            JobTitleLabel = jobTitleLabel;
        }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string JobTitleLabel { get; set; }

    }

    [AutoMap(typeof(JobTitle))]
    public class JobTitleDto : EntityDto
    {
        public string JobTitleLabel { get; set; }

    }

    [AutoMap(typeof(JobTitle))]
    public class CreateOrUpdateJobTitleDto : EntityDto
    {
        public string JobTitleLabel { get; set; }

    }
}
