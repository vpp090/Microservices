﻿namespace BrokerMessagesR.Models
{
    public class EventOrderModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }

        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
