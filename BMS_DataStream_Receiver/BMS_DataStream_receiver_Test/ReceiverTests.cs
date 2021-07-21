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
        public void GetMaximumValues_ValidReturnValue()
        {
            IDataStreamReceiver receiver = new DataStreamReceiver();
            IDataProcessor processor = new DataProcessor(receiver);
            OutputParameter result=new OutputParameter();
            List<string> TestdataList = GenerateRandomNumber();
            foreach (var inputRow in TestdataList)
            {
                result = processor.GetMinimumAndMaximumValues(inputRow);
            }
            Assert.IsTrue(result.StateOfCharge.Maximum==98 && result.Temperature.Maximum == 77);
        }

        [TestMethod]
        public void GetMinimumValues_ValidReturnValue()
        {
            IDataStreamReceiver streamReceiver = new DataStreamReceiver();
            IDataProcessor dataProcessor = new DataProcessor(streamReceiver);
            OutputParameter outputParam = new OutputParameter();
            List<string> TestdataList = GenerateRandomNumber();
            foreach (var inputRow in TestdataList)
            {
                if(inputRow!=string.Empty)
                outputParam = dataProcessor.GetMinimumAndMaximumValues(inputRow);
            }
            Assert.IsTrue(outputParam.StateOfCharge.Minimum == 56 && outputParam.Temperature.Minimum == 10);
        }
        [TestMethod]
        public void GetMinimumAndMaximumValues_InvalidInput_ValidReturnValue()
        {
            IDataStreamReceiver receiver = new DataStreamReceiver();
            IDataProcessor processor = new DataProcessor(receiver);
            OutputParameter result;
            List<string> TestdataList = GenerateRandomNumber();
            result = processor.GetMinimumAndMaximumValues(null);
            Assert.IsTrue(result.StateOfCharge.Maximum == float.MinValue && result.Temperature.Maximum == float.MinValue&& result.StateOfCharge.Minimum==float.MaxValue&&result.Temperature.Minimum==float.MaxValue);
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
