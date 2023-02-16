using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers {
    public class AccountController : Controller {
        //Injetando classes UserManager e SignInManager
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //Sempre gerar os construtores
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Criando metodo login
        [HttpGet]
        public IActionResult Login(string returnUrl) {
            return View(new LoginViewModel() {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM) {
            if(!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null) {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false/*Persistir o cookie*/, false/*Bloquear o user caso erre o login*/);
                if (result.Succeeded) {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl)) {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Falha ao fazer login!");
            return View(loginVM);
        }
    }
}
