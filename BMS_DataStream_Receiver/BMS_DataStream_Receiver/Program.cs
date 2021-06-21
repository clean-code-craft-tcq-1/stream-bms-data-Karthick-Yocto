using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataStreamReceiver receiver = new DataStreamReceiver();
            IDataProcessor processor = new DataProcessor(receiver);
            List<string> MovingDataList = new List<string>();
          
            int i = 0;
        
            string value = string.Empty;
               while ((value = Console.ReadLine()) != null)

            {
                if (value != string.Empty && value!=null)
                {
                    i++;
                    OutputParameter OutputParam;
                    MovingDataList.Add(value);
                    OutputParam = processor.GetMinimumAndMaximumValues(value);
                    Console.WriteLine("Minimum Temperature:{0}\tMaximum Temperature:{1}\tMinimum StateOfCharge:{2}\tMaximum StateOfCharge:{3}", OutputParam.Temperature.Minimum, OutputParam.Temperature.Maximum, OutputParam.StateOfCharge.Minimum, OutputParam.StateOfCharge.Maximum);
                    if (i == 5)
                    {

                        OutputParam = processor.GetMovingAverageValue(MovingDataList);
                        Console.WriteLine("Temperature Moving Avg.:{0}\n SOC Moving Avg.:{1}\n", OutputParam.Temperature.MovingAverage, OutputParam.StateOfCharge.MovingAverage);

                        MovingDataList = new List<string>();
                        i = 0;
                    }
                }

            }
            Console.ReadLine();
       
        }

    }

}
