using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebAfricaProject.Entities;

namespace WebAfricaProject.Services
{
    public class JobTitleService: CrudAppService<JobTitle, JobTitleDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateJobTitleDto, CreateOrUpdateJobTitleDto>
    {
        public JobTitleService(IRepository<JobTitle> repository)
        : base(repository)
        {

        }
    }
}
