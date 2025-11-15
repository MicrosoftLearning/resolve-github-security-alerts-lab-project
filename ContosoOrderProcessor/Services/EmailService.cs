using ContosoOrderProcessor.Models;

namespace ContosoOrderProcessor.Services
{
    public class EmailService
    {
        // SECURITY ISSUE: Hard-coded SendGrid API key
        private const string SendGridApiKey = "SG.ngeVfQFYQlKU0ufo8x5d1A.TwL2iGABf9DHoTf-09kqeF8tAmbihYzrnopqrstuvw";
        
        // SECURITY ISSUE: Hard-coded Mailgun API key
        private const string MailgunApiKey = "key-1234567890abcdef1234567890abcdef";
        
        // SECURITY ISSUE: Hard-coded SMTP credentials
        private const string SmtpHost = "smtp.contoso.com";
        private const string SmtpUsername = "notifications@contoso.com";
        private const string SmtpPassword = "N0tif1c@ti0nP@ss2024";

        public bool SendOrderConfirmation(Order order, Customer customer)
        {
            try
            {
                Console.WriteLine($"[EmailService] Sending order confirmation email");
                Console.WriteLine($"[EmailService] Using SendGrid API key: {SendGridApiKey.Substring(0, 20)}...");
                Console.WriteLine($"[EmailService] To: {customer.Email}");
                Console.WriteLine($"[EmailService] Subject: Order Confirmation - {order.OrderId}");

                string emailBody = GenerateOrderConfirmationEmail(order, customer);
                
                // Simulated SendGrid API call
                // In a real application, this would use SendGrid's SDK
                // var client = new SendGridClient(SendGridApiKey);
                // var msg = MailHelper.CreateSingleEmail(...);
                // var response = await client.SendEmailAsync(msg);

                Console.WriteLine($"[EmailService] Email sent successfully to {customer.Email}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmailService] Error sending email: {ex.Message}");
                return false;
            }
        }

        public bool SendShippingNotification(Order order, Customer customer, string trackingNumber)
        {
            try
            {
                Console.WriteLine($"[EmailService] Sending shipping notification email");
                Console.WriteLine($"[EmailService] Using SMTP server: {SmtpHost}");
                Console.WriteLine($"[EmailService] SMTP username: {SmtpUsername}");
                Console.WriteLine($"[EmailService] To: {customer.Email}");
                Console.WriteLine($"[EmailService] Tracking number: {trackingNumber}");

                // Simulated SMTP email sending
                // In a real application, this would use SmtpClient
                // using (var smtpClient = new SmtpClient(SmtpHost))
                // {
                //     smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                //     smtpClient.Send(mailMessage);
                // }

                Console.WriteLine($"[EmailService] Shipping notification sent successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmailService] Error sending shipping notification: {ex.Message}");
                return false;
            }
        }

        private string GenerateOrderConfirmationEmail(Order order, Customer customer)
        {
            var emailBody = $@"
Dear {customer.Name},

Thank you for your order!

Order Details:
- Order ID: {order.OrderId}
- Order Date: {order.OrderDate:yyyy-MM-dd HH:mm:ss}
- Total Amount: ${order.TotalAmount}
- Payment Method: {order.PaymentMethod}

Items Ordered:
{string.Join("\n", order.Items.Select(item => $"  - {item.ProductName} (Qty: {item.Quantity}) - ${item.Price * item.Quantity}"))}

Shipping Address:
{customer.ShippingAddress}

We will send you another email once your order ships.

Best regards,
Contoso Order Processor Team
";
            return emailBody;
        }

        public bool SendPaymentFailureNotification(Order order, Customer customer)
        {
            try
            {
                Console.WriteLine($"[EmailService] Sending payment failure notification");
                Console.WriteLine($"[EmailService] To: {customer.Email}");
                Console.WriteLine($"[EmailService] Order ID: {order.OrderId}");
                
                // Simulated email sending
                Console.WriteLine($"[EmailService] Payment failure notification sent");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmailService] Error sending payment failure notification: {ex.Message}");
                return false;
            }
        }
    }
}
