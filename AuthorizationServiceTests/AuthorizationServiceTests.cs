using NUnit.Framework;
using AuthorizationService.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AuthorizationService.Repo;
using AuthorizationService.MemberRepo;
using Moq;

namespace AuthorizationServiceTests
{
    [TestFixture]
    public class AuthorizationServiceTests
    {

        List<LoginModel> Credentials = new List<LoginModel>();
        DbContextOptions options;
        [SetUp]
        public void Setup()
        {

            Credentials = new List<LoginModel> { new LoginModel { UserName = "user1", Password = "pass1" }, new LoginModel { UserName = "user2", Password = "pass2" } };

            options= new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseInMemoryDatabase(databaseName: "AuthorizationService")
            .Options;


            using (var context = new EmployeeDbContext(options))
            {
                
                context.Employees.AddRange(Credentials);
                context.SaveChanges();

            }
        }
        [TearDown]
        public void CleanDatabase()
        {
            using (var context = new EmployeeDbContext(options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [TestCase("user1", "pass1")]
        [TestCase("user2", "pass2")]
        public void GetUserCred_Returns_Object(string UserName, string Password)
        {


            var credentials = new LoginModel { UserName = UserName, Password = Password };

      

        using (var context = new EmployeeDbContext(options))
        {

                Mock<IMemberRepository> mock = new Mock<IMemberRepository>();

                mock.Setup(p => p.GetMember(It.IsAny<LoginModel>())).Returns(credentials);
                MemberRepository uRepo = new MemberRepository(context);

                var userCred = uRepo.GetMember(credentials);

                Assert.IsInstanceOf<LoginModel>(userCred);
         }
        
        }

        [TestCase("user3", "user3")]
        public void GetUserCred_Returns_Null(string uname, string pass)
        {
          
            LoginModel cred = new LoginModel { UserName = uname, Password = pass };
            Mock<IMemberRepository> mock = new Mock<IMemberRepository>();
            mock.Setup(p => p.GetMember(It.IsAny<LoginModel>())).Returns((LoginModel)null);


            using (var context = new EmployeeDbContext(options))
            {
                MemberRepository uRepo = new MemberRepository(context);
                var userCred = uRepo.GetMember(cred);
                Assert.IsNull(userCred);

            }

        }


    }
}