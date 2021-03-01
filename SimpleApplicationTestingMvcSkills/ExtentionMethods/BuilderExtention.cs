using Microsoft.EntityFrameworkCore;
using SimpleApplicationTestingMvcSkills.Models;
using System.Collections.Generic;

namespace SimpleApplicationTestingMvcSkills.ExtentionMethods
{
    public static class BuilderExtention
    {
        public static void SeedDatabaseWithInitialData(this ModelBuilder model)
        {
            model.Entity<Employee>((builder) =>
            {
                builder.HasData(GetEmployees());
            });
        }

        private static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    Name = "iamtuse",
                    Email = "iamtuseTheProgrammer@iamtuse.com",
                    Department = HelperEnum.Department.IT
                },
                 new Employee
                {
                    ID = 2,
                    Name = "Precious K Wonkulah",
                    Email = "wonkulahp@iamtuse.com",
                    Department = HelperEnum.Department.Mgt
                },
                  new Employee
                {
                    ID = 3,
                    Name = "Darious F Wonkulah",
                    Email = "darious@iamtuse.com",
                    Department = HelperEnum.Department.Finance
                },
                   new Employee
                {
                    ID = 4,
                    Name = "Dacious F Wonkulah",
                    Email = "dacious@iamtuse.com",
                    Department = HelperEnum.Department.HR
                },
                    new Employee
                {
                    ID = 5,
                    Name = "Dad S Wonkulah Sr",
                    Email = "dad@iamtuse.com",
                    Department = HelperEnum.Department.Mgt
                }
            };

        }
    }
}
