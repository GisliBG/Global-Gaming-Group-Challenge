﻿using Model.Purchase;
using Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.CoreTests
{
	public class MockUserRepository : IUserRepository
	{
		public User AddUser(User user)
		{
			return user;
		}

		public List<Purchase> GetPurchases(Guid userId)
		{
			throw new NotImplementedException();
		}

		public User GetUser(Guid id)
		{
			throw new NotImplementedException();
		}

		public void PurchaseBooks(Purchase purchase, Guid userId)
		{
			throw new NotImplementedException();
		}

		public void Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public void Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
