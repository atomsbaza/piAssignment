using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using piAssignment.EntityModels;
using piAssignment.Repositories;
using piAssignment.Models;
using piAssignment.Interface;

namespace piAssignment.Tests;

public class UserRepositoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    #region Create User
    [Test]
    public async Task CreateUser_ValidUser_ReturnsTrue()
    {
        var options = new DbContextOptionsBuilder<piDbContext>()
           .UseInMemoryDatabase(databaseName: "GetUserInformationById_ExistingUserId_ReturnsUser")
           .Options;
        using (var dbContext = new piDbContext(options))
        {
            var newUser = new UserInfoRequestModel
            {
                Name = "Pisit Koolplukpol",
                EmailAddress = "test@test.com"
            };
            dbContext.SaveChanges();

            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.CreateUser(newUser);

            Assert.IsTrue(result);
        }
    }

    [Test]
    public async Task CreateUser_ValidUser_ReturnsFalse()
    {
        var options = new DbContextOptionsBuilder<piDbContext>()
           .UseInMemoryDatabase(databaseName: "GetUserInformationById_ExistingUserId_ReturnsUser")
           .Options;
        using (var dbContext = new piDbContext(options))
        {
            UserInfoRequestModel newUser = new UserInfoRequestModel();
            newUser = null;
            dbContext.SaveChanges();

            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.CreateUser(newUser);

            Assert.IsFalse(result);
        }
    }
    #endregion

    #region GetUserById
    [Test]
    public async Task GetUserInformationById_ExistingUserId_ReturnsUser()
    {
        int userId = 1;
        var options = new DbContextOptionsBuilder<piDbContext>()
            .UseInMemoryDatabase(databaseName: "GetUserInformationById_ExistingUserId_ReturnsUser")
            .Options;

        using (var dbContext = new piDbContext(options))
        {
            dbContext.UserInfos.Add(new UserInfoModel
            {
                Name = "User1",
                EmailAddress = "user1@example.com",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            dbContext.SaveChanges();

            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.GetUserInformationById(userId);

            Assert.NotNull(result);
            Assert.That(result.UserId, Is.EqualTo(userId));
        }
    }

    [Test]
    public async Task GetUserInformationById_NonExistingUserId_ReturnsNull()
    {
        int userId = 3;
        var options = new DbContextOptionsBuilder<piDbContext>()
            .UseInMemoryDatabase(databaseName: "GetUserInformationById_NonExistingUserId_ReturnsNull")
            .Options;

        using (var dbContext = new piDbContext(options))
        {
            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.GetUserInformationById(userId);

            Assert.Null(result);
        }
    }
    #endregion

    #region GetUserByName
    [Test]
    public async Task GetUserInformationByName_ExistingUserName_ReturnsUserList()
    {
        string userName = "User";
        var options = new DbContextOptionsBuilder<piDbContext>()
            .UseInMemoryDatabase(databaseName: "GetUserInformationByName_ExistingUserName_ReturnsUserList")
            .Options;

        using (var dbContext = new piDbContext(options))
        {
            dbContext.UserInfos.Add(new UserInfoModel
            {
                Name = "User1",
                EmailAddress = "user1@example.com",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            dbContext.UserInfos.Add(new UserInfoModel
            {
                Name = "User2",
                EmailAddress = "user2@example.com",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            dbContext.UserInfos.Add(new UserInfoModel
            {
                Name = "Us2",
                EmailAddress = "user2@example.com",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            });
            dbContext.SaveChanges();

            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.GetUserInformationByName(userName);

            Assert.NotNull(result);
            Assert.IsInstanceOf<List<UserInfoModel>>(result);
            Assert.That(result.Count, Is.EqualTo(2));
        }
    }

    [Test]
    public async Task GetUserInformationByName_NonExistingUserName_ReturnsNull()
    {
        string userName = "NonExistingUser";
        var options = new DbContextOptionsBuilder<piDbContext>()
            .UseInMemoryDatabase(databaseName: "GetUserInformationByName_NonExistingUserName_ReturnsNull")
            .Options;

        using (var dbContext = new piDbContext(options))
        {
            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.GetUserInformationByName(userName);

            Assert.AreEqual(0, result.Count);
        }
    }
    #endregion

    #region Update User
    [Test]
    public async Task UpdateUser_ValidUser_ReturnsSuccessful()
    {
        var options = new DbContextOptionsBuilder<piDbContext>()
            .UseInMemoryDatabase(databaseName: "GetUserInformationByName_NonExistingUserName_ReturnsNull")
            .Options;
        using (var dbContext = new piDbContext(options))
        {
            int userId = 2;
            var userInfo = new UserInfoRequestModel
            {
                Name = "Pisit Koolplukpol",
                EmailAddress = "test@test.com"
            };
            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.UpdateUser(userId, userInfo);

            Assert.IsTrue(result);
        }
    }

    [Test]
    public async Task UpdateUser_ValidUser_ReturnsNotSuccessful()
    {
        var options = new DbContextOptionsBuilder<piDbContext>()
            .UseInMemoryDatabase(databaseName: "GetUserInformationByName_NonExistingUserName_ReturnsNull")
            .Options;
        using (var dbContext = new piDbContext(options))
        {
            int userId = 10;
            UserInfoRequestModel userInfo = new UserInfoRequestModel();
            userInfo = null;
            var userRepository = new UserRepository(dbContext);
            var result = await userRepository.UpdateUser(userId, userInfo);

            Assert.IsFalse(result);
        }
    }
    #endregion
}