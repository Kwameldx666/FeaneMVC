﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace FinalProject.Models
{

    public class Cart
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public UserData User { get; set; }

        public decimal Total
        {
            get
            {
                return CartItems.Sum(item => item.Price * item.Quantity);
            }
        }

    }

}
