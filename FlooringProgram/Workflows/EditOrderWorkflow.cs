using System;
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
                    Console.WriteLine("{0}             {1}           {2}        {3}      {4}        {5}       {6}                {7}              {8}" +
                                              "     {9}   {10}  {11}", ordertofind.orderNumber,
                                      ordertofind.customerName, ordertofind.stateName,
                                      ordertofind.taxRate, ordertofind.productType,
                                      ordertofind.Area, ordertofind.CostPerSquareFoot,
                                      ordertofind.LaborCostPerSquareFoot,
                                      ordertofind.MaterialCost, ordertofind.LaborCost,
                                      ordertofind.Tax, ordertofind.Total);

                    Console.WriteLine("\nPress ENTER to edit... ");
                    Console.ReadLine();
                    Console.WriteLine();
                    //Update Customer Name
                    Console.Write("Enter customer name ({0}): ", ordertofind.customerName);
                    string inputname = Console.ReadLine();
                    if (inputname != "")
                        ordertofind.customerName = inputname;
                    // Update State Name
                    do
                    {
                        Console.Write("Enter state name ({0}): ", ordertofind.stateName);
                        string inputstate = Console.ReadLine();
                        if (inputstate == "")
                            break;
                        if (inputstate.Length == 2)
                        {
                            ordertofind.stateName = inputstate.ToUpper();
                            break;
                        }
                    } while (true);


                    do // Update Tax Rate
                    {
                        Console.Write("Enter tax rate ({0}): ", ordertofind.taxRate);
                        string inputtaxrate = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputtaxrate, out num);
                        if (test == false && inputtaxrate == "")
                            break;

                        if (inputtaxrate != "" && test)
                        {
                            ordertofind.taxRate = num;
                            break;
                        }
                    } while (true);

                    // Update Product Type
                    do
                    {
                        Console.Write("Enter product type ({0}): ", ordertofind.productType);
                        string inputproducttype = Console.ReadLine();
                        if (inputproducttype != "")
                        {
                            ordertofind.productType = inputproducttype;
                            break;
                        }
                        if (inputproducttype == "")
                            break;

                    } while (true);


                    do // Update Area
                    {
                        Console.Write("Enter area ({0}): ", ordertofind.Area);
                        string inputarea = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputarea, out num);
                        if (test == false && inputarea == "")
                            break;

                        if (inputarea != "" && test)
                        {
                            ordertofind.Area = num;
                            break;
                        }
                    } while (true);

                    do // Update CostPerSquareFoot
                    {
                        Console.Write("Enter CostPerSquareFoot ({0}): ", ordertofind.CostPerSquareFoot);
                        string inputcostpersqfoot = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputcostpersqfoot, out num);
                        if (test == false && inputcostpersqfoot == "")
                            break;
                        if (inputcostpersqfoot != "" && test)
                        {
                            ordertofind.CostPerSquareFoot = num;
                            break;
                        }
                    } while (true);

                    do // Update LaborCostSquareFoot
                    {
                        Console.Write("Enter LaborCostPerSquareFoot ({0}): ", ordertofind.LaborCostPerSquareFoot);
                        string inputlaborcostpersqfoot = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputlaborcostpersqfoot, out num);
                        if (test == false && inputlaborcostpersqfoot == "")
                            break;
                        if (inputlaborcostpersqfoot != "" && test)
                        {
                            ordertofind.LaborCostPerSquareFoot = num;
                            break;
                        }
                    } while (true);

                    do // Update MaterialCost
                    {
                        Console.Write("Enter Material Cost ({0}): ", ordertofind.MaterialCost);
                        string inputmaterialcost = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputmaterialcost, out num);
                        if (test == false && inputmaterialcost == "")
                            break;
                        if (inputmaterialcost != "" && test)
                        {
                            ordertofind.MaterialCost = num;
                            break;
                        }
                    } while (true);

                    do // Update LaborCost
                    {
                        Console.Write("Enter Labor Cost ({0}): ", ordertofind.LaborCost);
                        string inputlaborcost = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputlaborcost, out num);
                        if (test == false && inputlaborcost == "")
                            break;
                        if (inputlaborcost != "" && test)
                        {
                            ordertofind.LaborCost = num;
                            break;
                        }
                    } while (true);

                    do // Update Tax
                    {
                        Console.Write("Enter Tax ({0}): ", ordertofind.Tax);
                        string inputtax = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputtax, out num);
                        if (test == false && inputtax == "")
                            break;
                        if (inputtax != "" && test)
                        {
                            ordertofind.Tax = num;
                            break;
                        }
                    } while (true);

                    do // Update Total
                    {
                        Console.Write("Enter Total ({0}): ", ordertofind.Total);
                        string inputtotal = Console.ReadLine();
                        decimal num;
                        bool test = decimal.TryParse(inputtotal, out num);
                        if (test == false && inputtotal == "")
                            break;
                        if (inputtotal != "" && test)
                        {
                            ordertofind.Total = num;
                            break;
                        }
                    } while (true);

                    // Display newly edited order and confirm
                    Console.Clear();
                    Console.WriteLine("SUMMARY OF NEWLY EDITED ORDER (YOU MUST CONFIRM TO TAKE EFFECT)");
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

                        manager.EditOrder(ordertofind, date, ordernumber);
                        Console.Write("Order added to the system. Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.Write("Order has been cancelled! Press any key to continue...");
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
