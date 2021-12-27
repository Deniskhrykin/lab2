using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class MyFileInfo
    {
        public string FileName { get; set; }
        public int Length { get; set; }

        public MyFileInfo(string filename, int length)
        {
            FileName = filename;
            Length = length;
        }
    }
}
