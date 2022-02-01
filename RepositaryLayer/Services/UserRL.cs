using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositaryLayer.AppContext;
using RepositaryLayer.Entities;
using RepositaryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositaryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly Context context;
		private readonly IConfiguration Iconfiguration;
        public UserRL(Context context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }
        public bool Registration(UserRegistration user)
        {
            try
            {
                UserEntity users = new UserEntity();
                users.FirstName = user.Firstname;
                users.LastName = user.Lastname;
                users.Email = user.Email;
                users.Password = user.Password;
                this.context.Users.Add(users);
                int result = this.context.SaveChanges();
                if(result>0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(UserLogin userLogin)
        {
            try
            {
                var result = this.context.Users.FirstOrDefault(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
                if (result != null)
                {
                    var token = this.GenerateJWTToken(userLogin.Email);
                    return token;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GenerateJWTToken(string Emailid)
        {
            try
            {
                var loginTokenHandler = new JwtSecurityTokenHandler();
                var loginTokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.Iconfiguration[("Jwt:key")]));
                var loginTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, Emailid),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(loginTokenKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = loginTokenHandler.CreateToken(loginTokenDescriptor);
                return loginTokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public string ForgetPassword(string Emailid)
        {
            try
            {
                var result = this.context.Users.FirstOrDefault(x => x.Email == Emailid);
                if (result != null)
                {
                    var token = this.GenerateJWTToken(Emailid);
                    new MSMQ().sendmsg(token);
                    return token;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ResetPassword(string email, string password, string confirmpassword)
        {
            try
            {
                if (password.Equals(confirmpassword))
                {
                    UserEntity user = context.Users.Where(e => e.Email == email).FirstOrDefault();
                    user.Password = confirmpassword;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
