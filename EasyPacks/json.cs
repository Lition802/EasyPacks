using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPacks
{
    public class Header
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> min_engine_version { get; set; }
    }

    public class Modules
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> version { get; set; }
    }

    public class Manifest
    {
        /// <summary>
        /// 
        /// </summary>
        public int format_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Header header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Modules> modules { get; set; }
    }

    public class Resource
    {
        public string pack_id { get; set; }
        public List<int> version { get; set; }
    }
}
