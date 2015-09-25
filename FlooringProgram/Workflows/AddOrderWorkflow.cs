﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;

namespace FlooringProgram.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            string Date = GetDate();
            Console.Clear();
            string CustomerName = GetCustomerName();
            Console.Clear();
            string StateName = GetStateName();
            Console.Clear();
            string ProductType = GetProductType();
            Console.Clear();
            decimal Area = GetArea();
            Console.Clear();
            var manager = new OrderManager();
            var order = new Order();
            order.customerName = CustomerName;
            order.stateName = StateName;
            order.productType = ProductType;
            order.Area = Area;

            var response = manager.AddOrder(order, Date);
            if(response.Data.Orders == null || response.Data.Orders.Count < 1 )
            {
                Console.WriteLine("Blah...");
            }
            var neworder = response.Data.Order;

            Console.WriteLine("NEW ORDER SUMMARY");
            Console.WriteLine("*****************");
            Console.WriteLine("orderNumber  customerName  stateName  taxRate  productType  Area    CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax    Total");
            Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6:c}                {7:c}              {8:c}" +
                                      "     {9:c}   {10:c}  {11:c}", "#",
                                      neworder.customerName, neworder.stateName,
                                      neworder.taxRate, neworder.productType,
                                      neworder.Area, neworder.CostPerSquareFoot,
                                      neworder.LaborCostPerSquareFoot,
                                      neworder.MaterialCost, neworder.LaborCost,
                                      neworder.Tax, neworder.Total);
            Console.WriteLine();

            bool prompt = false;
            string newgame = "";
            while (prompt == false)
            {
                Console.Write("Commit new order? (Y/N): ");
                newgame = Console.ReadLine();
                if (newgame.ToUpper() == "Y" || newgame.ToUpper() == "YES"
                    || newgame.ToUpper() == "N" || newgame.ToUpper() == "NO")
                {
                    prompt = true;
                }
            }
            if (newgame.ToUpper() == "Y" || newgame.ToUpper() == "YES")
            {
                Console.Write("Order added to the system. Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                
                manager.RemoveOrder(neworder, Date, neworder.orderNumber);
                Console.Write("Order has been cancelled! Press any key to continue...");
                Console.ReadKey();
            }
        }

        private string GetCustomerName()
        {
            do
            {
                Console.Write("Enter customer name: ");
                string input = Console.ReadLine();
                int num;
                bool test = int.TryParse(input, out num);
                if (input.Length > 0 && input != "" && !test)
                {
                    return input;
                }
            } while (true);
        }

        private string GetStateName()
        {
            do
            {
                Console.Write("Enter state name (only OH/PA/MI/IN): ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "OH" || input.ToUpper() == "PA" ||
                    input.ToUpper() == "MI" || input.ToUpper() == "IN")
                {
                    return input.ToUpper();
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

        private string GetProductType()
        {
            do
            {
                Console.Write("Enter product type (only carpet/laminate/tile/wood): ");
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
            } while (true);

        }

        private decimal GetArea()
        {
            do
            {
                Console.Write("Enter area (ex: 10.00): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
                {
                    return num;
                }
            } while (true);
        }
    }
}
