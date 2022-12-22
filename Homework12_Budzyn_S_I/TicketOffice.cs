using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    enum OfficeStatus
    {   
        Mixed,
        Regular,
        Privileged,
        VIP
    }
    internal class TicketOffice
    {
        public event Action<TicketOffice> OfficeOvercrowded;
        private Queue<Client> _regularQueue = new Queue<Client>();
        private Queue<Client> _privilegedQueue = new Queue<Client>();
        private Queue<Client> _VIPQueue = new Queue<Client>();
        private Queue<Client> _pensionersClientsQueue = new Queue<Client>();
        private int _maximumUsersNumber = 15;
        private int _pensionAge = 60;
        private int _minimunClientServeTime = 4000;
        private int _maximumClientServeTime = 10000;
        public int OfficeNumber { get; private set; }
        public bool IsOpen { get; private set; } = false;
        public OfficeStatus Status { get; private set; }
        private IDisplay _display;
        public TicketOffice(IDisplay display, int officeNumber, params Client[] clients)
        {
            OfficeNumber = officeNumber;
            _display = display;
            foreach (var client in clients)
            {
                if (client.Age > 60)
                {
                    _pensionersClientsQueue.Append(client);
                }
                else if (client.Status == ClientStatus.VIP)
                {
                    _VIPQueue.Append(client);
                }
                else if (client.Status == ClientStatus.Privileged)
                {
                    _privilegedQueue.Append(client);
                }
                else
                {
                    _regularQueue.Append(client);
                }
            }
        }
        public int GetQueueLength()
        {
            return _regularQueue.Count + _pensionersClientsQueue.Count + _privilegedQueue.Count + _VIPQueue.Count;
        }
        public void AddClient(Client client)
        {
            
            if (client.Age > _pensionAge)
            {
                _pensionersClientsQueue.Enqueue(client);
            }
            if (client.Status == ClientStatus.VIP)
            {
                _VIPQueue.Enqueue(client);
            }
            if (client.Status == ClientStatus.Privileged)
            {
                _privilegedQueue.Enqueue(client);
            }
            if (client.Status == ClientStatus.Regular)
            {
                _regularQueue.Enqueue(client);
            }
            if (GetQueueLength() > _maximumUsersNumber)
            {
                OfficeOvercrowded?.Invoke(this);
            }
        }
        public void AddClients(params Client[] clients)
        {
            foreach (Client client in clients)
            {
                AddClient(client);
            }
        }
        public List<Client> ChangeOfficeStatus(OfficeStatus status)
        {
            Status = status;
            List<Client> clients = new();
            if (status == OfficeStatus.Privileged)
            {
                clients.AddRange(_VIPQueue.ToArray());
                _VIPQueue.Clear();
                clients.AddRange(_regularQueue.ToArray());
                _regularQueue.Clear();
            }
            else if (status == OfficeStatus.VIP)
            {
                clients.AddRange(_privilegedQueue.ToArray());
                _privilegedQueue.Clear();
                clients.AddRange(_regularQueue.ToArray());
                _regularQueue.Clear();
            }
            else if (status == OfficeStatus.Regular)
            {
                clients.AddRange(_VIPQueue.ToArray());
                _VIPQueue.Clear();
                clients.AddRange(_privilegedQueue.ToArray());
                _privilegedQueue.Clear();
            }
            return clients;
        }
        public List<Client> Close()
        {
            List<Client> clients = new();
            if (IsOpen == true)
            {
                IsOpen = false;
                
                clients.AddRange(_pensionersClientsQueue.ToArray());
                _regularQueue.Clear();
                clients.AddRange(_VIPQueue.ToArray());
                _VIPQueue.Clear();
                clients.AddRange(_privilegedQueue.ToArray());
                _privilegedQueue.Clear();
                clients.AddRange(_regularQueue.ToArray());
                _regularQueue.Clear();
            }
            return clients;
        }
        public void Open()
        {
            if (IsOpen == false)
            {
                IsOpen = true;
                Task.Run(() => ServeClients());
            }
        }
        private async Task ServeClients()
        {
            while (IsOpen == true)
            {
                var client = GetNextClient();
                while (client == null)
                {
                    await Task.Delay(1000);
                    if (IsOpen == false)
                        return;
                    client = GetNextClient();
                }
                await ServeClient(client);
                _display.Display(GenerateServedClientInfo(client));
            }
        }
        private async Task ServeClient(Client client)
        {
            Random random = new Random();
            var serveTime = random.Next(_minimunClientServeTime, _maximumClientServeTime);
            await Task.Delay(serveTime);
        }
        private Client? GetNextClient()
        {
            if (_pensionersClientsQueue.Count() != 0)
            {
                return _pensionersClientsQueue.Dequeue();
            }
            if (_VIPQueue.Count() != 0)
            {
                return _VIPQueue.Dequeue();
            }
            if (_privilegedQueue.Count() != 0)
            {
                return _privilegedQueue.Dequeue();
            }
            if (_regularQueue.Count() != 0)
            {
                return _regularQueue.Dequeue();
            }
            return null;
        }
        private string GenerateServedClientInfo(Client client)
        {
            return $"Client {client.Name}({client.Age} years, {client.Status}) was served in the office Number {OfficeNumber} at {DateTime.Now}";
        }
    }
}
