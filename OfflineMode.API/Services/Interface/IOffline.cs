using OfflineMode.DATA.Model.Request;
using OfflineMode.DATA.Model.ResponseDTO;

namespace OfflineMode.API.Services.Interface
{
    public interface IOffline
    {
        Task AddCourse(CourseRequest courseRequest, string userId);
        Task<List<CourseDTO>> GetCourses();
        Task UpdateCourse(int courseId, UpdateRequest updateRequest, string userId);
        Task<bool> DeleteTweet(int id);
        //Task CreateRole(string roleName);
        //Task AssignRoleToUser(string userId, string roleName);
        //Task<bool> UserHasRole(string userId, string roleName);
    }
}
