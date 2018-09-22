using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Utility;

namespace CashRegister.BO
{
    public sealed class Fruit : Item
    {
        //Fruit class inherits from parent class item specifically for fruits
        //As a sealed class, no other class can inherit from it


        public Fruit(string name, int quantUnitPrice, int weightUnitPrice, int inStockQuantity, int inStockWeight, string itemCode)
        {
            //This block helps to neaten the code up by allowing you to put your values 
            //In a bracket on a line for every new Fruit you wish to add

            this.Name = name;
            this.QuantityUnitPrice = quantUnitPrice;
            this.WeightUnitPrice = weightUnitPrice;
            this.InStockQuantity = inStockQuantity;
            this.InStockWeight = inStockWeight;
            this.ItemCode = itemCode;

        }

        public override string Receipt()
        {
            //Simply prints the user's current choice to screen in a conversational manner
            //NOT THE FINAL RECEIPT 
            string receiptMessage = "";
            if (this.userSelectedOption == UserSelectedOption.UserSelectedArr[0])
            {
                this.Total = this.QuantityUnitPrice * this.Quantity;
                receiptMessage = String.Format("\n\n----- Item Code: {4} ----- \n{0} cost {1:C} a piece. \nSo {2} will cost you {3:C}. \nPress enter to advance", this.Name, this.QuantityUnitPrice, this.Quantity, this.Total, this.ItemCode);
            }
            else
            {
                this.Total = this.WeightUnitPrice * this.Quantity;
                receiptMessage = String.Format("\n\n----- Item Code: {4} ----- \n{0} cost {1:C} per lb. \nSo {2} will cost you {3:C}. \nPress enter to advance", this.Name, this.WeightUnitPrice, this.Quantity, this.Total, this.ItemCode);
            }

            return receiptMessage;
            //throw new NotImplementedException();
        }

        public override string HowManyItemsOfChoice()
        {
            //Self explanatory

            string itemOfChoiceMessage = "";
            if (this.userSelectedOption == UserSelectedOption.UserSelectedArr[0])
                itemOfChoiceMessage = String.Format("\n\nHow many numbers of {0} would you like to buy? \n ", this.Name);
            else
                itemOfChoiceMessage = String.Format("\n\nHow many lbs of {0} would you like to buy? \n ", this.Name);

            return itemOfChoiceMessage;

            //throw new NotImplementedException();
        }

    }

}

