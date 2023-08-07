using Travel.Models;

namespace Travel.Repository.Interface
{
    public interface IAdminUseService
    {
        Task<Admin_User> AddUser(Admin_User user);
        Task<IEnumerable<Admin_User>> GetAllUsers();
        Task<Admin_User> GetUserByEmail(string email);
        Task<Admin_User> GetUserById(int userId);
        Task<IEnumerable<Admin_User>> GetPendingUsers();
        Task DeleteUser(Admin_User user);

        Task UpdateUser(Admin_User user);
    }
}