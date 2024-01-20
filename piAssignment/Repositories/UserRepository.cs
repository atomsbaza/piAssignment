using System;
using Microsoft.EntityFrameworkCore;
using piAssignment.EntityModels;
using piAssignment.Interface;
using piAssignment.Models;

namespace piAssignment.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly piDbContext _piDbContext;
        public UserRepository(piDbContext piDbContext)
		{
			_piDbContext = piDbContext;
		}

        public UserRepository()
        {
        }

        public async Task<bool> CreateUser(UserInfoRequestModel newUser)
        {
            try
            {
                if (newUser == null)
                {
                    throw new ArgumentNullException(nameof(newUser));
                }

                var userEntity = new UserInfoModel
                {
                    Name = newUser.Name,
                    EmailAddress = newUser.EmailAddress,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                _piDbContext.UserInfos.Add(userEntity);
                await _piDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserInfoModel?> GetUserInformationById(int id)
        {
            var result = await GetUserInformationByIdInternal(id);
            return result;
        }

        private async Task<UserInfoModel?> GetUserInformationByIdInternal(int id)
        {
            var results = await _piDbContext.UserInfos.FirstOrDefaultAsync(f => f.UserId == id);

            if (results == null)
            {
                return null;
            }

            var userInfo = new UserInfoModel
            {
                UserId = results.UserId,
                Name = results.Name,
                EmailAddress = results.EmailAddress,
                CreatedDate = results.CreatedDate,
                UpdatedDate = results.UpdatedDate
            };

            return userInfo;
        }

        public async Task<List<UserInfoModel?>?> GetUserInformationByName(string userName)
        {
            var results = await _piDbContext.UserInfos.Where(f => f.Name.Contains(userName)).OrderBy(f => f.UserId).ToListAsync();

            if (results == null)
            {
                return null;
            }

            var userInfoList = results.Select(result => new UserInfoModel
            {
                UserId = result.UserId,
                Name = result.Name,
                EmailAddress = result.EmailAddress,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            }).ToList();

            return userInfoList;
        }

        public async Task<string> UpdateUser(int id, UserInfoRequestModel userInfo)
        {
            var existingUser = await _piDbContext.UserInfos.FirstOrDefaultAsync(f => f.UserId == id);
            if (existingUser == null)
            {
                return "This user not exist";
            }

            existingUser.Name = userInfo.Name;
            existingUser.EmailAddress = userInfo.EmailAddress;
            existingUser.UpdatedDate = DateTime.Now;

            await _piDbContext.SaveChangesAsync();

            return "successful";
        }
    }
}

