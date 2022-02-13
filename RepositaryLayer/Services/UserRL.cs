namespace RepositaryLayer.Services
{
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
    public class UserRL: IUserRL
    {
        private readonly Context context;
        private readonly IConfiguration Iconfiguration;
        /// <summary>
        /// constructor to pass context and configuration 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Iconfiguration"></param>
        public UserRL(Context context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }
        /// <summary>
        /// Registration method to register new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserEntity Registration(UserRegistration user)
        {
            try
            {
                UserEntity users = new UserEntity();
                users.FirstName = user.Firstname;
                users.LastName = user.Lastname;
                users.Email = user.Email;
                users.CreatedAt = user.Createat;
                users.ModifiedAt = user.Modifiedat;
                users.Password = EncryptPass(user.Password);
                this.context.Users.Add(users);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return users;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EncryptPass(string password)
        {
            try
            {
                string msg = "";
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                msg = Convert.ToBase64String(encode);
                return msg;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Decrpt(string encodedData)
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Login method to log in with user email and password
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public string Login(UserLogin userLogin)
        {
            try
            {
                UserEntity user = new UserEntity();
                user = this.context.Users.FirstOrDefault(x => x.Email == userLogin.Email);
                string dPass = Decrpt(user.Password);
                var id = user.Id;
                if (dPass == userLogin.Password && user != null)
                {
                    var token = this.TokenBTID(id);
                    return token;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //public string GenerateJWTToken(string Emailid)
        //{
        //    try
        //    {
        //        var loginTokenHandler = new JwtSecurityTokenHandler();
        //        var loginTokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.Iconfiguration[("Jwt:key")]));
        //        var loginTokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim(ClaimTypes.Email, Emailid),
        //            }),
        //            Expires = DateTime.UtcNow.AddMinutes(50),
        //            SigningCredentials = new SigningCredentials(loginTokenKey, SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var token = loginTokenHandler.CreateToken(loginTokenDescriptor);
        //        return loginTokenHandler.WriteToken(token);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
        /// <summary>
        /// Generate JWT token by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GenerateJWTToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Iconfiguration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Email", email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Generate token by User id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string TokenBTID(long userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Iconfiguration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Id", userid.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Method for forget password -sending token to mail using msmq
        /// </summary>
        /// <param name="Emailid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Reseting password after authroization of token 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="confirmpassword"></param>
        /// <returns></returns>
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
