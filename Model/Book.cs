using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public class Book
	{
		public Guid id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Language { get; set; }
		public string Pages { get; set; }
	}
}
