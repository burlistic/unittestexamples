using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IDiscountStrategy
    {
        void Execute(List<Item> items);
    }
}