using Homework8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    internal interface IAnalyzer
    {
        string Analyze(string fileName, Storage storage);
        event Action<string, Order> OrderFailed;
    }
}
