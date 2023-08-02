using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IAdminUserRepository
{
    Task<IEnumerable<Admin_User>> GetAllAdminUsers();
    Task<Admin_User?> GetAdminUserById(int id);
    Task<int> CreateAdminUser(Admin_User adminUser);
    Task<bool> UpdateAdminUser(int id, Admin_User adminUser);
    Task<bool> DeleteAdminUser(int id);
}
