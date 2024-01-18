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
    public class UnitTestAssignAttributes
    {

        [TestMethod]
        public void AssignAttributes_PositiveAttributes()
        {

            //Arrange
            const int HP = 100, DMG = 40, Reduct = 30;
            double actualHP = 20, actualMaxHP = 20, actualDMG = 40, actualReduct = 60;

            //Act
            Modules.AssignAttributes(ref actualHP, ref actualMaxHP, ref actualDMG, ref actualReduct, HP, DMG, Reduct);

            //Assert
            Assert.AreEqual(actualHP, HP);
            Assert.AreEqual(actualMaxHP, HP);
            Assert.AreEqual(actualDMG, DMG);
            Assert.AreEqual(actualReduct, Reduct);

        }

        [TestMethod]
        public void AssignAttributes_NegativeAttributes()
        {

            //Arrange
            const int HP = -100, DMG = -40, Reduct = -30;
            double actualHP = 0, actualMaxHP = 0, actualDMG = 0, actualReduct = 0;

            //Act
            Modules.AssignAttributes(ref actualHP, ref actualMaxHP, ref actualDMG, ref actualReduct, HP, DMG, Reduct);

            //Assert
            Assert.AreEqual(actualHP, HP);
            Assert.AreEqual(actualMaxHP, HP);
            Assert.AreEqual(actualDMG, DMG);
            Assert.AreEqual(actualReduct, Reduct);

        }

        [TestMethod]
        public void AssignAttributes_AttributesEqualToZero()
        {

            //Arrange
            const int HP = 20, DMG = 40, Reduct = 60;
            double actualHP = 0, actualMaxHP = 0, actualDMG = 0, actualReduct = 0;

            //Act
            Modules.AssignAttributes(ref actualHP, ref actualMaxHP, ref actualDMG, ref actualReduct, HP, DMG, Reduct);

            //Assert
            Assert.AreEqual(actualHP, HP);
            Assert.AreEqual(actualMaxHP, HP);
            Assert.AreEqual(actualDMG, DMG);
            Assert.AreEqual(actualReduct, Reduct);

        }

    }
}