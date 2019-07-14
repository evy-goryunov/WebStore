using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;

namespace WebStore.Infrastructure.Interfaces
{
	public interface IProductService
	{
		IEnumerable<Section> GetSections();
		IEnumerable<Brand> GetBrands();
		IEnumerable<Product> GetProducts(ProductFilter filter);
	}
}
