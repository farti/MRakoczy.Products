﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MRakoczy.Application.Interfaces;
using MRakoczy.Application.Models.Domain;
using MRakoczy.Application.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MRakoczy.Application.Models.Validator;

namespace MRakoczy.Application.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductValidator _productValidator;

        public ProductsController(IMapper mapper, IProductRepository repository, IUnitOfWork unitOfWork, ProductValidator _productValidator)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
            this._productValidator = _productValidator;
        }
        /// <summary>
        /// Display products list
        /// </summary>
        /// <returns>List of products</returns>
        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _repository.List();

            return Ok(_mapper.Map<List<Product>, List<ProductDto>>(products));
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Product data</returns>
        // GET: api/Products/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> GetProductById([FromQuery]Guid id)
        {
            var product = await _repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<Product, ProductDto>(product);
            await _unitOfWork.CompleteAsync();

            return Ok(productDto);
        }
        /// <summary>
        /// Update product data
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="productDto">Product object</param>
        /// <returns>Update confirmation</returns>
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _repository.GetProductById(id);

            if (product == null)
                return NotFound();

            _mapper.Map<ProductDto, Product>(productDto, product);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Product, ProductDto>(product);

            return Ok(result);
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
            var validation = _productValidator.Validate(productDto);
            if (validation.IsValid == false)
            {
                foreach (var error in validation.Errors)
                {
                    Console.WriteLine("{0}: {1}", error.PropertyName, error.ErrorMessage);
                    return BadRequest();
                }
            }

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var product = _mapper.Map<ProductDto, Product>(productDto);
            _repository.AddProduct(product);

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Product, ProductDto>(product);

            return Ok(result.Id);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Delete confirmation</returns>
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            var product = await _repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            _repository.RemoveProduct(product);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
