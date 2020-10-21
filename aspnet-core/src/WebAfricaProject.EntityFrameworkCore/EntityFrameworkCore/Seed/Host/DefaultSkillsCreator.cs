using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore.Seed.Host
{
    public class DefaultSkillsCreator
    {
        public static List<Skill> InitialLanguages => GetInitialSkills();

        private readonly WebAfricaProjectDbContext _context;

        private static List<Skill> GetInitialSkills()
        {

            return new List<Skill>
            {
                new Skill("Angular"),
                new Skill("Django"),
                new Skill("ASP .NET"),
                new Skill("Python"),
                new Skill("C#"),
                new Skill("PostgreSQL"),
                new Skill("Javascript"),
                new Skill("Java"),
                new Skill("Email")
            };
        }

        public DefaultSkillsCreator(WebAfricaProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateSkills();
        }

        private void CreateSkills()
        {
            foreach (Skill skill in InitialLanguages)
            {
                AddSkillIfNotExists(skill);
            }
        }

        private void AddSkillIfNotExists(Skill skill)
        {
            if (_context.Skill.IgnoreQueryFilters().Any(l => l.Name == skill.Name))
            {
                return;
            }

            _context.Skill.Add(skill);
            _context.SaveChanges();
        }
    }
}
