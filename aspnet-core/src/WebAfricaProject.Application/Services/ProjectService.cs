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
        IRepository<ProjectEmployee> _projectEmployeeRepository;
        IRepository<Employee> _employeeRepository;
        public ProjectService(IRepository<Project> repository, IRepository<ProjectEmployee> projectEmployeeRepository, IRepository<Employee> employeeRepository)
        : base(repository)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
        }

        protected override IQueryable<Project> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAll().Include(p => p.ProjectEmployees).ThenInclude(x => x.Employee);
        }

        public double CalculateTotalProjectCost(List<Employee> employees, double projectBaseCost)
        {
            foreach (Employee item in employees)
            {
                projectBaseCost += item.JobTitle.ExtraProjectCost;
            }
            return projectBaseCost;
        }

        public override PagedResultDto<ProjectDto> GetAll(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto <ProjectDto> initialResults =  base.GetAll(input);
            foreach (ProjectDto item in initialResults.Items)
            {
                IQueryable<ProjectEmployee> projectEmployees = _projectEmployeeRepository.GetAll().Where(p => p.ProjectId == item.Id); 
                List<Employee> employees = _employeeRepository.GetAll().Include(x => x.JobTitle).Where(p => projectEmployees.Any(pem => p.Id == pem.EmployeeId)).ToList();
                item.Employees = employees;

                item.TotalCost = CalculateTotalProjectCost(employees, item.Cost);
            }

            return initialResults;
        }
    }
}
