﻿using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ShopContext _context;
        public ProductsController(ShopContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = _context.Products.ToArray();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id) 
        {
            var product = _context.Products.Find(id);
            if(product ==null)
                return NotFound();
            return Ok(product);
        }

    }
}
