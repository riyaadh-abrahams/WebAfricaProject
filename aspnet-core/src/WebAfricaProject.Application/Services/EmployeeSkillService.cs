using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebAfricaProject.Entities;
namespace WebAfricaProject.Services
{
    public class EmployeeSkillService : CrudAppService<EmployeeSkill, EmployeeSkillDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateEmployeeSkillDto, CreateOrUpdateEmployeeSkillDto>
    {
        public EmployeeSkillService(IRepository<EmployeeSkill> repository)
        : base(repository)
        {

        }
    }
}
