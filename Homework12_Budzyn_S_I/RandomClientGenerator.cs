using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class RandomClientGenerator : IClientGenerator
    {
        private ClientsDirector _director;
        public RandomClientGenerator(ClientsDirector director)
        {
            _director = director;
        }
        public Client Generate()
        {
            _director.ConstructClient();
            return _director.GetClient();
        }
    }
}
