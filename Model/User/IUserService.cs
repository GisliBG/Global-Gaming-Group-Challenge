using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
	public interface IUserService
	{
		User CreateUser(User user);
		void RemoveUser(User user);
		User GetUser(Guid userId);
		void UpdateUser(User user);
		Purchase.Purchase Purchase(List<PurchaseItem> purchaseItems, Guid userId);
		List<Purchase.Purchase> GetPurchases(Guid userId);
	}
}
