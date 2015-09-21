using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;



namespace FlooringProgram.BLL
{
    public class OrderManager
    {
        public OrderManager()
        {
            
        }

        public Response<DisplayOrderReceipt> DisplayOrders(int date)
        {
            var response = new Response<DisplayOrderReceipt>();

            try
            {
                var displayorders = /// repo.displayorders(date);
                    
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
