using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using WebAfricaProject.Entities;

namespace WebAfricaProject.Services
{
    public class EmployeeService: CrudAppService<Employee, EmployeeDto, int, PagedAndSortedResultRequestDto, CreateOrUpdateEmployeeDto, CreateOrUpdateEmployeeDto>
    {
        IRepository<ProjectEmployee> _projectEmployeeRepository;
        IRepository<Project> _projectRepository;
        IRepository<EmployeeSkill> _employeeSkillRepository;
        IRepository<Skill> _skillRepository;

        public EmployeeService(IRepository<Employee> repository, 
        IRepository<ProjectEmployee> projectEmployeeRepository,
        IRepository<Project> projectRepository,
        IRepository<EmployeeSkill> employeeSkillRepository,
        IRepository<Skill> skillRepository)
        : base(repository)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
            _projectRepository = projectRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _skillRepository = skillRepository;
        }

        protected override IQueryable<Employee> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAll().Include(p => p.ProjectEmployees).ThenInclude(x => x.Project)
                 .Include(p => p.EmployeeSkills).ThenInclude(x => x.Skill)
                 .Include(p => p.JobTitle);
        }

        public override EmployeeDto Get(EntityDto<int> input)
        {
            int id = input.Id;

            Employee employee = Repository.Get(id);
            IQueryable<ProjectEmployee> projectEmployees = _projectEmployeeRepository.GetAll().Where(p => p.EmployeeId == id); //.Select(k => k.ProjectId.Value).ToList();
            List<Project> projects = _projectRepository.GetAll().Where(p => projectEmployees.Any(pem => p.Id == pem.ProjectId)).ToList();

            IQueryable<EmployeeSkill> employeeSkills = _employeeSkillRepository.GetAll().Where(p => p.EmployeeId == id); 
            List<Skill> skills = _skillRepository.GetAll().Where(p => employeeSkills.Any(emplskill => p.Id == emplskill.SkillId)).ToList();

            EmployeeDto employeeDto = ObjectMapper.Map<EmployeeDto>(employee);
            employeeDto.Projects = projects;
            employeeDto.Skills = skills;
            return employeeDto;
        }
    }
}
