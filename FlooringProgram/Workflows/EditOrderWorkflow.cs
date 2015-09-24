﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            var date = GetDate();
            var ordernumber = GetOrderNumber();
            var manager = new OrderManager();
            var response = manager.DisplayOrders(date);
            if (response.Data.Orders.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Sorry! There are no orders at all for that particular date..");
                Console.Write("Press any key to continue... ");
                Console.ReadKey();
            }
            else
            {
                var ordertofind = response.Data.Orders.FirstOrDefault(a => a.orderNumber == ordernumber);
                if (ordertofind == null)
                {
                    Console.WriteLine();
                    Console.Write("Order#{0} was not found. Press any key to continue... ", ordernumber);
                    Console.ReadKey();
                }
                else
                {
                    // we found the correct order.
                    Console.Clear();
                    Console.WriteLine("EDIT ORDER SUMMARY");
                    Console.WriteLine("*****************");
                    Console.WriteLine("orderNumber  customerName  stateName  taxRate  productType  Area    CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax    Total");
                    Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6:c}                {7:c}              {8:c}" +
                                              "     {9:c}   {10:c}  {11:c}", ordertofind.orderNumber,
                                      ordertofind.customerName, ordertofind.stateName,
                                      ordertofind.taxRate, ordertofind.productType,
                                      ordertofind.Area, ordertofind.CostPerSquareFoot,
                                      ordertofind.LaborCostPerSquareFoot,
                                      ordertofind.MaterialCost, ordertofind.LaborCost,
                                      ordertofind.Tax, ordertofind.Total);

                    Console.WriteLine();
                    Console.Write("\nPress ENTER to edit... ");
                    Console.ReadLine();
                    Console.WriteLine();

                    var ordertoedit = new Order();

                    //Update Customer Name
                    Console.Write("Enter customer name ({0}): ", ordertofind.customerName);
                    string inputname = Console.ReadLine();
                    if (inputname != "")
                    {
                        ordertoedit.customerName = inputname;
                    }
                    if (inputname == "")
                    {
                        ordertoedit.customerName = ordertofind.customerName;
                    }

                    // Update State Name
                    ordertoedit.stateName = GetStateName(ordertofind);

                    // Update Product Type
                    ordertoedit.productType = GetProductType(ordertofind);
                    ordertoedit.orderNumber = ordertofind.orderNumber;
                    // Update Area
                    do
                    {
                        Console.Write("Enter area ({0}): ", ordertofind.Area);
                        string inputarea = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputarea, out num);
                        if (inputarea == "")
                        {
                            ordertoedit.Area = ordertofind.Area;
                            break;
                        }
                        if (inputarea != "" && test)
                        {
                            ordertoedit.Area = num;
                            break;
                        }
                    } while (true);

                    // confirm (y/n)
                    bool prompt = false;
                    string newgame = "";
                    while (prompt == false)
                    {
                        Console.Write("\nCommit new order? (Y/N): ");
                        newgame = Console.ReadLine();
                        if (newgame.ToUpper() == "Y" || newgame.ToUpper() == "YES"
                            || newgame.ToUpper() == "N" || newgame.ToUpper() == "NO")
                        {
                            prompt = true;
                        }
                    }
                    if (newgame.ToUpper() == "Y" || newgame.ToUpper() == "YES")
                    {

                        var response1 = manager.EditOrder(ordertoedit, date, ordernumber); // the order before it's been fully populated.
                        var editedorder = response1.Data.Order; // the one we get back after we load all data.

                        Console.Clear();
                        Console.WriteLine("(SUMMARY OF NEWLY EDITED ORDER)");
                        Console.WriteLine("*****************");
                        Console.WriteLine("orderNumber  customerName  stateName  taxRate  productType  Area    CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax    Total");
                        Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6:c}          {7:c}              {8:c}" +
                                                  "     {9:c}   {10:c}  {11:c}", editedorder.orderNumber,
                                          editedorder.customerName, editedorder.stateName,
                                          editedorder.taxRate, editedorder.productType,
                                          editedorder.Area, editedorder.CostPerSquareFoot,
                                          editedorder.LaborCostPerSquareFoot,
                                          editedorder.MaterialCost, editedorder.LaborCost,
                                          editedorder.Tax, editedorder.Total);

                        Console.WriteLine();
                        Console.Write("Order has been edited. Press any key to continue...");
                        Console.ReadKey();
                    }
                    else // user types no. Revert back to old order information.
                    {
                        manager.EditOrder(ordertofind, date, ordernumber);
                        Console.Write("Edited changes cancelled. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private int GetOrderNumber()
        {
            do
            {
                Console.Write("Enter order number(Ex: 1): ");
                string input = Console.ReadLine();
                int num;
                var passThisString = input;
                bool parsedinput = int.TryParse(input, out num);
                if (parsedinput)
                {
                    return num;
                }
            } while (true);
        }

        private string GetDate()
        {
            do
            {
                Console.Write("Enter date of order (MMDDYYYY): ");
                string input = Console.ReadLine();
                int num;
                var passThisString = input;
                bool parsedinput = int.TryParse(input, out num);
                if (parsedinput)
                {
                    return passThisString;
                }
            } while (true);
        }

        private string GetStateName(Order order)
        {
            do
            {
                Console.Write("Enter state name (only OH/PA/MI/IN)({0}): ", order.stateName);
                string input = Console.ReadLine();
                if (input.ToUpper() == "OH" || input.ToUpper() == "PA" ||
                    input.ToUpper() == "MI" || input.ToUpper() == "IN")
                {
                    return input.ToUpper();
                }
                if (input == "")
                {
                    return order.stateName;
                }
            } while (true);
        }

        private string GetProductType(Order order)
        {
            do
            {
                Console.Write("Enter product type (only carpet/laminate/tile/wood)({0}): ", order.productType);
                string input = Console.ReadLine();
                if (input.ToUpper() == "CARPET")
                {
                    return "Carpet";
                }
                if (input.ToUpper() == "LAMINATE")
                {
                    return "Laminate";
                }
                if (input.ToUpper() == "TILE")
                {
                    return "Tile";
                }
                if (input.ToUpper() == "WOOD")
                {
                    return "Wood";
                }
                if (input == "")
                {
                    return order.productType;
                }
            } while (true);
        }
    }
}
