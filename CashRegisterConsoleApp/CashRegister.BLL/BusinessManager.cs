using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.BO;
using System.IO;
using CashRegister.Utility;
using CashRegister.DAL;

namespace CashRegister.BLL
{/// <summary>
/// All Business logic should go Here..
/// </summary>
    public class BusinessManager
    {
        public static string message = "", couponCode = "";
        //message and x and declared in this way because i needed to use them in other methods in this class

        public static int length = 1, grandTotal = 0;
        //length is used in the for loop in order to enable the user run the code or any number of times without closing
        //Grandtotal keeps record of the total of every item purchase you make and stores in memory till it's needed later
        public static string userSelectedOption = "";
        Repository repositoryDAL = new Repository();

        
        
        public void DotheWork()
        {
            repositoryDAL.WriteToDataFile("\nThanks for doing business with us \nHere's Your Receipt: \n\n Item   Quantity  Price   Total   FreeQuantity(If Any) \n\n");//First line written into the text file       
            

            Fruit banana = new Fruit("Bananas", 2, 10, 50, 10, "Ripebanan3");
            Fruit apple = new Fruit("Apples", 3, 10, 62, 10, "apple320");
            Fruit pineApple = new Fruit("Pineapples", 2, 10, 100, 10, "pineapple4");
            Fruit pear = new Fruit("Pears", 4, 10, 72, 10, "Pearsily");
            Fruit orange = new Fruit("Oranges", 5, 10, 93, 10, "orahigh3");
            DisplayCouponInfo();
            couponCode = Console.ReadLine().ToUpper();
            
                
            if (Coupons.couponArr.Contains(couponCode))
                Console.Write("Voila ! Coupon Code {0} Applied.", couponCode);
            else
                Console.Write("No Coupon Code Applied");

            for (int i = 0; i < length; i++)
            {
                try
                {

                    if (length == 1)
                    {
                        message = "\n What would you like to buy? We have BANANA , ORANGE , APPLE , PINEAPPLE AND PEAR \n ";
                    }
                    else if (length >= 1)
                    {
                        message = "\nThanks for staying! What else would you like to buy?   ";
                    }
                    Console.Write(message);


                    string userPurchaseValue = Console.ReadLine().ToUpper();
                    Console.Write("Do you want to buy by Weight or  quantity? Enter 'W' Or 'Q'  \n ");
                     userSelectedOption = Console.ReadLine().ToUpper();
                    if (!UserSelectedOption.UserSelectedArr.Contains(userSelectedOption))
                    {
                        Console.Write("Invalid Entry . Setting the value to 'Q' \n ");
                        userSelectedOption = UserSelectedOption.UserSelectedArr[0];
                    }


                    switch (userPurchaseValue)
                    {

                        //I PREFER SWITCH CASES OVER IF STATEMENTS IF SO MANY INSTANCES ARE TO BE GIVEN-- MOSTLY DEALING WITH USER INPUT
                        default:
                            Console.WriteLine("Sorry, we do not have {0} in stock yet", userPurchaseValue);
                            //I another item is typed whether intentional or mistakenly, draw the users attention
                            break;


                        case "BANANA":

                            requiredOperations(banana);
                            break;


                        case "APPLE":

                            requiredOperations(apple);
                            break;


                        case "PINEAPPLE":

                            requiredOperations(pineApple);
                            break;

                        case "PEAR":

                            requiredOperations(pear);
                            break;

                        case "ORANGE":

                            requiredOperations(orange);
                            break;

                    }
                    //writeToTextFile.WriteLine(x);//at the end of each loop write the current value for x into text file
                    Console.ReadLine();
                    continuePurchase();


                }
                catch (FormatException e)
                {
                    Console.WriteLine("\n\n\n\n\n{0}\n\n\n\n", e.Message);

                    // THE ONLY RELEVANT EXCEPTION TYPE I FOUND NECESSARY TO USE AT THE MOMENT SINCE THAT'S PROBABLY THE MOST LIKELY OF ERRORS

                    continuePurchase();
                }
            }
        }
        public static void DisplayCouponInfo()
        {
            Console.Write(" Hello! Welcome to Our Store \n \n \n =================================================\n");
            Console.Write(" We have two coupons available Today. \n ");
            Console.Write("=================================================\n ");
            Console.Write("Buy 3 Get 1 Free . Coupon Code : BUY3GET1 \n ");
            Console.Write("Get 10% Off On Total Billed Amount . Coupon Code : 10PERCENTOFF \n ");

            Console.Write("=================================================\n ");
            Console.Write("Which one you want Select \n ");
        }
        public  void requiredOperations(Item item)
        {
            item.userSelectedOption = userSelectedOption;
            howManyWho(item);

            if (getUserInputForQuantity(item))
                repositoryDAL.WriteToDataFile(PrintUserChoicesToTextFile(item));
            grandTotal += item.Total;
        }

