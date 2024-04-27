using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        

        public OfflineService(ApplicationDbContext context)
        {
            _context = context;
           
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

        public async Task<bool> DeleteTweet(int id)
        {

            // Retrieve the Course from the database
            var tweet = await _context.Courses.FirstOrDefaultAsync(t => t.Id == id);

            if (tweet == null)
            {
                return false; // Tweet not found
            }

            _context.Courses.Remove(tweet);
            await _context.SaveChangesAsync();

            return true; // Tweet successfully deleted
        }


    }
}

