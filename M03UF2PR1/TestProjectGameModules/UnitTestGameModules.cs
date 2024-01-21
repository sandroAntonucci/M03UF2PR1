using GameModules;

namespace TestProjectGameModules
{
    [TestClass]
    public class UnitTestCheckAndAssignValidNames
    {
        [TestMethod]
        public void CheckAndAssignValidNames_InputEmptyString_ReturnsFalse()
        {

            //Arrange
            const string Names = "", ExpectedArcher = "", ExpectedBarbarian = "", ExpectedMage = "", ExpectedDruid = "";

            string archerName = "", barbarianName = "", mageName = "", druidName = "";

            bool result;

            //Act
            result = Modules.CheckAndAssignValidNames(Names, ref archerName, ref barbarianName, ref mageName, ref druidName);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(archerName, ExpectedArcher);
            Assert.AreEqual(barbarianName, ExpectedBarbarian);
            Assert.AreEqual(mageName, ExpectedMage);
            Assert.AreEqual(druidName, ExpectedDruid);

        }

        [TestMethod]
        public void CheckAndAssignValidNames_InputLessThanFourWords_ReturnsFalse()
        {

            //Arrange
            const string Names = "Sandro, Alex", ExpectedArcher = "", ExpectedBarbarian = "", ExpectedMage = "", ExpectedDruid = "";

            string archerName = "", barbarianName = "", mageName = "", druidName = "";

            bool result;

            //Act
            result = Modules.CheckAndAssignValidNames(Names, ref archerName, ref barbarianName, ref mageName, ref druidName);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(archerName, ExpectedArcher);
            Assert.AreEqual(barbarianName, ExpectedBarbarian);
            Assert.AreEqual(mageName, ExpectedMage);
            Assert.AreEqual(druidName, ExpectedDruid);

        }

        [TestMethod]
        public void CheckAndAssignValidNames_InputFourWords_ReturnsTrue()
        {

            //Arrange
            const string Names = "Sandro, Alex, Carla, Marcos", ExpectedArcher = "Sandro", ExpectedBarbarian = "Alex", ExpectedMage = "Carla", ExpectedDruid = "Marcos";

            string archerName = "", barbarianName = "", mageName = "", druidName = "";

            bool result;

            //Act
            result = Modules.CheckAndAssignValidNames(Names, ref archerName, ref barbarianName, ref mageName, ref druidName);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(archerName, ExpectedArcher);
            Assert.AreEqual(barbarianName, ExpectedBarbarian);
            Assert.AreEqual(mageName, ExpectedMage);
            Assert.AreEqual(druidName, ExpectedDruid);

        }



        [TestMethod]
        public void CheckAndAssignValidNames_InputMoreThanFourWords_ReturnsFalse()
        {

            //Arrange
            const string Names = "Sandro, Alex, Carla, Marcos, Juan", ExpectedArcher = "", ExpectedBarbarian = "", ExpectedMage = "", ExpectedDruid = "";

            string archerName = "", barbarianName = "", mageName = "", druidName = "";

            bool result;

            //Act
            result = Modules.CheckAndAssignValidNames(Names, ref archerName, ref barbarianName, ref mageName, ref druidName);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(archerName, ExpectedArcher);
            Assert.AreEqual(barbarianName, ExpectedBarbarian);
            Assert.AreEqual(mageName, ExpectedMage);
            Assert.AreEqual(druidName, ExpectedDruid);

        }

        [TestMethod]
        public void CheckAndAssignValidNames_InputFourWordsWithSpecialChars_ReturnsTrue()
        {

            //Arrange
            const string Names = "$andro, Al&x, Marc$s, Carl%", ExpectedArcher = "$andro", ExpectedBarbarian = "Al&x", ExpectedMage = "Marc$s", ExpectedDruid = "Carl%";

            string archerName = "", barbarianName = "", mageName = "", druidName = "";

            bool result;

            //Act
            result = Modules.CheckAndAssignValidNames(Names, ref archerName, ref barbarianName, ref mageName, ref druidName);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(archerName, ExpectedArcher);
            Assert.AreEqual(barbarianName, ExpectedBarbarian);
            Assert.AreEqual(mageName, ExpectedMage);
            Assert.AreEqual(druidName, ExpectedDruid);

        }
    }

    
    [TestClass]
    public class UnitTestAssignStats
    {

        [TestMethod]
        public void AssignStats_PositiveAttributes()
        {

            //Arrange
            double[,] matrix = { { 1500, 200, 25 }, { 3000, 150, 35 }, { 1100, 300, 20 }, { 2000, 70, 25 }, { 7000, 300, 20 } };
            double[] expectedArray = { 3000, 3000, 150, 35 };

            //Act
            double[] resultArray = Modules.AssignStats(matrix, 1);

            //Assert
            
            for(int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], resultArray[i]);
            }

        }

    }

    [TestClass]
    public class UnitTestCheckValidAttributes
    {

        [TestMethod]
        public void CheckValidAttributes_PositiveStatBetweenRange()
        {

            //Arrange
            const double attributeValue = 20, minValue = 5, maxValue = 40;

            //Act
            bool result = Modules.CheckValidAttributes(attributeValue, minValue, maxValue);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CheckValidAttributes_PositiveStatNotBetweenRange()
        {

            //Arrange
            const double attributeValue = 41, minValue = 5, maxValue = 40;


            //Act
            bool result = Modules.CheckValidAttributes(attributeValue, minValue, maxValue);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CheckValidAttributes_InferiorLimit_BetweenRange()
        {

            //Arrange
            const double attributeValue = 5, minValue = 5, maxValue = 40;


            //Act
            bool result = Modules.CheckValidAttributes(attributeValue, minValue, maxValue);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CheckValidAttributes_SuperiorLimit_BetweenRange()
        {

            //Arrange
            const double attributeValue = 40, minValue = 5, maxValue = 40;


            //Act
            bool result = Modules.CheckValidAttributes(attributeValue, minValue, maxValue);

            //Assert
            Assert.IsTrue(result);

        }
    }

    [TestClass]
    public class UnitTestGenerateRandom
    {

        [TestMethod]
        public void GenerateRandom_PositiveInput()
        {

            //Arrange
            const double min = 10, max = 100;

            //Act
            double result = Modules.GenerateRandom(Convert.ToInt32(min), Convert.ToInt32(max));

            //Assert

            Assert.IsTrue(result >= min && result <= max);

        }

    }

    [TestClass]
    public class UnitTestSaveNames
    {

        [TestMethod]
        public void SaveNames_ValidNames()
        {

            //Arrange
            const string ArcherName = "a", BarbarianName = "b", MageName = "c", DruidName = "d";
            string[] ExpectedNames = { "a", "b", "c", "d" };

            //Act
            string[] resultNames = Modules.SaveNames(ArcherName, BarbarianName, MageName, DruidName);

            //Assert

            Assert.AreEqual(resultNames, ExpectedNames);
        }
    }

}