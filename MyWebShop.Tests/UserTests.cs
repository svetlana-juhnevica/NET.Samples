using MyWebShop.Logic;
using MyWebShop.Logic.Managers;
using System;
using Xunit;

namespace MyWebShop.Tests
{
    public class UserTests
    {
        [Fact]
        public void TestCreateUser()
        {
            string mail = GetRandomText();
            UserManager.Create(mail, "testname", "testpass");
            var user = UserManager.GetByEmail(mail);
            //ja asertācija ir pareiza -> tests veiksmīgs
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
        }
        [Fact]
        public void TestGetUser()
        {
            string mail = GetRandomText();
            string password = "testpass";
            UserManager.Create(mail, "testname", password);
            var user = UserManager.GetByEmailAndPassword(mail, password);
            
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
            Assert.Equal(user.Password, password);
        }
       
        public void TestCreateCategory()
        {
            string name = GetRandomText();
            
            CategoryManager.Create(name, parentId);
            var category = CategoryManager.Get(id);

            Assert.NotNull(category);
            Assert.Equal(category.Id, id);
        
        }
        public static string GetRandomText()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
