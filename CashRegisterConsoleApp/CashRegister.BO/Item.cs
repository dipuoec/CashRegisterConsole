using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BO
{
    //Business Object Class . It's abstract class
   
        public abstract class Item
        {
            public string Name { get; set; }
            public int QuantityUnitPrice { get; set; }
            public int WeightUnitPrice { get; set; }
            public int Quantity { get; set; }
            public int InStockWeight { get; set; }
            public int InStockQuantity { get; set; }
            public int Total { get; set; }
            public string userSelectedOption { get; set; }
            public string ItemCode { get; set; }
            public abstract string HowManyItemsOfChoice();
            public abstract string Receipt();
        
    }
}
