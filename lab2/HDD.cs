using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class HDD
    {
        public int Total
        {
            get { return _total; }
        }

        public int Busy
        {
            get { return memory.Where(m => !m.IsAvailable).Sum(m => m.Total); }
        }

        public int Available
        {
            get { return _total - Busy; }
        }        

        public int Unallocated
        {
            get { return _total - memory.Sum(m => m.Total); }
        }

        public HDD()
        {
            memory = new List<MemoryArea>();
        }

        public bool Write(MyFileInfo file)
        {
            var area = memory.FirstOrDefault(m => m.IsAvailable && file.Length <= m.Total);
            if (area != null)
            {
                area.WriteFile(file);
                return true;
            }
            else if (file.Length <= Unallocated)
            {
                memory.Add(new MemoryArea(file));
                return true;
            }
            return false;           
        }

        public bool Delete(MyFileInfo file)
        {
            var area = memory.FirstOrDefault(m => m.File.FileName == file.FileName && m.File.Length == file.Length);
            
            if (area != null)
            {
                area.Clear();
                return true;
            }

            return false;
        }


        public string GetInfo()
        {
            string result = "\nУчастки памяти: \n";
            for (int i = 0; i < memory.Count; i++)
            {
                var area = memory[i];
                if (!area.IsAvailable)
                {
                    result += string.Format("\n\nразмер участка: {0}\nимя файла: {1}; \nразмер файла: {2};", area.Total, area.File.FileName, area.File.Length);
                }
                else
                {
                    result += string.Format("\n\nразмер участка: {0} \nСтатус: Достен для записи", area.Total);
                }               
            }
            if (Unallocated > 0)
            {
                result += string.Format("\n\nразмер участка: {0} \nСтатус: Достен для записи", Unallocated);
            }
            
            return result + string.Format("\n\nЗанято: {0} \nДоступно: {1} \nВсего: {2}", Busy, Available, Total);
        }

        List<MemoryArea> memory;

        const int _total = 360000;       
    }
}
