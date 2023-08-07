using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Travel.Models;
using Travel.Repository.Interface;

namespace Travel.Repository.Services
{
    public class UsersServices : IAdminUseService
    {
        private readonly KaniniTourismDbContext _context;

        public UsersServices(KaniniTourismDbContext context)
        {
            _context = context;
        }

        public async Task<Admin_User> AddUser(Admin_User user)
        {
            _context.AdminUsers.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<Admin_User>> GetAllUsers()
        {
            var users = await _context.AdminUsers.ToListAsync();
            return users;
        }

        public async Task<Admin_User> GetUserById(int userId)
        {
            return await _context.AdminUsers.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task UpdateUser(Admin_User user)
        {
            _context.AdminUsers.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Admin_User user)
        {
            _context.AdminUsers.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Admin_User> GetUserByEmail(string email)
        {
            return await _context.AdminUsers.FirstOrDefaultAsync(u => u.EmailId == email);
        }

        public async Task<IEnumerable<Admin_User>> GetPendingUsers()
        {
            var pendingUsers = await _context.AdminUsers.Where(u => u.IsActive == false).ToListAsync();
            return pendingUsers;
        }

        private string Encrypt(string password)
        {
            // Example key and IV generation using hashing
            string passphrase = "your-passphrase";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
                byte[] iv = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase)).Take(16).ToArray();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(cryptoStream))
                            {
                                writer.Write(password);
                            }
                        }

                        byte[] encryptedData = memoryStream.ToArray();
                        return Convert.ToBase64String(encryptedData);
                    }
                }
            }
        }

        private string Decrypt(string encryptedPassword)
        {
            // Example key and IV generation using hashing
            string passphrase = "your-passphrase";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
                byte[] iv = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase)).Take(16).ToArray();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    byte[] encryptedData = Convert.FromBase64String(encryptedPassword);

                    using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cryptoStream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
