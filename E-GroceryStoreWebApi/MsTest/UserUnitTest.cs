using AutoFixture;
using E_GroceryStoreWebApi.Controllers;
using E_GroceryStoreWebApi.Core.Interface;
using E_GroceryStoreWebApi.Core.Repository;
using E_GroceryStoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MsTest
{
    [TestClass]
    public class UserUnitTest
    {
        private Mock<IUser> _userRepoMock;
        private Fixture _fixture;
        private UserUnitTest _controller;
        public UserUnitTest()
        {
            _fixture = new Fixture();
            _userRepoMock = new Mock<IUser>();
        }
        [TestMethod]
        public async Task GetUserReturnOk()
        {
            var userList = _fixture.CreateMany<UserModel>(3).ToList();
            _userRepoMock.Setup(repo => repo.GetUsers()).Returns(userList);
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.GetUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task GetEmployeeThrowException()
        {
            _userRepoMock.Setup(repo => repo.GetUser()).Throws(new System.Exception());
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.GetUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddUserReturnOk()
        {
            var user = _fixture.Create<UserModel>();
            _userRepoMock.Setup(repo => repo.AddUser(It.IsAny<UserModel>())).Returns(user);
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.AddUser(user);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddUserThrowException()
        {
            _userRepoMock.Setup(repo => repo.GetUser()).Throws(new Exception());
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.GetUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]
        public async Task UpdateUserReturnOk()
        {
            var user = _fixture.Create<UserModel>();
            _userRepoMock.Setup(repo => repo.UpdateUser(It.IsAny<UserModel>())).Returns(user);
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.UpdateUser(User);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task UpdateEmployeeThrowException()
        {
            _userRepoMock.Setup(repo => repo.GetEmployee()).Throws(new Exception());
            _controller = new EmployeeController(_userRepoMock.Object);
            var result = await _controller.GetEmployee();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]
        public async Task DeleteEmployeeReturnOk()
        {
            var user = _fixture.Create<UserModel>();
            _userRepoMock.Setup(repo => repo.DeleteUserIsAny<int>()).Returns(user);
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.DeleteUser(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task DeleteUserThrowException()
        {
            _userRepoMock.Setup(repo => repo.GetUser()).Throws(new Exception());
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.GetUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
    }
}
