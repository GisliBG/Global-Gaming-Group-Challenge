using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
	public interface IUserRepository
	{
		User AddUser(User user);
		void Remove(Guid id);
		User GetUser(Guid id);
	}
}
