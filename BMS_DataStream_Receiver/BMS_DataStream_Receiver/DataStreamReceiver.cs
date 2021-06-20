using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
    public class DataStreamReceiver : IDataStreamReceiver
    {
        public List<BatteryParameters> ParseRawDataStream(List<string> rawInput)
        {
            List<BatteryParameters> batteryParameters = new List<BatteryParameters>();
            BatteryParameters Parameobj = new BatteryParameters();
            if (rawInput != null)
            {
            var ParameterValue = Regex.Matches(rawInput[0], @"\d+\.?\d*").Cast<Match>().Select(x => float.Parse(x.Value)).ToArray();
                if (ParameterValue.Length == 2)
                {

                    Parameobj.Temperature = ParameterValue[0];
                    Parameobj.StateOfCharge = ParameterValue[1];
                }
                batteryParameters.Add(Parameobj);
            }
         return batteryParameters;
        }
    }
}
