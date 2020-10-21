using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebAfricaProject.Entities;

namespace WebAfricaProject.Services
{
    public class ProjectEmployeeService : CrudAppService<ProjectEmployee, ProjectEmployeeDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateProjectEmployeeDto, CreateOrUpdateProjectEmployeeDto>
    {
        public ProjectEmployeeService(IRepository<ProjectEmployee> repository)
        : base(repository)
        {

        }
    }
}
