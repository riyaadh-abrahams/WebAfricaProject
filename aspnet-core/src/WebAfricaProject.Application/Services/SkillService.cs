using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebAfricaProject.Entities;

namespace WebAfricaProject.Services
{
    public class SkillService : CrudAppService<Skill, SkillDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateSkillDto, CreateOrUpdateSkillDto>
    {
        public SkillService(IRepository<Skill> repository)
        : base(repository)
        {

        }
    }
}
