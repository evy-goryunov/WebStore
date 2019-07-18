using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
	[Table(name:"Products")]
	public class Product : NamedEntity, IOrderedEntity
	{
		public int Order { get; set; }
		public int SectionId { get; set; }
		public int? BrandId { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		[ForeignKey(name: "SectionId")]
		public virtual Section Section { get; set; }
		[ForeignKey(name: "BrandId")]
		public virtual Brand Brand { get; set; }
	}
}