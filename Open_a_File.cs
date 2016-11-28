using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OpenFiles
{
    class Test
    {
        static void Main(string[] args)
        {
            //the @ is used in order not to have to escape weird characters
            string filePath = @"C:\Users\vc2.sophia\Downloads\Mytext.txt";

            //if the file already exists, we delete it
            if (File.Exists(filePath))
                {
                File.Delete(filePath);
            }
            //create the file
            using (FileStream fs = File.Create(filePath))
            {
                //We create an array in which we put the bytes of the string info
                Byte[] info = new UTF8Encoding(true).GetBytes("This is a weird way to write to a file ");
               
                //we write in the filestream the text represented by info starting at char zero and ending at the end of the string
                fs.Write(info, 0, info.Length);
            }
            //read the file
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                //create an empty array
                byte[] b = new byte[1024];

                //create an encoder object
                UTF8Encoding temp = new UTF8Encoding(true);
                
                //read the stream until exhaustion of the bytes and print them in the Console
                while(fs.Read(b,0,b.Length)>0)
                {
                    Console.WriteLine(temp.GetString(b));
                } 
            }
        }
    }
}
