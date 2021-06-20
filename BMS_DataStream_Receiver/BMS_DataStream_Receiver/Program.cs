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
            List<string> batteryData = new List<string>();
            string ReceivedData= GenerateRandomNumber();
            
            int i = 0;
            Console.WriteLine(ReceivedData);
            var inputstream = ReceivedData.Split('\n');
            string value = string.Empty;
               while ((value = Console.ReadLine()) != null)
           // foreach (var value in inputstream)

            {
                if (value != string.Empty && value!=null)
                {
                    i++;
                    OutputParameter OutputParam;
                    batteryData.Add(value);
                    OutputParam = processor.GetMinimumAndMaximumValues(value);
                    Console.WriteLine("Minimum Temperature:{0}\tMaximum Temperature:{1}\tMinimum StateOfCharge:{2}\tMaximum StateOfCharge:{3}", OutputParam.Temperature.Minimum, OutputParam.Temperature.Maximum, OutputParam.StateOfCharge.Minimum, OutputParam.StateOfCharge.Maximum);
                    if (i == 5)
                    {

                        OutputParam = processor.GetMovingAverageValue(batteryData);
                        Console.WriteLine("Temperature Moving Avg.:{0}\n SOC Moving Avg.:{1}\n", OutputParam.Temperature.MovingAverage, OutputParam.StateOfCharge.MovingAverage);

                        batteryData = new List<string>();
                        i = 0;
                    }
                }

            }
            Console.ReadLine();
       
        }

       public static string GenerateRandomNumber()
        {
            Random random_no = new Random();
            string input = string.Empty;
          
            using (StringWriter stringWriter = new StringWriter())
            {
                var originalStream = Console.Out;
                Console.SetOut(stringWriter);
                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine("Temperature=" + random_no.Next(100) + " ,SOC=" + random_no.Next(100));
                }
                input = stringWriter.ToString();
                Console.SetOut(originalStream);
                return input;
            }


        }
    }

}
