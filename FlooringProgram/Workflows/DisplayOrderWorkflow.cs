﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.BLL;

namespace FlooringProgram.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            var date = GetDate();
            var manager = new OrderManager();
            var response = manager.DisplayOrders(date);
            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine(
                    "orderNumber  customerName  stateName  taxRate  productType  Area    CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax    Total");

                foreach (var order in response.Data.Orders)
                {
                    Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6:c}          {7:c}              {8:c}" +
                                      "     {9:c}   {10:c}  {11:c}", order.orderNumber,
                                      order.customerName, order.stateName,
                                      order.taxRate, order.productType,
                                      order.Area, order.CostPerSquareFoot,
                                      order.LaborCostPerSquareFoot,
                                      order.MaterialCost, order.LaborCost,
                                      order.Tax, order.Total);

                }
                Console.Write("\nPress any key to continue... ");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(response.Message);
                Console.Write("\nPress any key to continue... ");
                Console.ReadKey();
            }

        }

        private string GetDate()
        {
            do
            {
                Console.Write("Enter date of orders to display (MMDDYYYY): ");
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
