using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal interface IAnalyzer
    {
        string Analyze(string fileName, Storage storage);
        
    }
}
