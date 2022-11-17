using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class DairyProduct : Product
    {
        public DateOnly ExpirationDate { get; }
        public DairyProduct(string name, decimal price, float weight, DateOnly date) : base(name, price, weight)
        {
            if (date.ToDateTime(new TimeOnly()) < DateTime.Now)
            {
                ExpirationDate = date;
            }
        }
        public override void ChangePrice(decimal changePercent)
        {// константи в цьому методі краще виносити в інший клас з статичними зміннмими.
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
        public override object Clone()
        {
            return base.Clone();
        }
        public override bool Equals(object? obj)
        {
            DairyProduct? diaryProduct = obj as DairyProduct;
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
