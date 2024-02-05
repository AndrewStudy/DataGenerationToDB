﻿namespace DataBase.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
