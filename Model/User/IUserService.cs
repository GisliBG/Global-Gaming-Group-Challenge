using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
	public interface IUserService
	{
		User CreateUser(User user);
		void RemoveUser(User user);
	}
}
