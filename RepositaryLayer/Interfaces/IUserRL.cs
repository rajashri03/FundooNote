namespace RepositaryLayer.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using CommonLayer.Model;
	using RepositaryLayer.Entities;
	/// <summary>
	/// Interface for Fundoo users-only Method calling should be here.
	/// </summary>
	public interface IUserRL
	{
		public UserEntity Registration(UserRegistration user);
		public string Login(UserLogin userlogin);
		public string GenerateJWTToken(string Emailid);
		public string ForgetPassword(string Emailid);
		public bool ResetPassword(string email, string password, string confirmpassword);
	}
}
