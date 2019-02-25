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

		public User GetUser(Guid userId)
		{
			try
			{
				var user = _userRepository.GetUser(userId);
				user.Password = null;
				return user;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void RemoveUser(User user)
		{
			try
			{
				var validUser = _userRepository.GetUser(user.Id);
				if(validUser.Password == user.Password && validUser.Email == user.Email)
				{
					_userRepository.Remove(user.Id);
				}
				else
				{
					throw new Exception("Invalid user credentials");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void UpdateUser(User user)
		{
			try
			{
				_userRepository.Update(user);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
