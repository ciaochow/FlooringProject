using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.Workflows
{
    public class RemoveOrderWorkflow
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
                Console.WriteLine("Sorry! There are no orders at all to delete...");
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
                    // we found the correct order to delete.
                    Console.Clear();
                    Console.WriteLine("DELETE ORDER SUMMARY");
                    Console.WriteLine("*****************");
                    Console.WriteLine("orderNumber  customerName  stateName  taxRate  productType  Area    CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax    Total");
                    Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6}                {7}              {8}" +
                                              "     {9}   {10}  {11}", ordertofind.orderNumber,
                                      ordertofind.customerName, ordertofind.stateName,
                                      ordertofind.taxRate, ordertofind.productType,
                                      ordertofind.Area, ordertofind.CostPerSquareFoot,
                                      ordertofind.LaborCostPerSquareFoot,
                                      ordertofind.MaterialCost, ordertofind.LaborCost,
                                      ordertofind.Tax, ordertofind.Total);

                    // Delete order (y/n)
                    bool prompt = false;
                    string newgame = "";
                    while (prompt == false)
                    {
                        Console.Write("\nDelete entire order. Are you sure? (Y/N): ");
                        newgame = Console.ReadLine();
                        if (newgame.ToUpper() == "Y" || newgame.ToUpper() == "YES"
                            || newgame.ToUpper() == "N" || newgame.ToUpper() == "NO")
                        {
                            prompt = true;
                        }
                    }
                    if (newgame.ToUpper() == "Y" || newgame.ToUpper() == "YES")
                    {

                        manager.RemoveOrder(ordertofind, date, ordernumber);
                        Console.Write("Order has been deleted. Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("Order not deleted. Press any key to continue...");
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
    }
}
