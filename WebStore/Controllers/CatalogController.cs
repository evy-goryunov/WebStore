﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Filters;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStore.Controllers
{
	public class CatalogController : Controller
	{
		private readonly IProductService _productService;

		public CatalogController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Shop(int? sectionId, int? brandId)
		{
			var products = _productService.GetProducts(
				new ProductFilter() { SectionId = sectionId, BrandId = brandId });

			// сконвертируем в CatalogViewModel
			var model = new CatalogViewModel()
			{
				BrandId = brandId,
				SectionId = sectionId,
				Products = products.Select(p => new ProductViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					Order = p.Order,
					Price = p.Price
				}).OrderBy(p => p.Order).ToList()
			};

			return View(model);
		}

		public IActionResult ProductDetails()
		{
			return View();
		}
	}
}
