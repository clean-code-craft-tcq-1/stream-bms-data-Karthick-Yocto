using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
  public  class DataProcessor:IDataProcessor
    {
        private OutputParameter OutPutParameters;
        private IDataStreamReceiver reveiverParser;

        public DataProcessor(IDataStreamReceiver _reveiverpParser)
        {
            reveiverParser = _reveiverpParser;
            OutPutParameters = new OutputParameter();
        }
        public OutputParameter GetMovingAverageValue(List<string> batteryInputParameters)
        {
            List<BatteryParameters> batteryParameters = reveiverParser.ParseRawDataStream(batteryInputParameters);
          
            if (batteryParameters.Count <= 0)
                return OutPutParameters;
         
            OutPutParameters.Temperature.MovingAverage = batteryParameters.Average(item => item.Temperature);
            OutPutParameters.StateOfCharge.MovingAverage =batteryParameters.Average(item => item.StateOfCharge);


            return OutPutParameters;
        }

        public OutputParameter GetMinimumAndMaximumValues(string batteryParameter)
        {
            if (batteryParameter != null)
            {
                List<BatteryParameters> batteryParameters = reveiverParser.ParseRawDataStream(new List<string>() { batteryParameter });
                OutPutParameters.Temperature.Minimum = Math.Min(OutPutParameters.Temperature.Minimum, batteryParameters[0].Temperature);
                OutPutParameters.StateOfCharge.Minimum = Math.Min(OutPutParameters.StateOfCharge.Minimum, batteryParameters[0].StateOfCharge);
                OutPutParameters.Temperature.Maximum = Math.Max(OutPutParameters.Temperature.Maximum, batteryParameters[0].Temperature);
                OutPutParameters.StateOfCharge.Maximum = Math.Max(OutPutParameters.StateOfCharge.Maximum, batteryParameters[0].StateOfCharge);
            }
            return OutPutParameters;
        }


    }
}
