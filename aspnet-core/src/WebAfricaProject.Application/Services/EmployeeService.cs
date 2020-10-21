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
    public class EmployeeService: CrudAppService<Employee, EmployeeDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateEmployeeDto, CreateOrUpdateEmployeeDto>
    {
        public EmployeeService(IRepository<Employee> repository)
        : base(repository)
        {

        }

        protected override IQueryable<Employee> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAll().Include(p => p.ProjectEmployees).ThenInclude(x => x.Project)
                 .Include(p => p.EmployeeSkills).ThenInclude(x => x.Skill);
        }

        //public override EmployeeDto Get(EntityDto<int> input)
        //{
        //    EmployeeDto employeeDto =  base.Get(input);


        //    return employeeDto;
        //}
    }
}
