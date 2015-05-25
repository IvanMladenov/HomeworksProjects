using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P4_CopyBinaryFail
{
    class CopyBinaryFail
    {
        static void Main(string[] args)
        {
            string filePath = @"../../file.jpg";
            string copiedFile = @"../../Empty.jpg";

            using(FileStream stream=new FileStream(filePath,FileMode.Open))
            {
                using(FileStream create=new FileStream(copiedFile,FileMode.CreateNew))
                {
                    byte[] buffer = new byte[4096];
                    while(true)
                    {
                        int readBytes = stream.Read(buffer, 0, buffer.Length);
                        if(readBytes==0)
                        {
                            break;
                        }
                        create.Write(buffer, 0, readBytes);
                    }
                }
            }

        }
    }
}
