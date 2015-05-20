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
            string fileToRead = @"E:\Fundamentials\FilesAndStreams\HomeworksProjects\text.txt";
            StreamReader read = new StreamReader(fileToRead);
            int rowCounter = 0;
            while(!read.EndOfStream)
            {
                string readLine = read.ReadLine();
                if(rowCounter%2==0)
                {
                    Console.WriteLine(readLine);
                }
                rowCounter++;
            }
        }
    }
}
