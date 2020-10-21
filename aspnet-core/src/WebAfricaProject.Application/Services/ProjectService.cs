using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebAfricaProject.Entities;

namespace WebAfricaProject.Services
{
    public class ProjectService : CrudAppService<JobTitle,ProjectDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateJobTitleDto, CreateOrUpdateJobTitleDto>
    {
        public ProjectService(IRepository<JobTitle> repository)
        : base(repository)
        {

        }
    }
}
