using Impacta.GAD.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDTO> GetUserByEmailAsync(string email);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string passwoord);
        Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDTO);
        Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDTO);
    }
}
