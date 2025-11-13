namespace ContosoOrderProcessor.Models
{
    public class Order
    {
        public string OrderId { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;

        public Order(string orderId, int customerId, List<OrderItem> items, string paymentMethod)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Items = items;
            PaymentMethod = paymentMethod;
            OrderDate = DateTime.UtcNow;
            TotalAmount = items.Sum(item => item.Price * item.Quantity);
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Order {OrderId} status updated to: {Status}");
        }
    }

    public class OrderItem
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem(string productName, decimal price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}
