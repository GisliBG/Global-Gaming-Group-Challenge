using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Purchase
{
	public class Purchase
	{
		public Guid Id { get; set; }
		public List<PurchaseItem> purchaseItems { get; set; }
	}
}
