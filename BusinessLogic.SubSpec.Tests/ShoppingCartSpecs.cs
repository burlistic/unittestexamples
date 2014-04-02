using BusinessLogic.DiscountStrategies;
using SubSpec;
using Xunit;

namespace BusinessLogic.SubSpec.Tests
{
    public class ShoppingCartSpecs
    {
        [Specification]
        public void ShoppingCart_double_discount()
        {
            var shoppingCart = default(ShoppingCart);
            "Given a shopping cart with six apples"
                .Context(() =>
                    shoppingCart = new ShoppingCart
                    {
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1}
                            });

            "with a three for two discount on apples"
                .Do(() =>
                    shoppingCart.Discounts.Add(new ThreeForTwoDiscountStrategy("Apple")));

            "expect only fours apples to be charged for in the total"
                .Assert(() =>
                    Assert.Equal(4, shoppingCart.Total()));
        }


        [Specification]
        public void ShoppingCart_double_discount_with_remainder()
        {
            var shoppingCart = default(ShoppingCart);
            "Given a shopping cart with seven apples"
                .Context(() =>
                    shoppingCart = new ShoppingCart
                    {
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1}
                            });

            "with a three for two discount on apples"
                .Do(() =>
                    shoppingCart.Discounts.Add(new ThreeForTwoDiscountStrategy("Apple")));

            "expect only five apples to be charged for in the total"
                .Assert(() =>
                    Assert.Equal(5, shoppingCart.Total()));
        }

    }
}
