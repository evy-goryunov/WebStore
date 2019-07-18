using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
	public class SqlProductService : IProductService
	{
		private readonly WebStoreContext _context;
		public SqlProductService(WebStoreContext context)
		{
			_context = context;
		}
		public IEnumerable<Brand> GetBrands()
		{
			return _context.Brands.ToList();
		}

		public IEnumerable<Product> GetProducts(ProductFilter filter)
		{
			var products = _context.Products.AsQueryable();

			if (filter.SectionId.HasValue)
				products = products.Where(x => x.SectionId == filter.SectionId.Value);
			if (filter.BrandId.HasValue)
				products = products.Where(x => x.BrandId == filter.BrandId.Value);

			return products.ToList();
		}

		public IEnumerable<Section> GetSections()
		{
			return _context.Sections.ToList();
		}
	}
}
