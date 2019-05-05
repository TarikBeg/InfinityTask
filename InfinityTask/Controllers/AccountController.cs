using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.Core.EntityModel;
using InfinityTask.Persistance;
using InfinityTask.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InfinityTask.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        private UnitOfWork _unitOfWork= new UnitOfWork(new MyContext());
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Login()
        {
            LoginVM loginVm=new LoginVM();


            List<AppUser> users = _unitOfWork.User.AddUsers();
               
            foreach (var user in users)
            {
              var result=await _userManager.CreateAsync(user, user.PasswordHash);
            }

              _unitOfWork.Blog.AddBlogs();
              
            return View("Login");
        }
        public async Task<IActionResult> CheckLogin(LoginVM loginVM)
        {
            if (!string.IsNullOrEmpty(loginVM.Password)&& !string.IsNullOrEmpty(loginVM.UserName))
            {
                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            
            var User = _unitOfWork.User.Get();
           
            var result = 
               await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, true, false);

            if (result.Succeeded)
                return RedirectToAction("Index","Home");
            }

        
            return RedirectToAction("Login");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}