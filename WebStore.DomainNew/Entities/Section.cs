using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
	[Table(name:"Sections")]
	public class Section : NamedEntity, IOrderedEntity
	{
		/// <summary>
		/// Родительская секция (при наличии)
		/// </summary>
		public int? ParentId { get; set; }
		public int Order { get; set; }
		public virtual ICollection<Product> Products { get; set; }
		[ForeignKey(name: "ParentId")]
		public virtual Section ParentSection { get; set; }
	}
}
