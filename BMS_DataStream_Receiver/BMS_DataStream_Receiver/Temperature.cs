using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
    public class Temperature
    {
        private float min = float.MaxValue;
        private float max = float.MinValue;
        public float MovingAverage { get; set; }
        public float Minimum
        {
            get { return min; }set { min = value; }
        }
       public float Maximum
        {
            get { return max; } set { max = value; }
        }
      
    }
}
