using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal class ApartmentData
    {
        public int Id { get; set; }
        public uint Number { get; set; }
        public int QuarterNumber { get; set; }
        public string Address { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public uint FirstMonthValue1 { get; set; }
        public uint FirstMonthValue2 { get; set; }
        public uint SecondMonthValue1 { get; set; }
        public uint SecondMonthValue2 { get; set; }
        public uint ThirdMonthValue1 { get; set; }
        public uint ThirdMonthValue2 { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }
        public DateTime ThirdDate { get; set; }

    }
}
