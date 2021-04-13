using HomeManagement.DTO;
using HomeManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.ServiceAbstractions
{
    public interface IUserService
    {
        Task<Response<UserDTO>> GetUser(string userId);

        Task<bool> EditUser(UserDTO model, string UserId);

        Task<bool> DeleteUser(string userId);

        Task<Response<UserDTO>> Login(LoginDTO model);
    }
}
