using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic3_Lab
{
    internal class Cart
    {
        private int cartId;
        private double total;
        private DateTime createAt;
        public Dictionary<Product, int> products;

        public int CartId { get => cartId; set => cartId = value; }
        public double Total { get => total; set => total = value; }
        public DateTime CreateAt { get => createAt; set => createAt = value; }

        public Cart(int cartId, double total, DateTime createAt)
        {
            products = new Dictionary<Product, int>();
            this.cartId = cartId;
            this.total = total;
            this.createAt = createAt;
        }
    }
}
