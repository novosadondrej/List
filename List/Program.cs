using System;
using System.Text.RegularExpressions;
using SautinSoft.Document;
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace List
{
    class Program
    {
        static void Main(string[] args)
        {

            //               na každém zařízení jiná cesta
            string path = @"C:\Users\novosad.ondrej.2017\Desktop\skola\PVA\4.A\List\List\bin\Debug\netcoreapp3.1\ThreeMenInABoatEnglish.txt";

            int lineNumber = 0;
            char[] spliter = new char[] { ',', ' ', '-', '_', ':' };
            List<string> lines = File.ReadAllLines(path).ToList();
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                lineNumber++;
                string[] pole = line.Split(spliter);
                foreach (var slovo in pole)
                {
                    if (result.ContainsKey(slovo))
                    {
                        result[slovo] = result[slovo] + Convert.ToString(lineNumber) + ", ";
                    }
                    else
                    {
                        result.Add(slovo, Convert.ToString(lineNumber) + ", ");
                    }
                }
            }
            FileStream fs = new FileStream("soubor.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var item in result.Keys)
            {
                Console.WriteLine($"{item}: {result[item]}");
                sw.WriteLine($"{item}: {result[item]}");
            }
            sw.Close();
            fs.Close();

            Console.ReadLine();
        }
       
    }
}
