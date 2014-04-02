using NUnit.Framework;

namespace BusinessLogic.NUnit.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        
        [Test]
        public void ShoppingCart_should_be_empty()
        {
            var shoppingCart = new ShoppingCart();
            Assert.AreEqual(0, shoppingCart.Count);
        }

        // should return 0 sub total
        [Test]
        public void ShoppingCart_should_return_zero_total_when_empty()
        {
            var shoppingCart = new ShoppingCart();
            Assert.AreEqual(0,shoppingCart.Total());
        }

        // add item
        [Test]
        public void ShoppingCart_should_return_correct_count()
        {
            var shoppingCart = new ShoppingCart {new Item {Name = "Apple", Costs = 1.20}};
            Assert.AreEqual(1, shoppingCart.Count);
        }

       // remove item
        [Test]
        public void ShoppingCart_should_return_correct_count_when_item_removed()
        {
            var shoppingCart = new ShoppingCart {new Item {Name = "Apple", Costs = 1.20}};
            shoppingCart.Remove("Apple");

            Assert.AreEqual(0, shoppingCart.Count);
        }

        // remove item that is not in the shoppingCart
        [Test]
        public void ShoppingCart_should_return_correct_count_when_removing_item_that_is_not_in_the_cart()
        {
            var shoppingCart = new ShoppingCart { new Item { Name = "Apple", Costs = 1.20 } };
            shoppingCart.Remove("BigApple");

            Assert.AreEqual(1, shoppingCart.Count);
        }

        //total
        [Test]
        public void ShoppingCart_should_return_correct_total()
        {
            var shoppingCart = new ShoppingCart
            {
                new Item {Name = "Apple", Costs = 1.20},
                new Item {Name = "Cherry", Costs = 3.00}
            };

            Assert.AreEqual(4.20, shoppingCart.Total());
        }

    }
}
