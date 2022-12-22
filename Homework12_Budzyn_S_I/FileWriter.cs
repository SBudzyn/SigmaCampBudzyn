using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class FileWriter : IDisplay
    {
        private string _path;
        public FileWriter(string path)
        {
            _path = path;
        }

        public void Display(string str)
        {
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine(str);
            }
        }
    }
}
