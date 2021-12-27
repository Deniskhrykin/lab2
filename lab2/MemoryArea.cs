using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class MemoryArea
    {
        public int Total 
        {
            get { return _total; } 
        }

        public int Busy
        {
            get { return File != null ? File.Length : 0; }
        }

        public bool IsAvailable
        {
            get { return File == null; }
        }

        public MyFileInfo File { get; private set; }

        public MemoryArea(MyFileInfo file)
        {
            File  = file;
            _total = file.Length;           
        }

        public void WriteFile(MyFileInfo file)
        {
            File = file;           
        }

        public void Clear()
        {
            File = null;
        }

        readonly int _total;     

       
    }
}
