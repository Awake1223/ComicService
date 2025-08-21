using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using TemplateService.API.Contracts;
using TemplateService.Application.Services;
using TemplateService.Domain.Models;
using TemplateService.Infrastructure.Reposotories;

namespace TemplateService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var response = users.Select(u => new UserResponse(u.Id, u.Username, u.Email));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
        {
            (UserModel? userModel, string error) = UserModel.Create(
                Guid.NewGuid(),
                request.Username,
                request.Email,
                request.PasswordHash);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _userService.CreateUser(userModel);

            return Ok(userModel);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UserRequest request)
        {
            var userId = await _userService.UpdateUser(id, request.Username, request.Email);
            return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            var user = await _userService.DeleteUser(id);
            return Ok(user);
        }
    }
}
