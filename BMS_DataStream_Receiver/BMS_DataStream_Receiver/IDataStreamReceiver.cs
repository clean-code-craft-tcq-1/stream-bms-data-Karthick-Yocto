using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
   public interface IDataStreamReceiver
    {
       List< BatteryParameters> ParseRawDataStream(List<string> rawInput);
    }
}
