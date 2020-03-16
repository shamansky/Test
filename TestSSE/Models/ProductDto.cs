using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestSSE.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
   // [HttpPost]
   // public IActionResult CreateProduct(int productId, [FromBody] ProductCreation product)
    //{
        
    //}
}
