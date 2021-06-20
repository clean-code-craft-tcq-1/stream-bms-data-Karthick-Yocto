using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_DataStream_Receiver
{
   public interface IDataProcessor
    {
        OutputParameter GetMovingAverageValue(List<string> batteryInputParameters);
        OutputParameter GetMinimumAndMaximumValues(string batteryParameter);
      
       
    }
}
