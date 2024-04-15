using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfflineMode.API.Services.Interface;
using OfflineMode.DATA.Model.Request;
using OfflineMode.DATA.Model.ResponseDTO;
using System.Security.Claims;

namespace OfflineMode.API.Controllers
{
    [Route("api/phoenix")]
    [ApiController]
    public class OfflineController : ControllerBase
    {
        private readonly IOffline _offlineService;
     

        public OfflineController(IOffline offlineService)
        {
            _offlineService = offlineService;
        }


        [HttpPost("addCourse")]
        [Authorize(Roles = "Admin")]
       
        
        public async Task<ActionResult<CourseDTO>> AddCourse([FromBody] CourseRequest courseRequest)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value);

            if (courseRequest == null)
            {
                return BadRequest("Course request object is null.");
            }

            await _offlineService.AddCourse(courseRequest, userId);
            return Ok("Course added successfully.");
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        /*[AllowAnonymous]*/ // Helps in testing endpoint without token
        public async Task<IActionResult> GetCourses()
        {
            //var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value);
            var courses = await _offlineService.GetCourses();
            return Ok(courses);
        }


        [HttpPut("updateCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] UpdateRequest updateRequest)
        {
            

            if (updateRequest == null)
            {
                return BadRequest("Update request object is null.");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value);
            await _offlineService.UpdateCourse( courseId, updateRequest, userId);

            return Ok("Course updated successfully.");
        }



    }
}
