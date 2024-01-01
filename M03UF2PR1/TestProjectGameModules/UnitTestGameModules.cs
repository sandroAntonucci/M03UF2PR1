using GameModules;

namespace TestProjectGameModules
{
    [TestClass]
    public class UnitTestCheckValidNames
    {
        [TestMethod]
        public void CheckValidNames_InputEmptyString_ReturnsFalse()
        {

            //Arrange
            string names = "";
            bool result;

            //Act
            result = Modules.CheckValidNames(names);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CheckValidNames_InputLessThanFourWords_ReturnsFalse()
        {

            //Arrange
            string names = "Sandro, Alex";
            bool result;

            //Act
            result = Modules.CheckValidNames(names);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CheckValidNames_InputFourWords_ReturnsTrue()
        {

            //Arrange
            string names = "Sandro, Alex, Marcos, Carla";
            bool result;

            //Act
            result = Modules.CheckValidNames(names);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CheckValidNames_InputMoreThanFourWords_ReturnsFalse()
        {

            //Arrange
            string names = "Sandro, Alex, Marcos, Carla, Juan";
            bool result;

            //Act
            result = Modules.CheckValidNames(names);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CheckValidNames_InputFourWordsWithSpecialChars_ReturnsTrue()
        {

            //Arrange
            string names = "$andro, Al&x, Marc$s, Carl%";
            bool result;

            //Act
            result = Modules.CheckValidNames(names);

            //Assert
            Assert.IsTrue(result);

        }
    }
}