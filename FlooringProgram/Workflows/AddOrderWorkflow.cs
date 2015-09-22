using System;
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
            bool end = false;
            do
            {
                Console.Clear();
                string Date = GetDate();
                Console.Clear();
                string CustomerName = GetCustomerName();
                Console.Clear();
                string StateName = GetStateName();
                Console.Clear();
                decimal TaxRate = GetTaxRate();
                Console.Clear();
                string ProductType = GetProductType();
                Console.Clear();
                decimal Area = GetArea();
                Console.Clear();
                decimal CostPerSquareFoot = GetCostPerSquareFoot();
                Console.Clear();
                decimal LaborCostPerSquareFoot = GetLaborCostPerSquareFoot();
                Console.Clear();
                decimal MaterialCost = GetMaterialCost();
                Console.Clear();
                decimal LaborCost = GetLaborCost();
                Console.Clear();
                decimal Tax = GetTax();
                Console.Clear();
                decimal Total = GetTotal();
                Console.Clear();

                Console.WriteLine("NEW ORDER SUMMARY");
                Console.WriteLine("*****************");
                Console.WriteLine("orderNumber  customerName  stateName  taxRate  productType  Area    CostPerSquareFoot LaborCostPerSquareFoot MaterialCost LaborCost Tax    Total");
                Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6}                {7}              {8}" +
                                          "     {9}   {10}  {11}", "#",
                                          CustomerName, StateName,
                                          TaxRate, ProductType,
                                          Area, CostPerSquareFoot,
                                          LaborCostPerSquareFoot,
                                          MaterialCost, LaborCost,
                                          Tax, Total);

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
                    var manager = new OrderManager();
                    var order = new Order();
                    order.customerName = CustomerName;
                    order.stateName = StateName;
                    order.taxRate = TaxRate;
                    order.productType = ProductType;
                    order.Area = Area;
                    order.CostPerSquareFoot = CostPerSquareFoot;
                    order.LaborCostPerSquareFoot = LaborCostPerSquareFoot;
                    order.MaterialCost = MaterialCost;
                    order.LaborCost = LaborCost;
                    order.Tax = Tax;
                    order.Total = Total;
                    var response = manager.AddOrder(order,Date);

                    Console.Write("Order added to the system. Press any key to continue...");
                    Console.ReadKey();
                    end = true;
                }
                else
                {
                    Console.Write("Order has been cancelled! Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
               

            } while (end == false);

            
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
                Console.Write("Enter state name (ex: OH): ");
                string input = Console.ReadLine();
                int num;
                bool test = int.TryParse(input, out num);
                if (input.Length == 2 && input != "" && !test)
                {
                    return input;
                }
            } while (true);
        }

        private decimal GetTaxRate()
        {
            do
            {
                Console.Write("Enter tax rate (ex: 6.75): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
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

        private string GetProductType()
        {
            do
            {
                Console.Write("Enter product type (ex: Wood): ");
                string input = Console.ReadLine();
                int num;
                bool test = int.TryParse(input, out num);
                if (input.Length > 0 && input != "" && !test)
                {
                    return input;
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

        private decimal GetCostPerSquareFoot()
        {
            do
            {
                Console.Write("Enter Cost per Square Foot (ex: 5.00): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
                {
                    return num;
                }
            } while (true);
        }

        private decimal GetLaborCostPerSquareFoot()
        {
            do
            {
                Console.Write("Enter Labor Cost per Square Foot (ex: 5.00): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
                {
                    return num;
                }
            } while (true);
        }

        private decimal GetMaterialCost()
        {
            do
            {
                Console.Write("Enter material cost (ex: 5.00): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
                {
                    return num;
                }
            } while (true);
        }

        private decimal GetLaborCost()
        {
            do
            {
                Console.Write("Enter labor cost (ex: 5.00): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
                {
                    return num;
                }
            } while (true);
        }

        private decimal GetTax()
        {
            do
            {
                Console.Write("Enter tax (ex: 5.00): ");
                string input = Console.ReadLine();
                decimal num;
                bool test = decimal.TryParse(input, out num);
                if (input != "" && test)
                {
                    return num;
                }
            } while (true);
        }

        private decimal GetTotal()
        {
            do
            {
                Console.Write("Enter total cost (ex: 500.00): ");
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
