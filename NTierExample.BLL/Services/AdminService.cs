using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NTierExample.BLL.IServices;
using NTierExample.DTO.UserDtos;
using NTierExample.Entities.AppEntities;
using NTierExample.Entities.AppIdentityEntities;
using NTierExample.Shared;
using NTierExample.ViewModel.UserVms;
using TierExample.DAL.IRepositories;

namespace NTierExample.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public AdminService(UserManager<AppUser> userManager,
                            IUserRepo userRepo,
                            IMapper mapper)
        {
            _userManager = userManager;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<ResultService<bool>> CreateUserAsync(UserCreateDto userCreateDto)
        {
            ResultService<bool> resultService = new ResultService<bool>();

            AppUser appUser = _mapper.Map<AppUser>(userCreateDto);
            User user = _mapper.Map<User>(appUser);

            var result = await _userManager.CreateAsync(appUser, appUser.Password);

            if (!result.Succeeded)
            {
                resultService.Model = result.Succeeded;
                result.Errors.ToList().ForEach(error =>
                {
                    resultService.AddErrorItem(error.Code,error.Description);
                });
                return resultService;
            }

            bool added = await _userRepo.AddAsync(user);

            if (!added)
            {
                resultService.Model = added;
                resultService.AddErrorItem("Hata","Kullanıcı oluşturulamadı");
                return resultService;
            }

            resultService.Model = true;

            return resultService;
        }

        public async Task<ResultService<bool>> DeleteUserAsync(int userId)
        {
            ResultService<bool> resultService = new ResultService<bool>();

            var appUser = await _userManager.FindByIdAsync(userId.ToString());
            var user = await _userRepo.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || appUser == null)
            {
                resultService.Model = false;
                resultService.AddErrorItem("Kullanıcı bulunamadı", "Kullanıcı Bulunamadı");
                return resultService;   
            }
            var result = await _userManager.DeleteAsync(appUser);

            if (!result.Succeeded)
            {
                resultService.Model = false;
                result.Errors.ToList().ForEach(error =>
                {
                    resultService.AddErrorItem(errorTitle: error.Code, errorMessage: error.Description);
                });

                return resultService;
            }

            resultService.Model = await _userRepo.DeleteAsync(user);

            if (!resultService.Model)
            {
                resultService.AddErrorItem("Hata", "Beklenmedik bir hata oluştu");
            }

            resultService.Model = true;

            return resultService;
        }

        public async Task<ResultService<List<UserListVm>>> GetAllUsersAsync()
        {
            ResultService<List<UserListVm>> resultService = new ResultService<List<UserListVm>>();

            var userList = await _userRepo.GetFilteredAllAsync(select: x => _mapper.Map<UserListVm>(x));

            if (userList == null)
            {
                resultService.AddErrorItem("Hata", "Beklenmedik bir hata oluştu");
            }

            resultService.Model = userList.ToList();

            return resultService;
        }

        public async Task<ResultService<UserDetailVm>> GetUserAsync(int id)
        {
            ResultService<UserDetailVm> resultService = new ResultService<UserDetailVm>();

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                resultService.AddErrorItem("Hata", "Kullanıcı Bulunamadı");
                return resultService;
            }

            UserDetailVm userDetailVm = _mapper.Map<UserDetailVm>(user);
            var roleList = await _userManager.GetRolesAsync(user);
            userDetailVm.RoleNames = roleList.ToList();

            resultService.Model = userDetailVm;

            return resultService;
        }

        public async Task<ResultService<List<UserListVm>>> GetUsersByRoleNameAsync(string roleName)
        {
            ResultService<List<UserListVm>> resultService = new ResultService<List<UserListVm>>();

            var userList = await _userManager.GetUsersInRoleAsync(roleName.ToUpper());

            if (userList == null)
            {
                resultService.AddErrorItem("Hata", "Beklenmedik bir hata oluştu");
                return resultService;
            }

            resultService.Model = userList.Select(x => _mapper.Map<UserListVm>(x)).ToList();

            return resultService;
        }

        public async Task<ResultService<bool>> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            ResultService<bool> resultService = new ResultService<bool>();

            var appUser = _mapper.Map<AppUser>(userUpdateDto);
            var user = _mapper.Map<User>(appUser);

            var result = await _userManager.UpdateAsync(appUser);

            if (!result.Succeeded)
            {
                resultService.Model = false;
                result.Errors.ToList().ForEach(result =>
                {
                    resultService.AddErrorItem(result.Code, result.Description);
                });
                return resultService;
            }

            bool updated = await _userRepo.UpdateAsync(user);

            if (!updated)
            {
                resultService.Model = false;
                resultService.AddErrorItem("Hata", "Güncelleme Başarısız");
                return resultService;
            }

            resultService.Model = true;
            return resultService;
        }
    }
}
