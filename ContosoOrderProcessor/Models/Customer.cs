namespace ContosoOrderProcessor.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public Customer(int customerId, string name, string email, string phoneNumber, string shippingAddress)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            ShippingAddress = shippingAddress;
            CreatedDate = DateTime.UtcNow;
        }
    }
}
