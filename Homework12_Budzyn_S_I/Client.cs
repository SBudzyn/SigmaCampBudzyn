using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    enum ClientStatus
    {
        Regular,
        Privileged,
        VIP
    }
    internal class Client
    {
        public Client(string name, int age, ClientStatus status, int maxTime, Coordinates coordinates)
        {
            Name = name;
            Age = age;
            Status = status;
            MaxTime = maxTime;
            Coordinates = coordinates;
        }
        public Client()
        {

        }
        public Coordinates Coordinates;
        public string Name { get; set; }
        private int _age;

        public int Age
        {
            get => _age;
            set 
            {
                if (value >= 100 || value < 0)
                {
                    throw new ArgumentException("Wrong age");
                } 
                _age = value;
            }
        }
        public ClientStatus Status { get; set; }
        private int _maxTime;

        public int MaxTime
        {
            get => _maxTime; 
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wrong maximum time of waiting");
                }
                _maxTime = value; 
            }
        }

    }
}
