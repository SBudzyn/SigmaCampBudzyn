using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class RailwayStation
    {
        private List<TicketOffice> _ticketOffices = new List<TicketOffice>();
        private bool _isWorking = false;
        public readonly uint Width;
        public readonly uint Height;
        private ClientsHandler _clientHandler;
        public RailwayStation(uint width, uint height, IClientGenerator generator, params TicketOffice[] ticketOffices)
        {
            Width = width;
            Height = height;
            _ticketOffices.AddRange(ticketOffices);
            _clientHandler = new ClientsHandler(generator, _ticketOffices);
        }
        public void Start()
        {
            _isWorking = true;
            _ticketOffices.ForEach(ticketOffice => ticketOffice.Open());
            Task task = Task.Run(() => _clientHandler.GenerateClients(ref _isWorking));
        }
        public void Stop()
        {
            _isWorking = false;
            _ticketOffices.ForEach(_ticketOffice => _ticketOffice.Close());
        }
        public TicketOffice GetTicketsOffice(int number)
        {
            if (number < 0 || number > _ticketOffices.Count - 1)
            {
                throw new ArgumentException("The office with this number doesn`t exist");
            }
            return _ticketOffices[number];
        }
        public void ChangeOfficeStatus(int num, OfficeStatus status)
        {
            var office = _ticketOffices.FirstOrDefault(o => o.OfficeNumber == num);
            if (office == null)
                return;
            var clients = office.ChangeOfficeStatus(status);
            clients.ForEach(cl => _clientHandler.ChooseOffice(cl));
        }
        public void CloseOffice(int num)
        {
            var office = _ticketOffices.FirstOrDefault(o => o.OfficeNumber == num);
            if (office == null)
                return;
            var clients = office.Close();
            clients.ForEach(cl => _clientHandler.ChooseOffice(cl));
        }      
    }
}
