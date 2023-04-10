using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.AccountViewModels;
using Core.IServices;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AspUser> _userManager;

        private readonly SignInManager<AspUser> _signInManager;
                        
        private readonly IRepository<Employee> employeeRepository;

        public AccountService(UserManager<AspUser> userManager, SignInManager<AspUser> signInManager, IRepository<Employee> repository)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.employeeRepository = repository;
        }

        // TODO: на Privacy стоит добавить просмотр пользователей и их ролей
        public async Task<SignInResult> Login(LoginViewModel model)
        {
            var user =  employeeRepository.GetAll().Include(u => u.AspUser).FirstOrDefaultAsync(u => u.AspUser.Email == model.Email);

            if( user.Result == null)
            {
                return SignInResult.Failed;
            }

            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        }

        public Task<IdentityResult> Register()
        {
            throw new NotImplementedException();
        }
    }
}
