﻿using System.ComponentModel;

namespace ProductCatalogService
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
    }
}
