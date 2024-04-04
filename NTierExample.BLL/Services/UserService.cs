using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NTierExample.BLL.IServices;
using NTierExample.DTO.UserDtos;
using NTierExample.Entities.AppIdentityEntities;
using NTierExample.Shared;
using NTierExample.ViewModel.UserVms;

namespace NTierExample.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager,
                           SignInManager<AppUser> signInManager,
                           IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResultService<LoginDto>> Login(LoginVm loginVm)
        {
            ResultService<LoginDto> resultService = new ResultService<LoginDto>();

            var user = await _userManager.FindByNameAsync(loginVm.UserName.ToUpper());

            if (user == null)
            {
                resultService.AddErrorItem("Kullanıcı Yok", "Kullanıcı Adı Bulunamadı");
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);

                if (!result.Succeeded)
                {
                    resultService.AddErrorItem("Hatalı Şifre", "Şifrenizi Kontrol Edin");
                }

                LoginDto loginDto = _mapper.Map<LoginDto>(user);
                resultService.Model = loginDto;
            }


            return resultService;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
