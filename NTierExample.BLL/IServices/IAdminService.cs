using NTierExample.DTO.UserDtos;
using NTierExample.Shared;
using NTierExample.ViewModel.UserVms;

namespace NTierExample.BLL.IServices
{
    public interface IAdminService
    {
        Task<ResultService<List<UserListVm>>> GetAllUsersAsync();

        Task<ResultService<List<UserListVm>>> GetUsersByRoleNameAsync(string roleName);

        Task<ResultService<bool>> CreateUserAsync(UserCreateDto userCreateDto);

        Task<ResultService<bool>> UpdateUserAsync(UserUpdateDto userUpdateDto);

        Task<ResultService<bool>> DeleteUserAsync(int userId);

        Task<ResultService<UserDetailVm>> GetUserAsync(int id);
    }
}
