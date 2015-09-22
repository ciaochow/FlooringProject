using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Data;



namespace FlooringProgram.BLL
{
    public class OrderManager
    {
        private IRepo _repo;

        public OrderManager()
        {
            string mode = ConfigurationManager.AppSettings["appName"];
            if (mode == "Test")
            {
                var repo = new TestOrderRepo();
                repo.LoadOrders();
                _repo = repo;
            }
            else
            {
                //var repo = new 
            }

        }

        public Response<DisplayOrderReceipt> DisplayOrders(int date)
        {
            var response = new Response<DisplayOrderReceipt>();
            var repo = _repo;
            var orders = repo.LoadOrders();

            try
            {
                if (orders.Count == 0)
                {
                    response.Success = false;
                    response.Message = "No orders were found with that date.";
                }
                else
                {
                    response.Success = true;
                    //sponse.Message = "";
                    response.Data = new DisplayOrderReceipt();
                    response.Data.Date = date;
                    response.Data.Orders = orders;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
