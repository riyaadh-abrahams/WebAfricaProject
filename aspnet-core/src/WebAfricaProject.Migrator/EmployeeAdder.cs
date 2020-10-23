using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using Abp.Data;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using WebAfricaProject.Entities;
using WebAfricaProject.EntityFrameworkCore;
using WebAfricaProject.EntityFrameworkCore.Seed;
using WebAfricaProject.MultiTenancy;

namespace WebAfricaProject.ConsoleApp
{
    public class EmployeeAdder : ITransientDependency
    {
        private readonly Log _log;
        private readonly AbpZeroDbMigrator _migrator;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<JobTitle> _jobtitleRepository;
        private readonly IDbPerTenantConnectionStringResolver _connectionStringResolver;

        public EmployeeAdder(
            AbpZeroDbMigrator migrator,
            IRepository<Tenant> tenantRepository,
            IRepository<Employee> employeeRepository,
            IRepository<JobTitle> jobTitleRepository,
            Log log,
            IDbPerTenantConnectionStringResolver connectionStringResolver)
        {
            _log = log;

            _migrator = migrator;
            _tenantRepository = tenantRepository;
            _employeeRepository = employeeRepository;
            _jobtitleRepository = jobTitleRepository;
            _connectionStringResolver = connectionStringResolver;
        }

        public bool Run(bool skipConnVerification)
        {
            var hostConnStr = CensorConnectionString(_connectionStringResolver.GetNameOrConnectionString(new ConnectionStringResolveArgs(MultiTenancySides.Host)));
            if (hostConnStr.IsNullOrWhiteSpace())
            {
                _log.Write("Configuration file should contain a connection string named 'Default'");
                return false;
            }

            Console.WriteLine("Current Employees");
            _employeeRepository.GetAllList().ForEach(employee => Console.WriteLine(employee.Name + " "+ employee.Surname));

            Console.WriteLine("\n\nLets Create an Employee\n\n");

            

            try
            {
                Console.WriteLine("Please enter an employee name");
                string employeeName = Console.ReadLine();

                Console.WriteLine("Please enter their surname");
                string employeeSurname = Console.ReadLine();

                Console.WriteLine("Please enter their date of birth (dd/MM/yyyy)");
                string employeeDOBString = Console.ReadLine();
                DateTime employeeDOB;
                try
                {
                    employeeDOB = DateTime.ParseExact(employeeDOBString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                    throw;
                }

                Console.WriteLine("What is their job title?");
                string employeeJobTitle = Console.ReadLine();
                JobTitle job = _jobtitleRepository.FirstOrDefault(x => x.JobTitleLabel == employeeJobTitle);

                Employee newEmployee = new Employee(employeeName, employeeSurname, job.Id, employeeDOB);
                _employeeRepository.InsertOrUpdate(newEmployee);

            }
            catch (Exception ex)
            {

            }

            _log.Write("Employee Has been added. Thank you");
            _log.Write("--------------------------------------------------------");

            return true;
        }

        private static string CensorConnectionString(string connectionString)
        {
            var builder = new DbConnectionStringBuilder { ConnectionString = connectionString };
            var keysToMask = new[] { "password", "pwd", "user id", "uid" };

            foreach (var key in keysToMask)
            {
                if (builder.ContainsKey(key))
                {
                    builder[key] = "*****";
                }
            }

            return builder.ToString();
        }
    }
}
