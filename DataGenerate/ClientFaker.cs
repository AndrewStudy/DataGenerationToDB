using Bogus;
using DataBase.Entities;

namespace DataGenerate
{
    public class ClientFaker
    {
        public IQueryable<Client> StubClients { get; private set; }

        public ClientFaker(int countFakes)
        {
            var data = GenerateData(countFakes);
            StubClients = data.AsQueryable();
        }

        private List<Client> GenerateData(int countFakes)
        {
            var faker = new Faker<Client>()
                .RuleFor(c => c.FullName, f => f.Person.FullName)
                .RuleFor(c => c.Age, f => f.Random.Int(18,50))
                .RuleFor(c => c.Id, Guid.NewGuid);

            return faker.Generate(countFakes);
        }
    }
}