        public  void continuePurchase()
        {
            //Simple message to find out if the user wants to buy anything else after each purchase attempt
            //i could make the user specify the number of items before hand but i just used this to protect 
            //customers from feeling stupid or undecided about how many items to buy

            Console.Write("Continue Shopping?    ( Y / N )  ");
            string tryReadKey = Console.ReadLine().ToUpper();//ToUpper() converts your user input into uppercase to prevent mismatched key input

            if (tryReadKey == "Y")
            {
                //If yes, then increase the scope of the for loop
                length += 1;
            }

            else
            {
                //otherwise put a line under the shopping list in the text file
                repositoryDAL.WriteToDataFile("\n-----------------------------------------");
                repositoryDAL.CloseFile();
                // End the StreamWriter process to enable other processes(Specifically StreamReader) to gain access to the text file

                Console.Clear();//just like DOS cls command
                length = 0;// End the for loop

                repositoryDAL.ReadFromFile();

                Console.WriteLine("\nGRAND TOTAL:                       {0:C}", grandTotal);
                Console.WriteLine("\n ===========================================");
                if (couponCode == Coupons.couponArr[1])
                {

                    Console.WriteLine("\n DISCOUNTED TOTAL:(COUPON:10PERCENTOFF) {0:C}", grandTotal - grandTotal * 0.10);
                }
                else if (couponCode == Coupons.couponArr[0])
                {

                    Console.WriteLine("\n Coupon Code  {0} Applied , Make Sure to collect Free items ", couponCode);
                }
                else
                {

                    Console.WriteLine("\n No Coupon Code  Applied , Pay the Full Bill");
                }
                //Writes the grand total
                Console.ReadLine();
            }
        }


        public static bool getUserInputForQuantity(Item item)
        {
            //make sure there are enough items in stock before you embarrass yourself and your client as well
            int userInputForQuantity = int.Parse(Console.ReadLine());
            item.Quantity = userInputForQuantity;
            if (item.userSelectedOption == UserSelectedOption.UserSelectedArr[0])
            {
                if (item.Quantity > item.InStockQuantity)
                {
                    Console.WriteLine("\nWe cannot give you the {0} {1} you requested\nbecause we have only {2} pieces left in stock.\nWe are deeply sorry for any inconvenince caused.\n   Press Enter to Continue!", item.Quantity, item.Name, item.InStockQuantity);
                    length += 1;
                    return false;
                }
                else
                {
                    printReceipt(item);// Refer to printReceipt Method for clarity
                    item.InStockQuantity -= item.Quantity;//Simply subtracts the quantity of items bought from the quantity in stock if purchase is successful
                    return true;
                }

            }
            else
            {
                if (item.Quantity > item.InStockWeight)
                {
                    Console.WriteLine("\nWe cannot give you the {0} {1} you requested\nbecause we have only {2} lbs left in stock.\nWe are deeply sorry for any inconvenince caused.\n   Press Enter to Continue!", item.Quantity, item.Name, item.InStockWeight);
                    length += 1;
                    return false;
                }
                else
                {
                    printReceipt(item);// Refer to printReceipt Method for clarity
                    item.InStockWeight -= item.Quantity;//Simply subtracts the quantity of items bought from the quantity in stock if purchase is successful
                    return true;
                }



            }
            //throw new NotImplementedException();
        }

        public static void printReceipt(Item item)
        {
            Console.WriteLine(item.Receipt());//any object inheriting properties from Item can reference the receipt property 
        }

        public static void howManyWho(Item item)
        {
            Console.Write(item.HowManyItemsOfChoice());// Refer to HowManyItemsOfChoice under fruit class.. 
        }


        public static string PrintUserChoicesToTextFile(Item item)
        {

            string allUserChoices = "";
            //For Buy3Get1 Coupon
            if (couponCode == Coupons.couponArr[0])
            {
                //The items are written to the text file in this format. 
                // If measure by Quantity
                if (item.userSelectedOption == UserSelectedOption.UserSelectedArr[0])
                    allUserChoices = String.Format("{0} --- {1} Nos. --- {2:C} --- {3:C} --- {4} Nos. FREE", item.Name, item.Quantity, item.QuantityUnitPrice, item.Total, item.Quantity / 3);
                //If measure by mass
                else
                    allUserChoices = String.Format("{0} --- {1} Lbs --- {2:C} --- {3:C} --- {4} Lbs. FREE", item.Name, item.Quantity, item.WeightUnitPrice, item.Total, item.Quantity / 3);
            }
            //For percentoff Coupon
            else
            {
                if (item.userSelectedOption == UserSelectedOption.UserSelectedArr[0])
                    allUserChoices = String.Format("{0} --- {1} Nos. --- {2:C} --- {3:C} ", item.Name, item.Quantity, item.QuantityUnitPrice, item.Total);
                else
                    allUserChoices = String.Format("{0} --- {1} Lbs --- {2:C} --- {3:C} ", item.Name, item.Quantity, item.WeightUnitPrice, item.Total);


            }

            return allUserChoices;
            //throw new NotImplementedException();
        }
    }
}

