using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Open_a_text_File
{
    class Test
    {
        //Mapper 
        //1.Cleaner
        public String cleanText(string input)
        {
            var fixedInput = Regex.Replace(input, "[^a-zA-Z .]", " ");
            String newInput = fixedInput.Replace("\"", "").Replace(".", " ");
            return (newInput);
        }

        //2.Splitter
        public String[] splitText(char splitter, string input)
        {
            String[] Words = input.Split(splitter);
            return (Words);
        }

        //3. Sorter
        public String[] sortText(String[] text_array)
        {
            Array.Sort(text_array);
            return (text_array);
        }

        //4. Saver to disk
        public void display_l(string[] input_array)
        {
            String[] str = { ".", "," };

            // this is the mapped+sorted file before redcution - please feel free to modify Be careful if you modify here(+)
            //you must modify below - when the file is called

            using (StreamWriter outputFile = new StreamWriter(@"C:\Users\vc2.sophia\Downloads\Assan tutos\WriteLines.txt"))
            {
                foreach (string w in input_array)
                {
                    if ((w.Split(',')[0] != str[0]) || (w.Split(',')[0] != str[1]) || (String.IsNullOrEmpty(w.Split(',')[0])))
                    {
                        outputFile.WriteLine(w + ",1");
                    }
                }
            }
        }

        //5.Reducer part
        public void read_l(StreamReader s)
        {
            int my_total = 0;
            String my_oldkey = "Welcome to Map reduce in C# !!!";
            String my_text = "";

            //this is the destination file - please feel free to modify
            using (StreamWriter mpr = new StreamWriter(@"C:\Users\vc2.sophia\Downloads\Assan tutos\Mapreduced.txt"))
            {
                // this is the mapped+sorted file before redcution - please feel free to modify(++)
                using (StreamReader s_i = new StreamReader(@"C:\Users\vc2.sophia\Downloads\Assan tutos\WriteLines.txt"))
                {
                    while (s_i.Peek() >= 0)
                    {
                        //Console.WriteLine(s_i.ReadLine());
                        {
                            //Console.WriteLine(sr.ReadLine());

                            my_text = s_i.ReadLine().Split(',')[0];
                            int anum = 0;
                            Int32.TryParse((s_i.ReadLine().Split(',')[1]), out anum);

                            if (my_text != my_oldkey)
                            {
                                Console.WriteLine(my_oldkey + "," + my_total);
                                mpr.WriteLine(my_oldkey + "," + my_total);

                                my_total = 0;
                                my_oldkey = my_text;
                            }

                            my_oldkey = my_text;
                            my_total = my_total + anum;
                        }
                    }
                    Console.WriteLine(my_oldkey + "," + my_total);
                    mpr.WriteLine(my_oldkey + "," + my_total);
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Test t = new Test();
                using (StreamReader str = new StreamReader(@"C:\Users\vc2.sophia\Downloads\Assan tutos\Mytext2.txt"))
                {
                    String line = str.ReadToEnd();
                    String line2 = t.cleanText(line);
                    String[] words = t.splitText(' ', line2);

                    t.sortText(words);
                    t.display_l(words);
                }
                StreamReader sr = new StreamReader(@"C:\Users\vc2.sophia\Downloads\Assan tutos\WriteLines.txt");
                t.read_l(sr);
            }
            catch (Exception e)
            {
                Console.WriteLine("the file could not be read.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
