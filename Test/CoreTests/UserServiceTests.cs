﻿using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Book;
using Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.CoreTests
{
	[TestClass]
	public class UserServiceTests
	{
		private IUserRepository _userRepository;
		private IBookRepository _bookrepository;
		private IUserService _userService;

		[TestInitialize]
		public void Setup()
		{
			_userRepository = new MockUserRepository();
			_bookrepository = new MockBookRepository();
			_userService = new UserService(_userRepository, _bookrepository);
		}

		[TestMethod]
		public void CreateUser_WithValidCredentials()
		{
			// Arrange
			var user = new User()
			{
				Email = "test",
				Password = "password",
				FirstName = "john",
				LastName = "Doe",
				Address = "home"
			};

			// Act
			var result = _userService.CreateUser(user);

			// Assert
			Assert.IsInstanceOfType(result, typeof(User));
			Assert.AreNotEqual(null, user.Id);

		}
	}
}
