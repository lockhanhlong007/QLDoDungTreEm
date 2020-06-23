using ModelsDungChung;
using System;

namespace QLDoDungTreEm.Models
{
    [Serializable]
    public class CartItem
    {
        public SanPham Product { get; set; }

        public int quantity { get; set; }
    }
}