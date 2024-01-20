﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            Thread.Sleep(1000);

            var result = _productService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetByID(id);
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getproductdetails")]
        public IActionResult GetByProductDetails()
        {
            var result = _productService.GetProductDetails();
            if (result.IsSuccess) { return Ok(result); }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product) 
        {
            var result = _productService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
