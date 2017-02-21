using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_manager
{
    public class Drive
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public long TotalSize { get; set; }
        public long TotalFreeSpace { get; set; }
        public long AvailableFreeSpace { get; set; }
    }
}
