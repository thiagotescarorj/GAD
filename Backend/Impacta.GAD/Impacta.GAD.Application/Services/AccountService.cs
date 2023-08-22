using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Enumeradores;
using Impacta.GAD.Domain.Identity;
using Impacta.GAD.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.GAD.Application.Services {
    public class AccountService : IAccountService {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserRepository userRepository) {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDTO, string password) {
            try {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == userUpdateDTO.Email.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(user, password, false);

            } catch (Exception ex) {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDTO) {
            try {

                if (await UserExists("admin@elawio.com.br") == false) {
                    var userAdmin = new UserDTO() {
                        Email = "admin@elawio.com.br",
                        Nome = "Administrador GDA",
                        Password = "gf@!#hGGet12",

                    };

                    var admin = _mapper.Map<User>(userAdmin);
                    admin.UserName = userAdmin.Email;
                    admin.PerfilUsuario = EnumPefil.Administrador;
                    admin.IsAtivo = true;

                    await _userManager.CreateAsync(admin, userAdmin.Password);

                }

                var user = _mapper.Map<User>(userDTO);
                user.UserName = userDTO.Email;
                user.NomeCompleto = userDTO.Nome + " " + userDTO.Sobrenome;
                user.PerfilUsuario = EnumPefil.NaoInformado;

                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded) {
                    return _mapper.Map<UserUpdateDTO>(user);
                }

                return null;
            } catch (Exception ex) {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> GetUserByUserNameAsync(string userName) {
            try {
                var user = await _userRepository.GetUserByUserNameAsync(userName);
                if (user == null) return null;

                return _mapper.Map<UserUpdateDTO>(user);

            } catch (Exception ex) {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDTO) {
            try {
                var user = await _userRepository.GetUserByUserNameAsync(userUpdateDTO.UserName);
                if (user == null) return null;

                userUpdateDTO.Id = user.Id;

                _mapper.Map(userUpdateDTO, user);

                if (userUpdateDTO.Password != null) {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                     await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.Password);
                }

                _userRepository.Atualizar<User>(user);

                if (await _userRepository.SalvarAlteracoesAsync()) {
                    var userRetorno = await _userRepository.GetUserById(user.Id);

                    return _mapper.Map<UserUpdateDTO>(userRetorno);
                }

                return null;

            } catch (Exception ex) {

                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string username) {
            try {
                return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
            } catch (Exception ex) {

                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
