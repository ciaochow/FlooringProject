using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            var date = GetDate();

        }

        private int GetDate()
        {
            do
            {
                Console.Write("Enter date of orders to display (MMDDYYYY): ");
                string input = Console.ReadLine();
                int num;
                bool parsedinput = int.TryParse(input, out num);
                if (parsedinput)
                {
                    num = int.Parse(input);
                    return num;
                }
            } while (true);
        }
    }
}
