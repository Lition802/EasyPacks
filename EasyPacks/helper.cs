using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPacks
{
    class helper
    {
        public static void behavior_packs()
        {
            if (Directory.Exists("behavior_packs"))
            {
                var bedir = new DirectoryInfo("behavior_packs").GetDirectories();
                var beh = new JArray();
                foreach (DirectoryInfo i in bedir)
                {                    
                    if (File.Exists(i.FullName + "\\manifest.json"))
                    {
                        var json = JsonConvert.DeserializeObject<Manifest>(File.ReadAllText(i.FullName + "\\manifest.json"));
                        Program.log("Loading "+json.header.name);
                        var j = new JObject
                        {
                            new JProperty("pack_id", json.header.uuid)
                        };
                        var ve = new JArray();
                        foreach (var it in json.header.version)
                        {
                            ve.Add(it);
                        }
                        j.Add(new JProperty("version", ve));
                        beh.Add(j);
                    }
                }
                File.WriteAllText("world_behavior_packs.json", beh.ToString());
                Program.log("behavior_packs done!");
            }
        }
        public static void resource_packs()
        {
            if (Directory.Exists("resource_packs"))
            {
                var redir = new DirectoryInfo("resource_packs").GetDirectories();
                var res = new JArray();
                foreach (DirectoryInfo i in redir)
                {
                    //Console.WriteLine("[EasyPacks] Loading " + i.FullName + "\\manifest.json");
                    if (File.Exists(i.FullName + "\\manifest.json"))
                    {
                        var json = JsonConvert.DeserializeObject<Manifest>(File.ReadAllText(i.FullName + "\\manifest.json"));
                        Program.log("Loading " + json.header.name);
                        var j = new JObject()
                        {
                            new JProperty("pack_id", json.header.uuid)
                        };
                        var ve = new JArray();
                        foreach (var it in json.header.version)
                        {
                            ve.Add(it);
                        }

                        j.Add(new JProperty("version", ve));
                        res.Add(j);
                    }
                }
                File.WriteAllText("world_resource_packs.json", res.ToString());
                Program.log("resource_packs done!");
            }
        }
        public static void unzip_pack(string name)
        {
            try
            {
                FileInfo file = new FileInfo(name);
                ZipHelper.UnZip(name,".packs\\"+file.Name+"\\");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
