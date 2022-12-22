using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal abstract class ClientBuilder
    {
        protected Client Client { get; private set; }
        public void CreateNewClient()
        {
            Client = new Client();
        }
        public Client GetClient()
        {
            return Client;
        }
        public abstract void SetName();
        public abstract void SetAge();
        public abstract void SetStatus();
        public abstract void SetMaxTime();
        public abstract void SetCoordinates();
    }
}
