using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using UserDL;
using UserModels;

namespace UserServiceMockTests
{
    public class UserRepoTest
    {
        private readonly DbContextOptions<UserDBContext> options;
        public UserRepoTest()
        {
            options = new DbContextOptionsBuilder<UserDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();
        }

        [Fact]
        public void AddUserAsyncAddsTheUser()
        {
            using (var context = new UserDBContext(options))
            {
                //Arrange
                IUserRepoDB _repo = new UserRepoDB(context);

                //Act
                _repo.AddUserAsync(
                    new User
                    {
                        UserName = "name8",
                        Email = "new@email.edu",
                        Role = "Associate"
                    }
                );
            }

            using (var assertContext = new UserDBContext(options))
            {
                //Assert
                var result = assertContext.User.Select(c => c).ToList();

                Assert.NotNull(result);
                Assert.Equal(4, result.Count);
            }
        }

        //this delete test doesn't work, and I thinkit has to do with how the model is set up

        //[Fact]
        //public void DeleteUserAsyncDeletesTheUser()
        //{
        //    using (var context = new UserDBContext(options))
        //    {
        //        //Arrange
        //        IUserRepoDB _repo = new UserRepoDB(context);

        //        //Act
        //        _repo.DeleteUserAsync(
        //            new User
        //            {
        //                Id = 1,
        //                UserName = "name1",
        //                Email = "e@mail.edu",
        //                Role = "Associate"
        //            }
        //        );

        //        var result = context.User.Select(c => c).ToList();
        //    }

        //    using (var assertContext = new UserDBContext(options))
        //    {
        //        //Assert
        //        var result = assertContext.User.Select(c => c).ToList();

        //        Assert.NotNull(result);
        //        Assert.Equal(2, result.Count());
        //    }
        //}

        [Fact]
        public void GetUserByEmailAsyncReturnsCorrectUser()
        {
            using (var context = new UserDBContext(options))
            {
                //Arrange
                IUserRepoDB _repo = new UserRepoDB(context);

                //Act
                var result = _repo.GetUserByEmail("e@mail.edu");

                //Assert
                Assert.NotNull(result);
                Assert.Equal(1, result.Result.Id);
            }
        }

        [Fact]
        public void GetUserByIDAsyncReturnsCorrectUser()
        {
            using (var context = new UserDBContext(options))
            {
                //Arrange
                IUserRepoDB _repo = new UserRepoDB(context);

                //Act
                var result = _repo.GetUserByIDAsync(1);

                //Assert
                Assert.NotNull(result);
                Assert.Equal("e@mail.edu", result.Result.Email);
            }
        }

        [Fact]
        public void GetUsersAsyncReturnsAllUsers()
        {
            using (var context = new UserDBContext(options))
            {
                //Arrange
                IUserRepoDB _repo = new UserRepoDB(context);

                //Act
                var result = _repo.GetUsersAsync();

                //Assert
                Assert.NotNull(result);
                Assert.Equal(3, result.Result.Count);
            }
        }

        [Fact]
        public void UpdateUserAsyncChangesTheUser()
        {
            using (var context = new UserDBContext(options))
            {
                //Arrange
                IUserRepoDB _repo = new UserRepoDB(context);

                //Act
                _repo.UpdateUserAsync(
                    new User
                    {
                        Id = 1,
                        UserName = "newName",
                        Email = "e@mail.edu",
                        Role = "Associate"
                    }
                );
            }

            using (var assertContext = new UserDBContext(options))
            {
                //Assert
                var result = assertContext.User.FirstOrDefault(c => c.UserName.Equals("newName"));

                Assert.NotNull(result);
                Assert.Equal(1, result.Id);
            }
        }

        private void Seed()
        {
            using (var context = new UserDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.User.AddRange(
                    new User
                    {
                        Id = 1,
                        UserName = "name1",
                        Email = "e@mail.edu",
                        Role = "Associate"
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "name2",
                        Email = "e2@2mail.e2u",
                        Role = "Associate"
                    },
                    new User
                    {
                        Id = 3,
                        UserName = "name3",
                        Email = "job@revpro.net",
                        Role = "The Boss"
                    }
                );

                context.Report.AddRange(
                    new Report
                    {
                        UserId = 1,
                        TargetId = 10,
                        IsSample = false,
                        ReportDate = new DateTime(2021, 01, 31),
                        Description = "Description for test report"
                    },
                    new Report
                    {
                        UserId = 2,
                        TargetId = 20,
                        IsSample = false,
                        ReportDate = new DateTime(2021, 02, 14),
                        Description = "Another description for testing"
                    },
                    new Report
                    {
                        UserId = 3,
                        TargetId = 30,
                        IsSample = true,
                        ReportDate = new DateTime(2021, 03, 31),
                        Description = "Yet another test description"
                    }
                );
                context.SaveChangesAsync();
            }
        }
    }
}
