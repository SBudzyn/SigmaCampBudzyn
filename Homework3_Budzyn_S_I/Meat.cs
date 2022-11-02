using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    enum Category
    {
        HighestSort,
        FirstSort,
        SecondSort
    }
    enum Type
    {
        Mutton,
        Pork,
        Beef,
        Chicken
    }
    internal class Meat : Product
    {
        public Category Category { get; }
        public Type Type { get; } 
        public Meat(string name, decimal price, float weight, Category category, Type type) : base(name, price, weight)
        {
            Category = category;
            Type = type;
        }
        public override object Clone()
        {
            return base.Clone();
        }
        public override void ChangePrice(decimal changePercent)
        {
            if (this.Type == Type.Chicken)
            {
                changePercent += 2;
            }
            else if (this.Type == Type.Beef)
            {
                changePercent += 4;
            }
            else if (this.Type == Type.Pork)
            {
                changePercent += 5;
            }
            else if (this.Type == Type.Mutton)
            {
                changePercent += 6;
            }
            base.ChangePrice(changePercent);
        }
        public override string ToString()
        {
            return $"{Name} (meat). Price - {Price}";
        }
        public override bool Equals(object? obj)
        {
            Meat? meat = obj as Meat;
            if (meat == null)
            {
                return false;
            }
            if (this.Name == meat.Name && this.Category == meat.Category && this.Type == meat.Type )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.Type.GetHashCode();
        }
    }
}
