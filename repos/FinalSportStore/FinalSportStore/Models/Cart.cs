using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Models
{
    public class Cart
    {
        public List<CartLine> Line = new List<CartLine>();
        public void AddItem(Product p,int quantity)
        {
            CartLine item = Line.Where(i => i.product.ProductID == p.ProductID).FirstOrDefault();
            if (item == null)
            {
                Line.Add(new CartLine { product = p, quantity = quantity });

            }
            else
            {
                item.quantity += quantity;
            }


        }
        public decimal ComputeTotalValues()
        {
            return Line.Sum(e => e.product.Price * e.quantity);
        }
        public void Clear()
        {
            Line.Clear();
        }
        public void RemoveAll(Product p)
        {
            Line.RemoveAll(e => e.product.ProductID == p.ProductID);
        }
    }
    public class CartLine
    {
        public int CartLineID;
        public Product product;
        public int quantity;
    }
}
