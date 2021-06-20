using System;
using System.Collections.Generic;
using System.IO;
using BMS_DataStream_Receiver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMS_DataStream_receiver_Test
{
    [TestClass]
    public class ReceiverTests
    {

        [TestMethod]
        public void GetMinimumAndMaximumValues_ValidReturnValue()
        {
            IDataStreamReceiver receiver = new DataStreamReceiver();
            IDataProcessor processor = new DataProcessor(receiver);
            OutputParameter result;
            List<string> TestdataList = GenerateRandomNumber();
             result = processor.GetMinimumAndMaximumValues(TestdataList[0]);
            Assert.IsTrue(result.StateOfCharge.Maximum==76 && result.Temperature.Maximum == 10);
        }
     
        [TestMethod]
        public void GetMovingAverageValue_ValidInput_ValidReturnValue()
        {
            IDataStreamReceiver receiver = new DataStreamReceiver();
            IDataProcessor processor = new DataProcessor(receiver);
            OutputParameter result;
            List<string> TestdataList = GenerateRandomNumber();
            result = processor.GetMovingAverageValue(TestdataList);
            Assert.IsFalse(result.StateOfCharge.MovingAverage == float.MaxValue && result.Temperature.MovingAverage == float.MaxValue);
        }

        [TestMethod]
        public void ParseRawDataStream_ValidInput_ValidReturnValue()
        {
            IDataStreamReceiver receiver = new DataStreamReceiver();
            IDataProcessor processor = new DataProcessor(receiver);
            IList<BatteryParameters> result;
            List<string> TestdataList = GenerateRandomNumber();
            result = receiver.ParseRawDataStream(TestdataList);
            Assert.IsInstanceOfType(result, typeof(IList<BatteryParameters>));
        }


        public List<string> GenerateRandomNumber()
        {
         
            List<string> teststring = new List<string>();
            teststring.Add("Temperature=10,SOC=76");
            teststring.Add("Temperature=33,SOC=88.7");
            teststring.Add("Temperature=54,SOC=57");
            teststring.Add("Temperature=36,SOC=56");
            teststring.Add("Temperature=77,SOC=89");
            teststring.Add("Temperature=24,SOC=98");
            return teststring;


        }
    }
}
