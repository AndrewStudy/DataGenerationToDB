using Bogus;
using DataBase.Entities;

namespace DataGenerate
{
    public class ProductFaker
    {
        public IQueryable<Product> StubProducts { get; private set; }

        public ProductFaker(int countFakes)
        {
            var data = GenerateData(countFakes);
            StubProducts = data.AsQueryable();
        }

        private List<Product> GenerateData(int countFakes)
        {
            var faker = new Faker<Product>()
                .RuleFor(c => c.Title, f => f.Company.CompanyName())
                .RuleFor(c => c.Description, f => f.Lorem.Letter(50))
                .RuleFor(c => c.Price, f => f.Random.Decimal(200,999))
                .RuleFor(c => c.Id, Guid.NewGuid);

            return faker.Generate(countFakes);
        }
    }
}
