﻿using System;
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
        public static double[] arrayIMUdata = new double[42];

        public static byte[] arrayOriginData = new byte[42];
        public static int[] intFogData = new int[3];
        public static int[] intFogTmp = new int[3];
        public static int[] intAccData = new int[3];
        public static int[] intAccTmp = new int[3];
        public static int Counter;
        public static int TotalCounter;
        public static int Timer_cyc;
        public static double[] doubleFogData = new double[3];
        public static double[] doubleFogTmp = new double[3];
        public static double[] doubleAccData = new double[3];
        public static double[] doubleAccTmp = new double[3];

    }

    class PathString
    {
        public static string IMUDataBaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "IMUDATA";
        public static string IMUDataCurrentDirectory = null;
        public static string ClearDirectory = null;
    }
    class clsIMUCalidata
    {
        public Matrix GyroBias = new Matrix(3, 1);
        public Matrix GyroSF = new Matrix(3, 1);
        public Matrix GyroMA = new Matrix(3, 3);

        public Matrix AccBias = new Matrix(3, 1);
        public Matrix AccSF = new Matrix(3, 1);
        public Matrix AccMA = new Matrix(3, 3);

    }
}
