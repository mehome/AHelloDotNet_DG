﻿using QX_Frame.Helper_DG;
using QX_Frame.Helper_DG.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ConsoleApp1.NETFramework461
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File_Helper_DG.Json_GetJObjectFromJsonFile("123.json")["data"][1]["loginId"].ToString();
            Console.WriteLine(data);


            Console.WriteLine("any key to exit ...");
            Console.ReadKey();
        }
    }
}