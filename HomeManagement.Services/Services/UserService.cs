using AutoMapper;
using HomeManagement.Core.ServiceAbstractions;
using HomeManagement.DTO;
using HomeManagement.DTO.ManualMapper;
using HomeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HomeManagement.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJWTService _jwtService;
        private readonly IMapper _mapper;

        public UserService(IServiceProvider serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            _jwtService = serviceProvider.GetRequiredService<IJWTService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> EditUser(UserDTO model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var updatedUser = DTOMappings.MapUser(user, model);
            var result = await _userManager.UpdateAsync(updatedUser);
            return result.Succeeded;
        }

        public async Task<Response<UserDTO>> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var returnUser = _mapper.Map<UserDTO>(user);
            return new Response<UserDTO>
            {
                Success = user != null,
                Data = returnUser,
            };
        }

        public async Task<Response<UserDTO>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            Response<UserDTO> response = new Response<UserDTO>();

            if (user != null)
            {
                var check = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!check)
                {
                    response.Message = "Invalid credentials";
                    response.Success = false;
                    return response;
                }

                var dto = _mapper.Map<UserDTO>(user);
                dto.Token = await _jwtService.GetToken(user);
                response.Data = dto;
                response.Success = true;

                return response;
            }

            response.Message = "Invalid credentials";
            response.Success = false;

            return response;
        }
    }
}
