using Core.DTOs.UserDTO;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; set; }
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            UserService = userService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromForm] UserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest("Model is invalid");
            await UserService.Create(user);
            _logger.LogInformation("User was successfully created!");
            return Ok(); // also can return all table
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put([FromBody] UserDTO user)
        {
            await UserService.Edit(user);
            _logger.LogInformation("User was successfully updated!");
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(string id)
        {
            await UserService.Delete(id);
            _logger.LogInformation($"Successfully delete user with id {id}");
            return Ok();
        }

        [HttpGet]
        [ResponseCache(Duration = 30)]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return Ok(await UserService.Get());
        }

        [HttpGet("{id:int}")] // maybe need change to string :)
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserDTO>> Get(string id)
        {
            var author = await UserService.GetUserById(id);
            _logger.LogInformation($"Got a author with id {id}");
            return author;
        }

    }
}
