using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDS_Code_Challenge.Classes;

namespace SDS_Challenge_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Testupdate()
        {
            Logic intlVal = new Logic();
            Logic testVal = new Logic();
            testVal.UpdateQuality();
            Assert.AreEqual(intlVal.Items[0].Quality - 1, testVal.Items[0].Quality, "The Update did not correctly update the quality of '+ 5 Dexterity Vest'");
            Assert.AreEqual(intlVal.Items[2].SellIn - 1, testVal.Items[2].SellIn, "The Update did not correctly update the sellin of 'Elixir of the Mongoose'");
            Assert.AreEqual(intlVal.Items[3].Quality, testVal.Items[3].Quality, "The Update did not correctly update the quality of 'Sulfuras'");
            Assert.AreEqual(intlVal.Items[4].Quality + 1, testVal.Items[4].Quality, "The Update did not correctly update the quality of 'Backstage passes'");
            Assert.AreEqual(intlVal.Items[1].Quality + 1, testVal.Items[1].Quality, "The Update did not correctly update the quality of 'Aged Brie'");
            Assert.AreEqual(intlVal.Items[5].Quality -2, testVal.Items[5].Quality, "The Update did not correctly update the quality of 'Conjured'");
        }

        [TestMethod]
        public void TestConjured()
        {
            Logic intlVal = new Logic();
            Logic testVal = new Logic();
            for (int i = 0; i < intlVal.Items[5].SellIn; i++)
            {
                testVal.UpdateQuality();
            }
            Assert.AreEqual(0, testVal.Items[5].Quality, "The Update did not correctly update the quality of 'Conjured'");
            Assert.AreEqual(intlVal.Items[5].SellIn - intlVal.Items[5].SellIn, testVal.Items[5].SellIn, "The Update did not correctly update the sellin of 'Conjured'");
        }

        [TestMethod]
        public void TestAgedBrie()
        {
            Logic testVal = new Logic();
            for (int i = 0; i < 55; i++)
            {
                testVal.UpdateQuality();
            }
            Assert.AreEqual(50, testVal.Items[1].Quality, "The Update did not correctly update the quality of 'Aged Brie'");
        }

        [TestMethod]
        public void TestBackstagePass()
        {
            Logic testVal = new Logic();
            for (int i = 0; i < 5; i++)
            {
                testVal.UpdateQuality();
            }
            
            Assert.AreEqual(25, testVal.Items[4].Quality, "The Update did not correctly update the quality of 'Backstage passes' before 10 days remain");

            for (int i = 0; i < 5; i++)
            {
                testVal.UpdateQuality();
            }
         
            Assert.AreEqual(35, testVal.Items[4].Quality, "The Update did not correctly update the quality of 'Backstage passes' when 5 to 10 days remain");

            for (int i = 0; i < 5; i++)
            {
                testVal.UpdateQuality();
            }
            Assert.AreEqual(50, testVal.Items[4].Quality, "The Update did not correctly update the quality of 'Backstage passes' when 0 to 5 days remain");

            testVal.UpdateQuality();

            Assert.AreEqual(0, testVal.Items[4].Quality, "The Update did not correctly update the quality of 'Backstage passes' when negative days remain");

        }

        [TestMethod]
        public void TestSulfuras()
        {
            Logic intlVal = new Logic();
            Logic testVal = new Logic();
            testVal.UpdateQuality();
            Assert.AreEqual(intlVal.Items[3].Quality, testVal.Items[3].Quality, "Sulfuras does not update quality");
            Assert.AreEqual(intlVal.Items[3].SellIn, testVal.Items[3].SellIn, "Sulfuras does not update sell-in");
           
        }
    }
}
