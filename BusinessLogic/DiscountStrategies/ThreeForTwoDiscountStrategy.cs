using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.DiscountStrategies
{
    public class ThreeForTwoDiscountStrategy : IDiscountStrategy
    {
        private readonly string _itemToDiscount;

        public ThreeForTwoDiscountStrategy(string itemName)
        {
            _itemToDiscount = itemName;
        }

        public void Execute(List<Item> items)
        {
          
            //div by three?

            // check last element does not have a remainder?
            
            var itemsMatchingDiscount = items.Where(i => i.Name == _itemToDiscount);

            var matchingDiscount = itemsMatchingDiscount as IList<Item> ?? itemsMatchingDiscount.ToList();
            var loopCounter = matchingDiscount.Count() / 3;

            for (int i = 0; i < loopCounter; i++)
            {
                matchingDiscount[i].Costs = 0;
            }

            //var firstThree = matchingDiscount.Take(3);

            //var secondThree = matchingDiscount.Take(3);

            //if (matchingDiscount.Count() >= 3)
            //{

            //    //System.Diagnostics.Debugger.Launch();

            //    // ReSharper disable once PossibleNullReferenceException
            //    items.Where(i => i.Name == _itemToDiscount).FirstOrDefault().Costs = 0;

            //}

        }
    }
}