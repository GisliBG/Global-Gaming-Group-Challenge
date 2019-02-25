using System;
using System.Collections.Generic;
using System.Text;
using Model.Book;

namespace Model.Purchase
{
	public class PurchaseItem
	{
		public Guid Id { get; set; }
		public Book.Book Book { get; set; }
		public int Quantity { get; set; }
	}
}
