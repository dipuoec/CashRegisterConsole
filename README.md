# CashRegisterConsole

This is a Cash Register console application with the facility to select items from the list and buy an item by weight or quantity. There is limited stock(hardcoded value has be set for the stock limit for each item by weight and quantity. If the user is ordering for more quantity than the stock limit, It will not allow placing order. The user can buy items by quantity or by lbs. The user has to select at the beginning if he/she wants to proceed by Quantity or Weight.

At the start of the project, the user can select a coupon from 'BUY3GET1' OR '10PERCENTOFF', the discount will be applied in the final receipt.

It's important to mention, some of the cases are not handled properly and invalid inputs may crash the application,
 The application is designed using 3-layer architecture and each module has a separate class library.

I have tried to create as much method as possible to reuse the code and used inheritance concepts like abstract class and method overriding. Business object, Business logic, and Data access logic, and utility class are separated in the project library.

Steps to work with application

1> Select Coupon from 'BUY3GET1' OR ' 10PERCENTOFF'
2>If you are not selecting valid value no coupon will be applied.
3>Select the Item from the list
4>User will be asked to buy by mass or quantity ( Enter either 'Q' or 'W')
5>If you are entering invalid input, then by default it will select by Quantity.
6>Enter the number 
7>A message with the total amount will be shown to the user for that Item.
8> In next step user has to decide if he/she wants to buy another item.
9>If 'Y' opted, then User can select another item by quantity or weight. else final recipt will be printed for that item.
10> At the end user can see the final receipt with the discount or free items.

If BUY3GET1 applied User will get 1 piece free for every 3 pieces in each item category.


If 10PERCENTOFF applied then, the user gets 10% off in final billing amount.

If no coupon applied then, the user has to pay the full billed amount.

The user can see a message in the final receipt for the discount.


Please, fill free to reach me at 312-730-6272.

