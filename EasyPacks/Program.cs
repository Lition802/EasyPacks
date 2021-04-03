using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;

namespace EasyPacks
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(@"    ______                 ____             __       
   / ____/___ ________  __/ __ \____ ______/ /_______
  / __/ / __ `/ ___/ / / / /_/ / __ `/ ___/ //_/ ___/
 / /___/ /_/ (__  ) /_/ / ____/ /_/ / /__/ ,< (__  ) 
/_____/\__,_/____/\__, /_/    \__,_/\___/_/|_/____/  
                 /____/                             ");
            DirectoryInfo bedir = new DirectoryInfo("behavior_packs");
            DirectoryInfo redir = new DirectoryInfo("resource_packs");
            DirectoryInfo[] dirinfos = bedir.GetDirectories();
            DirectoryInfo[] dirinfos2 = redir.GetDirectories();
            var behavior = new List<Resource>();
            var resource = new List<Resource>();
            if(bedir.Exists)
            {
                foreach (DirectoryInfo i in dirinfos)
                {
                    Console.WriteLine("[EasyPacks] Loading " + i.FullName + "\\manifest.json");
                    if (File.Exists(i.FullName + "\\manifest.json"))
                    {
                        var json = JsonConvert.DeserializeObject<Manifest>(File.ReadAllText(i.FullName + "\\manifest.json"));
                        var tmp = new Resource()
                        {
                            pack_id = json.header.uuid,
                            version = json.header.version
                        };
                        behavior.Add(tmp);
                    }
                }
            }           
            if(redir.Exists)
            {
                foreach (DirectoryInfo i in dirinfos2)
                {
                    Console.WriteLine("[EasyPacks] Loading " + i.FullName + "\\manifest.json");
                    if (File.Exists(i.FullName + "\\manifest.json"))
                    {
                        var json = JsonConvert.DeserializeObject<Manifest>(File.ReadAllText(i.FullName + "\\manifest.json"));
                        var tmp = new Resource()
                        {
                            pack_id = json.header.uuid,
                            version = json.header.version
                        };
                        resource.Add(tmp);
                    }
                }
            }        
            if(File.Exists("world_behavior_packs.json"))
            {
                Computer my = new Computer();
                my.FileSystem.RenameFile("world_behavior_packs.json", "world_behavior_packs_old.json");
            }
            if (File.Exists("world_resource_packs.json"))
            {
                Computer my = new Computer();
                my.FileSystem.RenameFile("world_resource_packs.json", "world_resource_packs_old.json");
            }
            File.WriteAllText("world_behavior_packs.json", JsonConvert.SerializeObject(behavior));
            File.WriteAllText("world_resource_packs.json", JsonConvert.SerializeObject(resource));
            Console.WriteLine("[EasyPacks] json file generated successfully！");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
