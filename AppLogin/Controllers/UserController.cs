﻿using AppLogin.DTOs;
using AppLogin.DTOs.Excel;
using AppLogin.Repos;
using AppLogin.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Crypto;

namespace AppLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userrepo;
        public UserController(IUser userrepo)
        {
            this.userrepo = userrepo;
        }

        [HttpGet("GetUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsers()
        {
            List<UserDTO> dtos;
            try
            {
                dtos = await userrepo.GetUsersAsync();
                var response = new ApiResponse<List<UserDTO>> { Mensaje = "ok", Response = dtos };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<UserDTO>> { Mensaje = ex.Message, Response = null };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse); ;
            }
        }

        [HttpPut("UpdateUsers")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdateUser(UserDTO user)
        {
            try
            {
                await userrepo.UpdateUserAsync(user);
                var response = new ApiResponse<List<UserDTO>> { Mensaje = "ok", Response = null };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<UserDTO>> { Mensaje = ex.Message, Response = null };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("DeleteUsers")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteUserAsync(UserDTO user)
        {
            try
            {
                await userrepo.DeleteUserAsync(user);
                var response = new ApiResponse<List<UserDTO>> { Mensaje = "ok", Response = null };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<List<UserDTO>> { Mensaje = ex.Message, Response = null };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }


}