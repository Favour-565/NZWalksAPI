using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NzApp.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //create a get action method
        //GET: https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            string[] studentNames = new string[] { "John", "Kelvin", "Mark", "Emily" };
            {
                return Ok(studentNames);
            }
           

        }
    }
}
