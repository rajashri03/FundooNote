using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Model;

namespace RepositaryLayer.Interfaces
{
	/// <summary>
	/// Interface for Fundoo users-only Method calling should be here.
	/// </summary>
	public interface IUserRL
	{
		public bool Registration(UserRegistration user);
		public string Login(UserLogin userlogin);
		public string GenerateJWTToken(string Emailid);
		public string ForgetPassword(string Emailid);
		public bool ResetPassword(string email, string password, string confirmpassword);
	}
}
