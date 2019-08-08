using System;
using System.IO;

namespace TextClass
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class TextMethods
    {
        public static void PrintOddLine(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            String str;
            using(reader)
            {
                try
                {
                    str = reader.ReadLine();
                    int lineCount = 1;
                    while ( str != null)
                    {
                        if (lineCount % 2 == 1) Console.WriteLine(str);
                        str = reader.ReadLine();
                        lineCount++;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void AddLineCount(string inputfile, string outputfile)
        {
            StreamReader reader = new StreamReader(inputfile);
            StreamWriter writer = new StreamWriter(outputfile);
            String str;
            int lineCount = 1;
            using(reader)
            using(writer)
            {
                try
                {
                    str = reader.ReadLine();
                    while(str != null)
                    {
                        str = lineCount + " " + str;
                        writer.WriteLine(str);
                        lineCount++;
                        str = reader.ReadLine();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void SortByLine(string inputfile, string outputfile)
        {
            StreamReader reader = new StreamReader(inputfile);
            StreamWriter writer = new StreamWriter(outputfile);
            using(reader)
            using(writer)
            {
                String str = reader.ReadToEnd();
                String[] strList = str.Split('\n');
                Array.Sort(strList);
                foreach(String s in strList)
                {
                    writer.WriteLine(s);
                }
            }
        }
    }
}
