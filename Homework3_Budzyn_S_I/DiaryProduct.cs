using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class DiaryProduct : Product
    {
        DateOnly ExpirationDate { get; }
        public DiaryProduct(string name, decimal price, float weight, DateOnly date) : base(name, price, weight)
        {
            ExpirationDate = date;
        }
        public override void ChangePrice(decimal changePercent)
        {
            int days = (ExpirationDate.ToDateTime(new TimeOnly()) - DateTime.Now).Days;
            if (days > 100)
            {
                changePercent += 5;
            }
            else if (days > 50)
            {
                changePercent += 3;
            }
            else if (days > 20)
            {
                changePercent += 1;
            }
            else if (days > 10)
            {
                changePercent -= 2;
            }
            else if (days > 5)
            {
                changePercent -= 4;
            }
            else 
            {
                changePercent -= 10;
            }
            base.ChangePrice(changePercent);
        }
        public override bool Equals(object? obj)
        {
            DiaryProduct? diaryProduct = obj as DiaryProduct;
            if (diaryProduct == null)
                return false;
            if (diaryProduct.Name == this.Name && diaryProduct.ExpirationDate == this.ExpirationDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"{Name}, Expiration Date - {ExpirationDate}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
