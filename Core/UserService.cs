using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Book;
using Model.Purchase;
using Model.User;

namespace Core
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IBookRepository _bookRepository;

		public UserService(IUserRepository userRepository, IBookRepository bookRepository)
		{
			_userRepository = userRepository;
			_bookRepository = bookRepository;
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

		public List<Purchase> GetPurchases(Guid userId)
		{
			try
			{
				return _userRepository.GetPurchases(userId);	
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

		public Purchase Purchase(List<PurchaseItem> purchaseItems, Guid userId)
		{
			try
			{
				Purchase purchase = new Purchase() { Id = Guid.NewGuid(), purchaseItems = purchaseItems};
				var books = _bookRepository.GetAll();
				foreach(PurchaseItem purchaseItem in purchase.purchaseItems)
				{
					purchaseItem.Id = purchase.Id;
					purchaseItem.Book = books.Find(book => book.id == purchaseItem.Book.id);
				}
				_userRepository.PurchaseBooks(purchase, userId);
				
				return purchase;
			}
			catch (Exception ex)
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
