using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAfricaProject.Entities;

namespace WebAfricaProject.Services
{
    public class ProjectService : CrudAppService<Project, ProjectDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateProjectDto, CreateOrUpdateProjectDto>
    {
        public ProjectService(IRepository<Project> repository)
        : base(repository)
        {

        }

        protected override IQueryable<Project> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAll().Include(p => p.ProjectEmployees).ThenInclude(x => x.Employee);
        }
    }
}
