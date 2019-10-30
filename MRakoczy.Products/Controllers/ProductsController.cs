﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRakoczy.Application.Controllers.Resources;
using MRakoczy.Application.Models;
using MRakoczy.Application.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MRakoczy.Application.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Display products list
        /// </summary>
        /// <returns>List of products</returns>
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> List()
        {
            var products =  await _context.Products.ToListAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Product data</returns>
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        /// <summary>
        /// Update product data
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="product">Product object</param>
        /// <returns>Update confirmation</returns>
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Update product data
        /// </summary>
        /// <param name="productDto">Product object</param>
        /// <returns>New product object</returns>
        // POST: api/Products

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Product, ProductDto>(product);

            return Ok(result);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Delete confirmation</returns>
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> RemoveProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
