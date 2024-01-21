using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using piAssignment.Interface;
using piAssignment.Models;

namespace piAssignment.Controllers
{
    [ApiController]
    [Route("api/User")]
    //[Authorize] // Open this to use Authentication
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetUserInformationById")]
        public async Task<IActionResult> GetUserInformationById(int id)
        {
            try
            {
                UserInfoResultsByIdModel results = new UserInfoResultsByIdModel();

                // Fetch user information from DB
                var list = await _userRepository.GetUserInformationById(id);
                if (list != null)
                {
                    results.status = true;
                    results.results = list;
                }
                else
                {
                    results.status = false;
                    results.results = null;
                }

                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserInfoRequestModel newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest("Invalid user data.");
                }

                var results = await _userRepository.CreateUser(newUser);
                if (!results)
                {
                    return BadRequest("Create User not successful");
                }

                return Ok("Create User successful");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // HttpPut to update user information
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInfoRequestModel updateUser)
        {
            try
            {
                if(updateUser == null)
                {
                    return BadRequest("Invalid user data.");
                }

                var results = await _userRepository.UpdateUser(id, updateUser);
                if (!results)
                {
                    return BadRequest("Update or Create user not successful");
                }

                return Ok("Update or Create user successful");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("GetUserInformationByName")]
        public async Task<IActionResult> GetUserInformationByName(string userName)
        {
            try
            {
                UserInfoResultsByNameModel results = new UserInfoResultsByNameModel();

                // Fetch user information from DB
                var list = await _userRepository.GetUserInformationByName(userName);
                if (list != null)
                {
                    results.status = true;
                    results.results = list;
                }
                else
                {
                    results.status = false;
                    results.results = null;
                }

                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

