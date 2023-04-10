using Microsoft.AspNetCore.Identity;
using Core.DTOs.AccountViewModels;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface IAccountService
    {
        Task<SignInResult> Login(LoginViewModel model);

        Task<IdentityResult> Register( );
    }
}
