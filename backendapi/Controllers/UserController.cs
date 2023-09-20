using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendapi.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserFormModel userForm)
        {
            _logger.LogInformation($"LOG INFO. username: {userForm.FirstName} and lastname {userForm.LastName}");
            //_logger.LogInformation($"Header: {HttpContext.User}");
            Console.WriteLine($"First Name: {userForm.FirstName}");
            Console.WriteLine($"Last Name: {userForm.LastName}");
            Console.WriteLine($"License Plate: {userForm.LicensePlate}");
            if (userForm.Picture != null)
            {
    
                Console.WriteLine($"Picture Length: {userForm.Picture.Length}");
            } else
            {
                Console.WriteLine("picture is null");
            }
            // Set picture in container with blob storage to set picture in.


            return Ok(new { message = "Data received" });
        }

        public class UserFormModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string LicensePlate { get; set; }
            public IFormFile? Picture { get; set; }
        }


    }
}
