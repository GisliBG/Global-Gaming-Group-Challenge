using Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public class UserRepository : IUserRepository
	{
		DataAccess db;
		public UserRepository()
		{
			db = new DataAccess();
		}

		public User AddUser(User user)
		{
			try
			{
				string sql = "INSERT INTO USERS (id, EMAIL, Password, FIRST_NAME, LAST_NAME, ADDRESS, PHONE) VALUES ('";
				sql += user.Id.ToByteArray() + "', '" + user.Email + "', '" + user.Password + "', '" + user.FirstName + "', '" + user.LastName + "', '" + user.Address + "', '" + user.Phone + "')";
				db.Insert(sql);
				return user;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
