using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositaryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL iuserrl;
        /// <summary>
        /// Inititalizing the instanse of UserBL class
        /// </summary>
        /// <param name="iuserrl"></param>
        public UserBL(IUserRL iuserrl)
        {
            this.iuserrl = iuserrl;
        }
        /// <summary>
        ///Registration model to register user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.iuserrl.Registration(user);
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
                return iuserrl.Login(userLogin);
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
                return iuserrl.GenerateJWTToken(Emailid);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public string ForgetPassword(string Emailid)
        {
            try
            {
                return iuserrl.ForgetPassword(Emailid);
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
                return iuserrl.ResetPassword(email, password, confirmpassword);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
