using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class ClientsHandler
    {
        private IClientGenerator _clientGenerator;
        private List<TicketOffice> _offices;
        private int _maximumIntensivity = 300;
        private int _minimumIntensivity = 1000;
        public ClientsHandler(IClientGenerator clientGenerator, List<TicketOffice> offices)
        {
            _clientGenerator = clientGenerator;
            _offices = offices;
        }
        public void SetIntensivity(int maximumIntensivity, int minimumIntensivity)
        {
            _maximumIntensivity = maximumIntensivity;
            _minimumIntensivity = minimumIntensivity;
        }
        public void GenerateClients(ref bool isWorking)
        {
            while (isWorking == true)
            {
                var client = _clientGenerator.Generate();
                ChooseOffice(client);
                Random random = new Random();
                Thread.Sleep(random.Next(_maximumIntensivity, _minimumIntensivity));
            }
        }
        public void ChooseOffice(Client client)
        {
            if (_offices.All(o => o.IsOpen == false))
            {
                return;
            }
            if (_offices.Where(o => o.IsOpen == true).All(o => o.GetQueueLength() == _offices.Where(o => o.IsOpen == true).FirstOrDefault()!.GetQueueLength()))
            {
                var office = GetNearestOffice(client);
                office.AddClient(client);
            }
            else
            {
                var office = _offices.MinBy(o => o.GetQueueLength())!;
                office.AddClient(client);
            }
        }
        private TicketOffice GetNearestOffice(Client client)
        {
            var minDist = CalculateDistanse(0, client);
            TicketOffice nearestOffice = _offices[0];
            for (int i = 1; i < _offices.Count; i++)
            {
                if (_offices[i].IsOpen == true)
                {
                    var dist = CalculateDistanse(i, client);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        nearestOffice = _offices[i];
                    }
                }
            }
            return nearestOffice;
        }
        private double CalculateDistanse(int officeIndex, Client client)
        {
            return Math.Sqrt(Math.Pow((client.Coordinates.X - officeIndex), 2) + Math.Pow(client.Coordinates.Y, 2));
        }

    }
}
