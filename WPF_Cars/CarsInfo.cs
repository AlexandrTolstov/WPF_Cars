using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Cars
{
    public class CarsInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public CarsInfo(string name)
        {
            Name = name.Remove(name.Length - 4);
            Path = AppDomain.CurrentDomain.BaseDirectory + "png/" + name;
        }
    }
}
