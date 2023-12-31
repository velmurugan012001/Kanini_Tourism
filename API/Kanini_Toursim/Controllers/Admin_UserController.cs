﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Travel.Models;
using Travel.Repository.Interface;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IAdminUseService _userRepository;
        private readonly string _jwtSecret = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx";

        public UsersController(IAdminUseService userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(Admin_User user)
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }

            // Encrypt the password before storing it
            user.Password = Encrypt(user.Password);

            // Set IsActive status based on the role
            if (user.Role == "Agent" || user.Role == "agent")
            {
                user.IsActive = false; // Pending approval for Agents
                var createdUser = await _userRepository.AddUser(user);

                // Return the token as part of the response
                return Ok("Wait untill Approval");
            }
            else
            {
                user.IsActive = true; // Active for other roles 
                var createdUser = await _userRepository.AddUser(user);

                // Generate JWT token with user details
                var token = GenerateJwtToken(createdUser);

                // Return the token  
                return Ok(token);
            }


        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] Admin_User loginModel)
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }

            var existingUser = await _userRepository.GetUserByEmail(loginModel.EmailId);

            if (existingUser == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var decryptedPassword = Decrypt(existingUser.Password);
            if (loginModel.Password != decryptedPassword)
            {
                return Unauthorized("Invalid credentials");
            }

            if (!existingUser.IsActive)
            {
                return Unauthorized("User is not approved");
            }

            var token = GenerateJwtToken(existingUser);

            return Ok(token);
        }

        [HttpPost("approve/{userId}")]
        public async Task<ActionResult> ApproveAgent(int userId)
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }

            var agent = await _userRepository.GetUserById(userId);

            if (agent == null)
            {
                return NotFound("Agent not found.");
            }

            if (
               agent.Role != "agent")
            {
                return BadRequest("The user is not an agent.");
            }

            agent.IsActive = true;

            await _userRepository.UpdateUser(agent);

            return Ok("Agent approved successfully.");
        }

        [HttpPost("reject/{userId}")]
        public async Task<ActionResult> RejectUser(int userId)
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }

            var user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            await _userRepository.DeleteUser(user); // Delete the user from the database

            return Ok("User rejected successfully.");
        }


        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Admin_User>>> GetPendingUsers()
        {
            if (_userRepository == null)
            {
                return Problem("User repository is null.");
            }

            var pendingUsers = await _userRepository.GetPendingUsers();

            return Ok(pendingUsers);
        }

        private string GenerateJwtToken(Admin_User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, user.Role)
             }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string Encrypt(string password)
        {
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