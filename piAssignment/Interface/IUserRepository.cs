using System;
using piAssignment.Models;

namespace piAssignment.Interface
{
	public interface IUserRepository
	{
        Task<UserInfoModel?> GetUserInformationById(int id);
        Task<List<UserInfoModel?>?> GetUserInformationByName(string userName);
        Task<bool> CreateUser(UserInfoRequestModel newUser);
        Task<string> UpdateUser(int id, UserInfoRequestModel userInfo);
    }
}

