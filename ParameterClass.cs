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
        public static int Upd_rate = 50;
        public static bool isTest = true;
    }
    class serialData
    {
        public static List<byte> buffer = new List<byte>(4096);
        public static UInt16 index = 0;
    }

    class IMUData
    {
        public static double[] arrayIMUdata = new double[46];
        public static List <double>ListFogxData = new List<double>();
        public static List<double> ListFogyData = new List<double>();
        public static List<double> ListFogzData = new List<double>();

        public static List<double> ListFogxData_BC = new List<double>();
        public static List<double> ListFogyData_BC = new List<double>();
        public static List<double> ListFogzData_BC = new List<double>();

        public static List<double> ListAccxData = new List<double>();
        public static List<double> ListAccyData = new List<double>();
        public static List<double> ListAcczData = new List<double>();

        public static List<double> ListTemFogxData = new List<double>();
        public static List<double> ListTemFogyData = new List<double>();
        public static List<double> ListTemFogzData = new List<double>();

        public static List<double> ListTemAccxData = new List<double>();
        public static List<double> ListTemAccyData = new List<double>();
        public static List<double> ListTemAcczData = new List<double>();

        public static List<double> ListFogxData_1s = new List<double>();
        public static List<double> ListFogyData_1s = new List<double>();
        public static List<double> ListFogzData_1s = new List<double>();

        public static List<double> ListFogxData_1s_BC = new List<double>();
        public static List<double> ListFogyData_1s_BC = new List<double>();
        public static List<double> ListFogzData_1s_BC = new List<double>();

        public static List<double> ListAccxData_1s = new List<double>();
        public static List<double> ListAccyData_1s = new List<double>();
        public static List<double> ListAcczData_1s = new List<double>();

        public static List<double> ListTemFogxData_1s = new List<double>();
        public static List<double> ListTemFogyData_1s = new List<double>();
        public static List<double> ListTemFogzData_1s = new List<double>();

        public static List<double> ListTemAccxData_1s = new List<double>();
        public static List<double> ListTemAccyData_1s = new List<double>();
        public static List<double> ListTemAcczData_1s = new List<double>();

        public static double[] data_1s = new double[19];
        public static byte[] arrayOriginData = new byte[50];
        public static int[] intFogData = new int[3];
        public static int[] intFogTmp = new int[3];
        public static int[] intFogData_BC = new int[3];
        public static int[] intAccData = new int[3];
        public static int[] intAccTmp = new int[3];
        public static int Counter;
        public static int TotalCounter;
        public static int Timer_cyc;
        public static double[] doubleFogData = new double[3];
        public static double[] doubleFogTmp = new double[3];
        public static double[] doubleAccData = new double[3];
        public static double[] doubleAccTmp = new double[3];
        public static float[] floatAccData = new float[3];
        public static float[] floatAccTmp = new float[3];
        public static float[] floatFogData = new float[3];
        public static float[] floatFogData_BC = new float[3];
        public static double Fogx_SF, Fogy_SF, Fogz_SF;
        public static double[] Fog_SF   = new double[3];
        public static double[] Fog_Bias = new double[3];

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
