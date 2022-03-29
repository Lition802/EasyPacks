using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyPacks
{
    class Program
    {
        public static void log(object o)
        {
            Console.WriteLine($"[{DateTime.Now}] {o?.ToString()}");
        }
        static void Main(string[] args)
        {
            log("EasyPacks v2.1.0");
            Directory.CreateDirectory("behavior_packs");
            Directory.CreateDirectory("resource_packs");
            if(args.Length == 0)
            {
                helper.behavior_packs();
                helper.resource_packs();
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                Environment.Exit(0);
            }
            if(args[0].EndsWith("mcaddon") || args[0].EndsWith("mcpack") || args[0].EndsWith("zip"))
            {
                log($"unzip {args[0]}");
                ZipHelper.UnZip(args[0],args[0]+".unzip");
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }     
}
