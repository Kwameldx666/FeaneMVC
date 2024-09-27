﻿using WebApplication1.Models.Enums;

namespace WebApplication1.Models
{
    public class PaymentDetails
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Currency { get; set; } = "USD";

    }
}
