using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_GroceryStoreWebApi.DataAccess;
using E_GroceryStoreWebApi.Models;
using Microsoft.AspNetCore.Authentication;
using log4net;
using Microsoft.AspNetCore.Authentication.Cookies;
using E_GroceryStoreWebApi.Core.Interface;

namespace E_GroceryStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUser _context;
        public UserController(IUser _context)
        {

            this._context = _context;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(String Email, string Password)
        {
            try
            {
                var userList = await _context.Login(Email, Password);
                if (userList == null)
                {
                    log.Error("Error occur");
                    return BadRequest("Invalid Credentials");
                }

                return Ok("Sign In Successful");
            }
            catch (Exception ex)
            {
                log.Error("Error occur");
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                log.Info("items are displayed");
                return Ok(await _context.GetUsers());
            }
            catch (Exception)
            {
                log.Error("Error occured");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data- from the Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            try
            {
                var result = await _context.GetUser(id);
                if (result == null)
                {
                    log.Error("No Data");
                    return NotFound("No Data");
                }
                return result;
            }
            catch (Exception)
            {
                log.Error("Error Occured");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserModel>> AddUser(UserModel userModel)
        {
            try
            {
                if (userModel == null)
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
                var addUser = await _context.AddUser(userModel);
                log.Info("Created Successfully");
                return CreatedAtAction(nameof(GetUsers), new { id = addUser.UserId }, addUser);
            }
            catch (Exception)
            {
                log.Error("Error Occured");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, UserModel userModel)
        {
            try
            {
                if (id != userModel.UserId)
                {
                    log.Error("Mismatch Id");
                    return BadRequest("Mismatch UserId");
                }
                var updateUser = await _context.GetUser(id);
                if (updateUser == null)
                {
                    log.Error("Id Not Found");
                    return NotFound($"User with Id={id} not Found");
                }
                log.Info("Update SuccessFul");
                return await _context.UpdateUser(userModel);
            }
            catch (Exception)
            {
                log.Error("Error Occured");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var deleteUser = await _context.GetUser(id);
                if (deleteUser == null)
                {
                    log.Error("Id Not Found");
                    return NotFound($"User with Id={id} not Found");
                }
                await _context.DeleteUser(id);
                log.Info("Deleted Successfully");
                return Ok($"User with Id={id} is Deleted");
            }
            catch (Exception)
            {
                log.Error("Error Occured");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
    }
}
