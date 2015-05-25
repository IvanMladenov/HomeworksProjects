using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P1_OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToRead = @"..\..\..\..\text.txt";
            StreamReader read = new StreamReader(fileToRead);
            StreamWriter write = new StreamWriter("../../../../result.txt");
            int rowCounter = 1;
            while (!read.EndOfStream)
            {
                string readLine = read.ReadLine();
                StringBuilder str = new StringBuilder();
                str.Append(rowCounter+".");
                str.Append(readLine);
                write.WriteLine(str.ToString());
                Console.WriteLine(str.ToString());
                rowCounter++;
            }
        }
    }
}
