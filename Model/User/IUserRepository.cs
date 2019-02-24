using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
	public interface IUserRepository
	{
		User AddUser(User user);
	}
}
