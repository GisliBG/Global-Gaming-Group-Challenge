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
	}
}
