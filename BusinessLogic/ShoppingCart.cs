using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ShoppingCart : List<Item>
    {

        public List<IDiscountStrategy> Discounts;

        public ShoppingCart()
        {
            Discounts = new List<IDiscountStrategy>();
        }

        public void Remove(string itemName)
        {
            if (itemName == null) throw new ArgumentNullException("itemName");
            var item = this.Where(i => i.Name == itemName).FirstOrDefault();
         
            this.Remove(item);
        }

        public double Total()
        {
            foreach (var discount in Discounts)
            {
                discount.Execute(this);
            }

            return this.Sum(i => i.Costs);
        }

        public void WipeCart()
        {
            // Why would you do this? - you crazy fool!

            RemoveRange(0, this.Count);
        }


    }
}
