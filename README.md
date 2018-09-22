# CashRegisterConsole

This is a Cash Register console application with facility to select items from the list and buy item by weight or qyantity. There is limited stock for each item  by weight and quantity. If the user is ordering  for more quantity than the stock quantity. It will not allow to place order. User can buy items by quantity or by lbs. User has to select at the begining if he/she want to proceed by Quantity or Weight.



In start of the project user can select coupon from 'BUY3GET1' OR ' 10PERCENTOFF' , which will be applied at the end and will offer will be visisble in final receipt.

I want to inform that , some of the cases are not handled properly and may be crash the application , but the application is designed using 3-layer architecture and each module has separate class library.

I have tried create as much method as possible to reuse the code. 

Steps to work with application

1> Select Coupon from 'BUY3GET1' OR ' 10PERCENTOFF'
2>If you are not selecting valid value no coupon will be applied.
3>Select the Item from the list
4>User will be asked to buy by mass or quantity ( Enter either 'Q' or 'W')
5>If you are entering invalid input, then by default it will select  by Quantity.
6>Enter the number 
7>A message with total amount  will be shown to user for that Item.
8> In next step user has to decide if he/she wants to buy another item.
9>If Y selected , then User can slect another item by quantity or weight.
10> At the end user can see the final recipt with the discount or free items.

If BUY3GET1 applied User will get 1 pieces   free for each 3 pieces in each item category.


If 10PERCENTOFF applied then, user get 10% off in final billing amount.

If no coupon applied then , user has to pay full billed amount.

User can see a message in final recipt for the discount.
