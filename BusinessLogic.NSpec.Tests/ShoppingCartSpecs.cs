using BusinessLogic.DiscountStrategies;
using NSpec;

namespace BusinessLogic.NSpec.Tests
{
    internal class ShoppingCartSpecs : nspec
    {

// ReSharper disable once UnusedMember.Local
            private void Given_a_shopping_cart_with_three_apples()
            {

               ShoppingCart shoppingCart = new ShoppingCart();

                before =
                    () =>
                        shoppingCart =
                            new ShoppingCart
                            {
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1}
                            };
                context["When a three for two discount on apples is applied"] =
                    () =>
                    {
                        before = () => shoppingCart.Discounts.Add(new ThreeForTwoDiscountStrategy("Apple"));
                        it["Only two apples should be charged for in the total"] =
                            () => shoppingCart.Total().should_be(2.00);
                    };
            }


// ReSharper disable once UnusedMember.Local
            private void Given_a_shopping_cart_with_four_apples()
            {

                ShoppingCart shoppingCart = new ShoppingCart();

                before =
                    () =>
                        shoppingCart =
                            new ShoppingCart
                            {
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1},
                                new Item {Name = "Apple", Costs = 1}
                            };
                context["When a three for two discount on apples is applied"] =
                    () =>
                    {
                        before = () => shoppingCart.Discounts.Add(new ThreeForTwoDiscountStrategy("Apple"));
                        it["Only three apples should be charged for in the total"] =
                            () => shoppingCart.Total().should_be(3.00);
                    };
            }

        }

}
