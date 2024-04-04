using NTierExample.DTO.UserDtos;
using NTierExample.Shared;
using NTierExample.ViewModel.UserVms;

namespace NTierExample.BLL.IServices
{
    public interface IUserService
    {
        Task<ResultService<LoginDto>> Login(LoginVm loginVm);

        Task LogOut();
    }
}
