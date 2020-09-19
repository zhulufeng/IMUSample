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
        public static bool isHighFreq = false;
        public static bool isSaveHex = false;
        public static string IMU_id = "001";
    }
    class serialData
    {
        public static List<byte> buffer = new List<byte>(4096);
        public static UInt16 index = 0;
    }

    class IMUData
    {
        public  double[] arrayIMUdata = new double[99];
        public  List <double>ListFogxData = new List<double>();
        public  List<double> ListFogyData = new List<double>();
        public  List<double> ListFogzData = new List<double>();

        public  List<double> ListAccxData = new List<double>();
        public  List<double> ListAccyData = new List<double>();
        public  List<double> ListAcczData = new List<double>();

        public List<double> ListfpxData = new List<double>();
        public List<double> ListfpyData = new List<double>();
        public List<double> ListfpzData = new List<double>();

        public  List<double> ListTemFogxData = new List<double>();
        public  List<double> ListTemFogyData = new List<double>();
        public  List<double> ListTemFogzData = new List<double>();

        public  List<double> ListTemAccxData = new List<double>();
        public  List<double> ListTemAccyData = new List<double>();
        public  List<double> ListTemAcczData = new List<double>();

        public List<double> ListAttxData = new List<double>();
        public List<double> ListAttyData = new List<double>();
        public List<double> ListAttzData = new List<double>();

        public  List<double> ListFogxData_1s = new List<double>();
        public  List<double> ListFogyData_1s = new List<double>();
        public  List<double> ListFogzData_1s = new List<double>();

        public  List<double> ListAccxData_1s = new List<double>();
        public  List<double> ListAccyData_1s = new List<double>();
        public  List<double> ListAcczData_1s = new List<double>();

        public  List<double> ListTemFogxData_1s = new List<double>();
        public  List<double> ListTemFogyData_1s = new List<double>();
        public  List<double> ListTemFogzData_1s = new List<double>();

        public  List<double> ListTemAccxData_1s = new List<double>();
        public  List<double> ListTemAccyData_1s = new List<double>();
        public  List<double> ListTemAcczData_1s = new List<double>();

        public  double[] data_1s = new double[99];
        public  byte[] arrayOriginData = new byte[99];
        public byte[] arrayStatusData = new byte[6];
        public  int[] intFogData = new int[3];
        public  int[] intAttData = new int[3];
        public  int[] intFogTmp = new int[3];
        public  int[] intAccData = new int[3];
        public  int[] intfpData = new int[3];
        public  int[] intAccTmp = new int[3];
        public  int Counter;
        public  int TotalCounter;
        public  int Timer_cyc;
        public int nav_state;
        public  double[] doubleFogData = new double[3];
        public  double[] doubleAttData = new double[3];
        public  double[] doubleFogTmp = new double[3];
        public  double[] doubleAccData = new double[3];
        public  double[] doublefpData = new double[3];
        public  double[] doubleAccTmp = new double[3];
        public  float[] floatAccData = new float[3];
        public  float[] floatfpData = new float[3];
        public  float[] floatAccTmp = new float[3];
    }

    class PathString
    {
        public static string IMUDataBaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "IMUDATA";
        public static string IMUDataCurrentDirectory = null;
        public static string ClearDirectory = null;
    }
    class TimePara
    {
        public int total_time = 0;
        public int dt;
        public int sampleFreq = 1000;
        public int drawCount = 0;
        public int testTimes = 0;
        public List<double> drawIndexTime = new List<double>();
    }
}
