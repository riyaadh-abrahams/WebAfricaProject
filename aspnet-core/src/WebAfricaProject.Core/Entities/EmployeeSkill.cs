using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WebAfricaProject.Entities
{
    public class EmployeeSkill : Entity
    {
        public EmployeeSkill(int? employeeId, int? skillId)
        {
            EmployeeId = employeeId;
            SkillId = skillId;
        }

        public int? EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public int? SkillId { get; set; }

        [Required]
        public Skill Skill { get; set; }
    }

    [AutoMap(typeof(EmployeeSkill))]
    public class EmployeeSkillDto : EntityDto
    {
        public int? EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int? SkillID { get; set; }
        public Skill Skill { get; set; }
    }

    [AutoMap(typeof(EmployeeSkill))]
    public class CreateOrUpdateEmployeeSkillDto : EntityDto
    {
        public int? SkillID { get; set; }
        public int? EmployeeID { get; set; }
    }
}
