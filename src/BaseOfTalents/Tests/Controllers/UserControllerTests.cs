﻿using DAL;
using DAL.DTO;
using DAL.Infrastructure;
using DAL.Migrations;
using DAL.Services;
using Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using WebUI.Controllers;

namespace Tests.Controllers
{
    public class UserControllerTests : BaseTest
    {
        UserController controller;

        [SetUp]
        public void Init()
        {
            System.Diagnostics.Debug.WriteLine("User init");

            context = GenerateNewContext();

            context.Users.AddRange(users);
            context.SaveChanges();

            IUnitOfWork uow = new UnitOfWork(context);
            UserService service = new UserService(uow);

            controller = new UserController(service);
        }

        [TearDown]
        public void TearDown()
        {
            System.Diagnostics.Debug.WriteLine("User teardown");
            context.Database.Delete();
            controller = null;
            context = null;

        }

        [Test]
        public void OnPostControllerShouldAddUser()
        {
            System.Diagnostics.Debug.WriteLine("User adding");

            UserDTO userToAdd = new UserDTO
            {
                BirthDate = new DateTime(1960, 1, 1, 0, 0, 0),
                Email = string.Format("NEWUSER@mail.com"),
                FirstName = "NEWUSER",
                isMale = true,
                LastName = "NEWUSER",
                CityId = 1,
                Login = "NEWUSER",
                MiddleName = "NEWUSER",
                Password = "qwerty123",
                RoleId = 1,
                PhoneNumbers = new List<PhoneNumberDTO> { new PhoneNumberDTO { Number = "+3800000000" } },
                Photo = new FileDTO
                {
                    Description = "user photo",
                    FilePath = "some/path"
                },
                Skype = "skype666"
            };
            var httpResult = controller.Post(userToAdd);
            var response = httpResult as JsonResult<UserDTO>;
            var result = response.Content;

            Assert.NotNull(result);
            Assert.AreNotEqual(result.Id, 0);
        }

        [Test]
        public void OnGetControllerShouldReturnUser()
        {
            System.Diagnostics.Debug.WriteLine("User returned");

            var httpresult = controller.Get(1);
            var response = httpresult as JsonResult<UserDTO>;
            var result = response.Content;

            Assert.NotNull(result);
            Assert.AreEqual(result.Id, 1);
        }


        [Test]
        public void OnUpdateControllerShouldUpdateUsersPhoneNumbers()
        {
            System.Diagnostics.Debug.WriteLine("User phonenumbers updated");

            var httpResult = controller.Get(1);
            var response = httpResult as JsonResult<UserDTO>;
            var user = response.Content;

            string newPhoneNumber = "+39091325322";
            user.PhoneNumbers.First().Number = newPhoneNumber;

            var newHttpResult = controller.Put(user.Id, user);
            var newResponse = newHttpResult as JsonResult<UserDTO>;
            var newUser = newResponse.Content;

            Assert.AreEqual(newPhoneNumber, newUser.PhoneNumbers.First().Number);
        }

        //[Test]
        //public void OnUpdateControllerShouldUpdateUsersPhoto()
        //{
        //    System.Diagnostics.Debug.WriteLine("User photo updated");

        //    var httpResult = controller.Get(1);
        //    var response = httpResult as JsonResult<UserDTO>;
        //    var user = response.Content;

        //    string newPhotoDescription = "new description";
        //    user.Photo.Description = newPhotoDescription;

        //    var newHttpResult = controller.Put(user.Id, user);
        //    var newResponse = newHttpResult as JsonResult<UserDTO>;
        //    var newUser = newResponse.Content;

        //    Assert.AreEqual(newUser.Photo.Description, newPhotoDescription);
        //}

        List<User> users = new List<User>
        {
                    new User
                    {
                        BirthDate = new DateTime(1960,1,1,0,0,0),
                        Email = string.Format("firstmail@mail.com"),
                        FirstName = "FirstNameUserName",
                        isMale = true,
                        LastName = "LastNameUserName",
                        City = DummyData.Cities[1],
                        Login = "killer666",
                        MiddleName = "MiddleNameUserName",
                        Password = "qwerty123",
                        PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "+380930986252" } },
                        Photo = new File
                        {
                            Description = "user photo",
                            FilePath = "some/path"
                        },
                        Role = DummyData.Roles[1],
                        Skype = "skype666"
                    },
                    new User
                    {
                        BirthDate = new DateTime(1950,1,1,0,0,0),
                        Email = string.Format("secondmail@mail.com"),
                        FirstName = "secondname",
                        isMale = false,
                        LastName = "secondname",
                        City = DummyData.Cities[2],
                        Login = "killerwa666",
                        MiddleName = "secondname",
                        Password = "qwerty123321",
                        PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "+38095365242" } },
                        Photo = new File
                        {
                            Description = "second user photo",
                            FilePath = "some/newpath"
                        },
                        Role = DummyData.Roles[2],
                        Skype = "skype666123"
                    }
        };
    }
}
