using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class RandomClientBuilder : ClientBuilder
    {
        public RandomClientBuilder(uint height, uint width) : base()
        {
            Height = height;
            Width = width;
        }
        private uint Width;
        private uint Height;
        private Random random = new Random();
        public override void SetAge()
        {
            Client.Age = random.Next(10, 85);
        }

        public override void SetCoordinates()
        {
            Client.Coordinates = new Coordinates(random.Next(0, (int)Width), random.Next(0, (int)Height));
        }

        public override void SetMaxTime()
        {
            Client.MaxTime = random.Next(5000, 50_000);
        }

        public override void SetName()
        {
            
            Client.Name = Data.Names[random.Next(0, Data.Names.Count)];
        }

        public override void SetStatus()
        {
            Client.Status = (ClientStatus)random.Next(0, 3);
        }
    }
}
