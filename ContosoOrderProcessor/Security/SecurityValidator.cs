using ContosoOrderProcessor.Models;

namespace ContosoOrderProcessor.Security
{
    public class SecurityValidator
    {
        private readonly List<string> _suspiciousPatterns = new List<string>
        {
            "<script>", "javascript:", "onerror=", "onload=",
            "SELECT * FROM", "DROP TABLE", "UNION SELECT",
            "../", "..\\", "eval(", "exec("
        };

        private readonly HashSet<string> _blockedIpAddresses = new HashSet<string>
        {
            "192.0.2.0", "198.51.100.0", "203.0.113.0"
        };

        public bool ValidateOrder(Order order)
        {
            Console.WriteLine($"[SecurityValidator] Validating order {order.OrderId}");

            if (!ValidateOrderAmount(order.TotalAmount))
            {
                Console.WriteLine($"[SecurityValidator] Invalid order amount: ${order.TotalAmount}");
                return false;
            }

            if (!ValidateOrderItems(order.Items))
            {
                Console.WriteLine($"[SecurityValidator] Invalid order items detected");
                return false;
            }

            if (!ValidatePaymentMethod(order.PaymentMethod))
            {
                Console.WriteLine($"[SecurityValidator] Invalid payment method: {order.PaymentMethod}");
                return false;
            }

            Console.WriteLine($"[SecurityValidator] Order validation passed");
            return true;
        }

        public bool ValidateCustomer(Customer customer)
        {
            Console.WriteLine($"[SecurityValidator] Validating customer {customer.CustomerId}");

            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                Console.WriteLine($"[SecurityValidator] Invalid customer name");
                return false;
            }

            if (!ValidateEmail(customer.Email))
            {
                Console.WriteLine($"[SecurityValidator] Invalid email address: {customer.Email}");
                return false;
            }

            if (ContainsSuspiciousContent(customer.ShippingAddress))
            {
                Console.WriteLine($"[SecurityValidator] Suspicious content detected in shipping address");
                return false;
            }

            Console.WriteLine($"[SecurityValidator] Customer validation passed");
            return true;
        }

        private bool ValidateOrderAmount(decimal amount)
        {
            const decimal minAmount = 0.01m;
            const decimal maxAmount = 50000.00m;
            return amount >= minAmount && amount <= maxAmount;
        }

        private bool ValidateOrderItems(List<OrderItem> items)
        {
            if (items == null || items.Count == 0)
            {
                return false;
            }

            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.ProductName))
                {
                    return false;
                }

                if (item.Price <= 0 || item.Quantity <= 0)
                {
                    return false;
                }

                if (ContainsSuspiciousContent(item.ProductName))
                {
                    Console.WriteLine($"[SecurityValidator] Suspicious content in product name: {item.ProductName}");
                    return false;
                }
            }

            return true;
        }

        private bool ValidatePaymentMethod(string paymentMethod)
        {
            var validMethods = new[] { "stripe", "credit card", "paypal", "debit card" };
            return validMethods.Contains(paymentMethod.ToLower());
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ContainsSuspiciousContent(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (var pattern in _suspiciousPatterns)
            {
                if (input.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateIpAddress(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return false;
            }

            if (_blockedIpAddresses.Contains(ipAddress))
            {
                Console.WriteLine($"[SecurityValidator] Blocked IP address detected: {ipAddress}");
                return false;
            }

            return true;
        }

        public string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Basic sanitization - remove common dangerous characters
            string sanitized = input
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#x27;")
                .Replace("&", "&amp;");

            return sanitized;
        }

        public bool CheckFraudRisk(Order order, Customer customer)
        {
            Console.WriteLine($"[SecurityValidator] Performing fraud risk assessment");

            // Simulated fraud detection logic
            bool highRiskOrder = order.TotalAmount > 5000;
            bool newCustomer = customer.CreatedDate > DateTime.UtcNow.AddDays(-30);

            if (highRiskOrder && newCustomer)
            {
                Console.WriteLine($"[SecurityValidator] High fraud risk detected - new customer with large order");
                return false;
            }

            Console.WriteLine($"[SecurityValidator] Fraud risk assessment passed");
            return true;
        }
    }
}
