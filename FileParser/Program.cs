﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Application(args).Run();

            Console.ReadKey();
        }
    }
}
