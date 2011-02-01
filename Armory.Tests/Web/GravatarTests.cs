using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Armory.Web;

namespace Armory.Tests
{
    [TestClass]
    public class Gravatar_Given_An_Email_Should
    {
        private Gravatar target;
        private string testEmail;
        private string testEmailHash;

        [TestInitialize]
        public void Initialize()
        {
            testEmail = "tim@timrayburn.net";
            testEmailHash = Gravatar.CreateMD5Hash(testEmail);
            target = new Gravatar(testEmail);
        }

        [TestMethod]
        public void ToString_Should_Create_Img_Tag()
        {
            // Arrange 

            // Act
            var tag = target.ToString();

            // Assert
            StringAssert.Contains(tag, testEmailHash);
            StringAssert.StartsWith(tag, "<img");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Size_Should_Not_Allow_Negative_Values()
        {
            // Arrange


            // Act
            var tag = target.Size(-1);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Size_Should_Not_Allow_Values_Over_512()
        {
            // Arrange


            // Act
            var tag = target.Size(513);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Size_Should_Be_Included_In_Img_Src_Querystring()
        {
            // Arrange


            // Act
            var tag = target.Size(128).ToString();

            // Assert
            StringAssert.StartsWith(tag, "<img");
            StringAssert.Contains(tag, "s=128&");
        }

        [TestMethod]
        public void Default_Should_Be_Able_To_Be_A_Url()
        {
            // Arrange


            // Act
            var tag = target.Default("http://TimRayburn.net").ToString();

            // Assert
            StringAssert.StartsWith(tag, "<img");
            StringAssert.Contains(tag, "TimRayburn.net");
        }

        [TestMethod]
        public void Default_Should_Be_Able_To_Be_A_Enumeration_Value()
        {
            // Arrange
            

            // Act
            var tag = target.Default(GravatarDefaults.IdentIcon).ToString();

            // Assert
            StringAssert.StartsWith(tag, "<img");
            StringAssert.Contains(tag, "identicon");
        }

        [TestMethod]
        public void Default_Should_Be_Capable_Of_404_Enumeration_Value()
        {
            // Arrange
            

            // Act
            var tag = target.Default(GravatarDefaults.return404).ToString();

            // Assert
            StringAssert.StartsWith(tag, "<img");
            StringAssert.Contains(tag, "404");
        }

        [TestMethod]
        public void Rating_Should_Be_Enumeration_Value()
        {
            // Arrange
            

            // Act
            var tag = target.Rating(GravatarRating.G).ToString();

            // Assert
            StringAssert.StartsWith(tag, "<img");
            StringAssert.Contains(tag, "r=g&");
        }

        [TestMethod]
        public void AlternateText_Should_Create_An_Alt_Attribute()
        {
            // Arrange
            

            // Act
            var tag = target.AlternateText("TestingTesting").ToString();

            // Assert
            StringAssert.StartsWith(tag, "<img");
            StringAssert.Contains(tag, "alt=\"TestingTesting\"");
        }

        [TestMethod]
        public void ToString_Should_Produce_A_Self_Closing_Tag()
        {
            // Arrange
            

            // Act
            var tag = target.ToString();

            // Assert
            Assert.IsFalse(tag.Contains("</img>"));
        }
    }

    
}
