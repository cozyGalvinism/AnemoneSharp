using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownfishAPI;

namespace AnemoneSharp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path of an audio file: ");
            string filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("This file does not exist!");
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
                return;
            }

            ClownfishHandler handler = new ClownfishHandler();
            handler.PlayFile(filePath);
        }
    }
}
