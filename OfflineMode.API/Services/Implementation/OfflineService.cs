using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OfflineMode.API.Services.Interface;
using OfflineMode.DATA.Data;
using OfflineMode.DATA.Entities;
using OfflineMode.DATA.Model.Request;
using OfflineMode.DATA.Model.ResponseDTO;

namespace OfflineMode.API.Services.Implementation
{
    public class OfflineService : IOffline
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public OfflineService(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            //    _roleManager = roleManager;
            //
        }


        public async Task AddCourse(CourseRequest courseRequest, string userId)
        {
            var course = new Course
            {
                Title = courseRequest.Title,
                Description = courseRequest.Description,
                UserId = userId,
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }



        public async Task<List<CourseDTO>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses.Select(t => new CourseDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                UserId = t.UserId,
                //ImageUrl = t.ImageUrl,
                
               
            }).ToList();
        }

        public async Task UpdateCourse(int courseId, UpdateRequest updateRequest, string userId)
        {
            var course = await _context.Courses.FindAsync(courseId);

            if (course == null)
            {
                throw new ArgumentException("Course not found.");
            }


            course.Title = updateRequest.Title;
            course.Description = updateRequest.Description;

            await _context.SaveChangesAsync();
        }

        
    }
}
