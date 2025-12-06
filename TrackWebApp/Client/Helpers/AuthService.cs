using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public class AuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> IniciarSesion(string usuario, string contraseña)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario, contraseña, false, false);
            return result;
        }

        public async Task CerrarSesion()
        {
            await _signInManager.SignOutAsync();
        }
    }

}
