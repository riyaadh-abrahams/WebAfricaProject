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
    public class Skill : Entity
    {
        public Skill(string name)
        {
            Name = name;
        }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string Name { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }

    [AutoMap(typeof(Skill))]
    public class SkillDto : EntityDto
    {
        public string Name { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }

    [AutoMap(typeof(Skill))]
    public class CreateOrUpdateSkillDto : EntityDto
    {
        public string Name { get; set; }
    }
}
