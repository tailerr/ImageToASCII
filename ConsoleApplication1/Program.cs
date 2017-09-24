using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 3 || args[0]=="-help")
                {
                    help();
                    return;

                }
                string filename = args[0];
                string path = args[1];
                double k = Convert.ToDouble(args[2]);
                if (k<=0 || k > 1)
                {
                    Console.WriteLine("k value should be in (0, 1]");
                    Console.ReadLine();
                    return;
                }
                if (args.Length < 4)
                {
                    converter conv = new converter(filename, path, k);
                    conv.procces(path);
                }
                else
                {
                    string alf = ' '+args[3];
                    converter conv = new converter(filename, path, k, alf);
                    conv.procces(path);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("wrong type of values");
                Console.ReadKey();
            }
            catch (IOException)
            {
                Console.WriteLine("file or directory does not exist");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("check your input");
                Console.ReadKey();
            }
            
        }

        static void help()
        {
            Console.WriteLine("HELP");
            Console.WriteLine("This program needs three required parametrs and one optional:");
            Console.WriteLine("First is a path to image you want to convert");
            Console.WriteLine("    supported formats:  BMP, GIF, EXIF, JPG, PNG и TIFF");
            Console.WriteLine("Second is a path where program will save output");
            Console.WriteLine("    supported formats: text formats");
            Console.WriteLine("Third is a compression parametr defined in (0, 1] (1=full size)");
            Console.WriteLine("Last optional is an alphabet of ASCII symbols ordered from white to black");
            Console.WriteLine("    space to alphabet adds automatically");
            Console.ReadLine();
            
        }
    }
}
