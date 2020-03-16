using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSSE.Models;

namespace TestSSE
{
    public class ProductsDataStore
    {

        public static ProductsDataStore Current { get; } = new ProductsDataStore();
        public List<ProductDto> Products { get; set; }
        

        public ProductsDataStore()
        {
            Products = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Lavender heart",
                    Price = "9.25"
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Personalised cufflinks",
                    Price = "45.00"
                },
                new ProductDto()
                {
                    Id = 3,
                    Name = "Kids T-shirt",
                    Price = "19.95"
                }
            };
        }
    }
}
