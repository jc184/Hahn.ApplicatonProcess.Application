using Hahn.ApplicatonProcess.July2021.Web.DTOs.Users;
using Hahn.ApplicatonProcess.July2021.Web.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Constructor for User Controller
        /// </summary>
        public UserController(ILogger<UserController> logger
            , UserService service)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a specific user by email
        /// </summary>
        /// <response code="200">User retrieved</response>
        [HttpGet("user")]
        public async Task<IActionResult> Get([FromQuery] GetUserRequest request)
        {
            var users = await _service.SearchAsync(request);
            return Ok(users);
        }

        /// <summary>
        /// Retrieves all users
        /// </summary>
        /// <response code="200">Users retrieved</response>
        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <response code="201">Users added</response>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            var users = await _service.AddNewAsync(request);
            return Ok(users);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <response code="204">User deleted</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var users = await _service.DeleteAsync(request);
            return Ok(users);
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <response code="200">User updated</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, int Id)
        {
            var users = await _service.UpdateAsync(request, Id);
            return Ok(users);
        }
    }
}
