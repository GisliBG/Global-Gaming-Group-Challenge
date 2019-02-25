using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Book
{
	public class Book
	{
		public Guid id { get; set; }
		[Required]
		public string ISBN { get; set; }
		[Required]
		public string Title { get; set; }
		public string Author { get; set; }
		public string Language { get; set; }
		public string Pages { get; set; }
		[Required]
		[Range(0, int.MaxValue)]
		public int Price { get; set; }
		[Required]
		[Range(0, int.MaxValue)]
		public int InStock { get; set; }
	}
}
