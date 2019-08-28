namespace ConsoleTestletApp
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using static ConsoleTestletApp.TestletProgram;

    [TestClass]
    public class TestletAppTest
    {
        /// <summary>
        ///     First two items failure test
        /// </summary>     
        [TestMethod]
        public void FirstTwoItemSuccessTest()
        {
            var itemList = GetItems();

            TestletProgram objTestlet = new TestletProgram("1", itemList);
            var actualData = objTestlet.Randomize();
            Assert.AreEqual(actualData[0].ItemType, ItemTypeEnum.Pretest);
            Assert.AreEqual(actualData[1].ItemType, ItemTypeEnum.Pretest);

        }

        /// <summary>
        ///     First two items failure test
        /// </summary>
        [TestMethod]
        public void FirstTwoItemsFailureTest()
        {
            var itemList = GetItems();

            TestletProgram objTestlet = new TestletProgram("1", itemList);
            var actualResult = objTestlet.Randomize();
            Assert.AreNotEqual(ItemTypeEnum.Operational, actualResult[0].ItemType);
            Assert.AreNotEqual(ItemTypeEnum.Operational, actualResult[1].ItemType);

        }

        /// <summary>
        ///     Success test for ramdom items
        /// </summary>
        [TestMethod]
        public void RandomItemsSuccessTest()
        {
            var itemList = GetItems();

            var expectedList = new List<string> { "1", "2", "3", "4" };

            TestletProgram objTestlet = new TestletProgram("1", itemList);
            var actualResult = objTestlet.Randomize();
            Assert.IsTrue(expectedList.Contains(actualResult[0].ItemId));
            Assert.IsTrue(expectedList.Contains(actualResult[0].ItemId));

        }

        /// <summary>
        ///     Failure test for ramdom items
        /// </summary>
        [TestMethod]
        public void RandomItemsFailureTest()
        {
            var itemList = GetItems();

            var expectedList = new List<string> { "5", "12", "3", "abc" };

            TestletProgram objTestlet = new TestletProgram("1", itemList);
            var actualResult = objTestlet.Randomize();
            Assert.IsFalse(expectedList.Contains(actualResult[0].ItemId));
            Assert.IsFalse(expectedList.Contains(actualResult[1].ItemId));

        }

        /// <summary>
        ///     Last 8 items ramdom failure test
        /// </summary>
        [TestMethod]
        public void RemainingRamdomItemsFailureTest()
        {
            var itemList = GetItems();

            TestletProgram objTestlet = new TestletProgram("1", itemList);
            var actualData = objTestlet.Randomize();
            Assert.AreEqual(actualData.Where(x => x.ItemType == ItemTypeEnum.Operational).Count(), 6);
            Assert.AreEqual(actualData.Where(x => x.ItemType == ItemTypeEnum.Pretest).Count(), 4);

        }

        [TestMethod]
        public void TestForPreTestRandomFromRemainingItemSucess()
        {
            var itemList = GetItems();
            TestletProgram objTestlet = new TestletProgram("1", itemList);
            var actualResult = objTestlet.Randomize();

            Assert.AreEqual(actualResult.Where(x => x.ItemType == ItemTypeEnum.Operational).Count(), 6);
            Assert.AreEqual(actualResult.Where(x => x.ItemType == ItemTypeEnum.Pretest).Count(), 4);
            Assert.AreEqual(actualResult.Count, 10);

        }

        private List<Item> GetItems()
        {
            return new List<Item>()
            {
                new Item {ItemId = "1", ItemType = ItemTypeEnum.Pretest},
                new Item {ItemId = "2", ItemType = ItemTypeEnum.Pretest},
                new Item {ItemId = "3", ItemType = ItemTypeEnum.Pretest},
                new Item {ItemId = "4", ItemType = ItemTypeEnum.Pretest},
                new Item {ItemId = "5", ItemType = ItemTypeEnum.Operational},
                new Item {ItemId = "6", ItemType = ItemTypeEnum.Operational},
                new Item {ItemId = "7", ItemType = ItemTypeEnum.Operational},
                new Item {ItemId = "8", ItemType = ItemTypeEnum.Operational},
                new Item {ItemId = "9", ItemType = ItemTypeEnum.Operational},
                new Item {ItemId = "10", ItemType = ItemTypeEnum.Operational}

            };
        }
    }
}
