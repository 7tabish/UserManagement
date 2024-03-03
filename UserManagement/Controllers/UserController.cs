using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service;

    
namespace OA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ILogger _logger;
        public UserController(IUserService userService)
        {
            _userService = userService;
  
        }

        [HttpPost("/Add")]
        public ActionResult AddUser([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int userID = _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserByID), new { id = userID }, new {status = true});
        }

        [HttpGet("/getUsers")]
        public ActionResult<List<UserOutputDTO>> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpGet("/getUser")]
        public ActionResult<UserOutputDTO> GetUserByID(int ID)
        {
            var resource = _userService.GetUserById(ID);
            if (resource==null)
            {
                return NotFound(new { error = new { message = "Resource not found" } });
            }
            return Ok(resource);
        }

        [HttpDelete("/Delete")]
        public ActionResult DeleteUser(int ID)
        {
            try
            {
                if (_userService.DeleteUser(ID))
                {
                    return NoContent(); // 204 No Content on successful deletion
                }
                else { return NotFound(new { error = new { message = "Resource not found" } }); }
          
            }
            catch(Exception ex) { return StatusCode(500, "Internal Server Error"); }
            
        }

        [HttpPut("/Update")]
        public ActionResult UpdateUser(int userID, [FromBody] UserDTO user)
        {
            var updatedResoure = _userService.UpdateUser(userID, user);

            if (updatedResoure != null)
            {
                return Ok(new { message = "Resource updated successfully", data = updatedResoure });
            }
            else
            {
                return NotFound(new { error = new { message = "Resource not found" } });
            }
        }

    }
}
