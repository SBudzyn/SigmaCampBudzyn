using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class ClientsDirector
    {
        private ClientBuilder _clientBuilder;
        
        public ClientsDirector(ClientBuilder clientBuilder)
        {
            _clientBuilder = clientBuilder;
        }
        public void SetClientBuilder(ClientBuilder builder)
        {
            _clientBuilder = builder;
        }
        public Client GetClient()
        {
            return _clientBuilder.GetClient();
        }
        public void ConstructClient()
        {
            _clientBuilder.CreateNewClient();
            _clientBuilder.SetName();
            _clientBuilder.SetAge();
            _clientBuilder.SetCoordinates();
            _clientBuilder.SetStatus();
            _clientBuilder.SetMaxTime();
        }
        
    }
}
