using System;
using System.Collections.Generic;
using System.Text;
using Model.User;

namespace Core
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User CreateUser(User user)
		{
			user.Id = Guid.NewGuid();
			try
			{
				user = _userRepository.AddUser(user);
				user.Password = null;
				return user;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
