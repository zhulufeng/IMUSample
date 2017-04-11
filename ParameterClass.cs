using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMUSample
{
    class ParameterClass
    {
    }
    class serialParameter
    {
        public static string comName = "COM1";
        public static string baudRate = "38400";
        public static string dataBit = "8";
        public static string stopBit = "1";
        public static string parityBit = "none";
    }
    class serialData
    {
        public static List<byte> buffer = new List<byte>(4096);
        public static UInt16 index = 0;
    }

    class IMUData
    {
        public static Int32[] arrayIMUdata = new Int32[40];
    }
    class PathString
    {
        public static string IMUDataBaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "IMUDATA";
        public static string IMUDataCurrentDirectory = null;
        public static string ClearDirectory = null;
    }
}
