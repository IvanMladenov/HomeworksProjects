using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P5_SliceFile
{
    class SliceFile
    {
        static void Main()
        {
            string fileSource=@"../../file.jpg";
            string destination = @"../../";
            string assemble = @"../../new.jpg";

            int parts = int.Parse(Console.ReadLine());

            List<string> slices = Slice(fileSource,destination,parts);

            Assemble(slices, assemble);
        }

        static void Assemble(List<string>files, string destination)
        {
            for (int i = 0; i < files.Count; i++)
            {
                using(FileStream assemble=new FileStream(files[i],FileMode.Open))
                {
                    using(FileStream newFile=new FileStream(destination,i==0?FileMode.Create:FileMode.Append))
                    {
                        byte[] buffer = new byte[files[i].Length];
                        assemble.Read(buffer, 0, buffer.Length);
                        newFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static List<string> Slice(string sourseFile, string destinationDirectory,int parts)
        {
            List<string> slices = new List<string>();
            using(FileStream sourse=new FileStream(sourseFile,FileMode.Open) )
            {
                long sliceSize = sourseFile.Length / parts;
                long left = sourseFile.Length - sliceSize * parts;
                
                    for (int i = 1; i <= parts; i++)
                    {
                        slices.Add(string.Format("../../Slice{0}.jpg", i));
                        using (FileStream create = new FileStream(string.Format(destinationDirectory+"Slice{0}.jpg", i), FileMode.Create))                        
                        {
                            sliceSize = (i < parts) ? sliceSize : sliceSize + left;
                            byte[] buffer = new byte[sliceSize];
                            sourse.Read(buffer, 0, buffer.Length);
                            create.Write(buffer, 0, buffer.Length);
                        }
                    }                
            }
            return slices;
        }
    }
}
