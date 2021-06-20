using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
    public class OutputParameter
    {
        public OutputParameter()
        {
            Temperature = new Temperature();
            StateOfCharge = new StateOfCharge();
        }
        public Temperature Temperature { get; set; }
        public StateOfCharge StateOfCharge { get; set; }
    }
}
