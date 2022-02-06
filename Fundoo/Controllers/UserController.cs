using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositaryLayer.Entities;

namespace Fundoo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;

        }
        [HttpPost]
        public IActionResult AddUser(UserRegistration userRegistration)
        {
            try
            {
                if (userBL.Registration(userRegistration))

                {
                    return this.Ok(new { Success = true, message = "Registration Sucessfull" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration Unsucessfull" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        //[Authorize]
        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            try
            {
                string tokenString = userBL.Login(login);
                if (tokenString != null)
                {
                    return Ok(new {Success = true, message = "login Sucessfull", Data = tokenString });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "login Unsucessfull" });
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        [HttpPost]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                string token = userBL.ForgetPassword(email);
                if (token != null)
                {
                    return Ok(new { success=true,Message = "Please check your Email.Token sent succesfully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, Message = "Email not registered" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            try
            {
                var email = User.Claims.First(e => e.Type == "Email").Value;
                if (userBL.ResetPassword(email, password, confirmPassword))
                {
                    return this.Ok(new { Success = true, message = "Your password has been changed sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to reset password.Please try again" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
