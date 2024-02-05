using Bogus;
using DataBase.Data;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DataGenerate
{
    public class EmployeeFaker
    {
        public IQueryable<Employee> StubEmployees { get; private set; }

        public EmployeeFaker(int countFakes)
        {
            var data = GenerateData(countFakes);
            StubEmployees = data.AsQueryable();
        }

        private List<Employee> GenerateData(int countFakes)
        {
            var faker = new Faker<Employee>()
                .RuleFor(c => c.FullName, f => f.Person.LastName)
                .RuleFor(c => c.Age, f => f.Random.Int(18,50))
                .RuleFor(c => c.JobTitle, f => f.PickRandom("Бухгалтер", "Начальник отдела","Кладовщик","Прораб"))
                .RuleFor(c => c.Id, Guid.NewGuid);

            return faker.Generate(countFakes);
        }
    }
}
