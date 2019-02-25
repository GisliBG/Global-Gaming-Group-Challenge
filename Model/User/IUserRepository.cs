using System;
using System.Collections.Generic;
using System.Text;
using Model.Purchase;

namespace Model.User
{
	public interface IUserRepository
	{
		User AddUser(User user);
		void Remove(Guid id);
		User GetUser(Guid id);
		void Update(User user);
		void PurchaseBooks(Purchase.Purchase purchase, Guid userId);
	}
}
