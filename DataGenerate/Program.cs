using DataBase.Data;
using DataBase.Entities;

namespace DataGenerate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (Employees, Clients, Products) = InitializationAsync(
                countClients: 100,
                countEmployees:10,
                countProducts: 800).Result;

            Print(Employees);
            Print(Clients);
            Print(Products);

            Console.ReadLine();
        } 
        
        private static async Task<(
            IQueryable<Employee>? Employees,
            IQueryable<Client>? Clients, 
            IQueryable<Product>? Products)> 
        InitializationAsync(int countEmployees, int countClients, int countProducts)
        {
            EmployeeFaker employeeFaker = new EmployeeFaker(countEmployees);
            ClientFaker clientFaker = new ClientFaker(countClients);
            ProductFaker productFaker = new ProductFaker(countProducts);

            using(var _context = new GeneralDbContext())
            {
                try
                {
                    await _context.Clients.AddRangeAsync(clientFaker.StubClients);
                    await _context.Products.AddRangeAsync(productFaker.StubProducts);
                    await _context.Employees.AddRangeAsync(employeeFaker.StubEmployees);
                }
                catch
                {
                    return (null, null, null);
                }

                await _context.SaveChangesAsync();
                return (employeeFaker.StubEmployees, clientFaker.StubClients, productFaker.StubProducts);
            }
        }

        private static void Print(IQueryable<Employee>? employees)
        {
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine($"ID:{employee.Id}| {employee.FullName} - {employee.Age} age | Post: {employee.JobTitle}");
                }
            }
            else
            {
                Console.WriteLine("Employees not found!");
            }
        }

        private static void Print(IQueryable<Client>? clients)
        {
            if (clients != null)
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"ID:{client.Id}| {client.FullName} - {client.Age} age;");
                }
            }
            else
            {
                Console.WriteLine("Clients not found!");
            }
        }

        private static void Print(IQueryable<Product>? products)
        {
            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"ID:{product.Id}| {product.Title} > {product.Description} | Price: {product.Price}");
                }
            }
            else
            {
                Console.WriteLine("Products not found!");
            }
        }
    }
}
