using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeDay1Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\Mykola\\Pictures\\input.txt";
            string[] textArray = ReadTextFromFile(filePath);
            if (textArray.Length == 0)
            {
                Console.Error.WriteLine("No text was found in the text file");
                return;
            }
            List<int> masses = Values(textArray);
            int fuelNeeded = 0;
            
            foreach (int mass in masses)
            {
                fuelNeeded += CalculateFuel(mass);
            }
            Console.WriteLine(fuelNeeded);
        }

        static int CalculateFuel(int mass)
        {
            int fuel;
            fuel = (int)Math.Floor(mass / 3.0f) - 2;
            if (fuel < 0)
            {
                return 0;
            }
            else if (fuel > 2)
            {
                return fuel += CalculateFuel(fuel);
            }
            else
                return fuel;
        }

        static List<int> Values(string[] textArray)
        {
            List<int> masses = new List<int>();
            masses.Capacity = 12;//pre-alocates memory
            foreach (string tempString in textArray)
            {
                int intCheck;
                if (int.TryParse(tempString, out intCheck))
                {
                    masses.Add(intCheck);
                }
            }
            return masses;
        }

        static string[] ReadTextFromFile(string filePath)
        {
            StreamReader input = new StreamReader(File.OpenRead(filePath));
            if (input == null)
            {
                Console.Error.WriteLine("No input exists");
                string[] error = new string[0];
                return error;
            }
            else
            {
                string longTextString = input.ReadToEnd();
                string[] tempStringArray = longTextString.Split("\n");
                return tempStringArray;
            }
        }
    }
}
