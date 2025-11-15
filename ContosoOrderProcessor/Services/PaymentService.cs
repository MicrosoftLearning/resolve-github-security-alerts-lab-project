using ContosoOrderProcessor.Models;

namespace ContosoOrderProcessor.Services
{
    public class PaymentService
    {
        // SECURITY ISSUE: Hard-coded Stripe API key
        private const string StripeApiKey = "sk_live_51MqxYzABC123def456GHI789jklMNO012pqrSTU345vwxYZ678abcDEF901ghiJKL234mnoPQR567stuVWX890yzABC";
        
        // SECURITY ISSUE: Hard-coded PayPal API credentials
        private const string PayPalClientId = "AYjcyBXRO7UZLP5MNqQmH6BfGHJ8KLMnoPQRSTUVWXYZ-ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrs";
        private const string PayPalSecret = "EJKLMnoPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijk";
        
        // SECURITY ISSUE: Hard-coded Square Access Token
        private const string SquareAccessToken = "EAAAEOuLQavTvyym5PByGZrGdRLWiL_RB0n8YF0gELTxFqLhNp6bKHRhA6P7Uv5F";

        public bool ProcessPayment(Order order)
        {
            try
            {
                Console.WriteLine($"[PaymentService] Processing payment for order {order.OrderId}");
                Console.WriteLine($"[PaymentService] Payment method: {order.PaymentMethod}");
                Console.WriteLine($"[PaymentService] Amount: ${order.TotalAmount}");

                bool paymentSuccessful = false;

                switch (order.PaymentMethod.ToLower())
                {
                    case "stripe":
                    case "credit card":
                        paymentSuccessful = ProcessStripePayment(order);
                        break;
                    case "paypal":
                        paymentSuccessful = ProcessPayPalPayment(order);
                        break;
                    default:
                        Console.WriteLine($"[PaymentService] Unknown payment method: {order.PaymentMethod}");
                        return false;
                }

                if (paymentSuccessful)
                {
                    Console.WriteLine($"[PaymentService] Payment processed successfully for order {order.OrderId}");
                    order.UpdateStatus("Payment Confirmed");
                }
                else
                {
                    Console.WriteLine($"[PaymentService] Payment failed for order {order.OrderId}");
                    order.UpdateStatus("Payment Failed");
                }

                return paymentSuccessful;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PaymentService] Error processing payment: {ex.Message}");
                return false;
            }
        }

        private bool ProcessStripePayment(Order order)
        {
            Console.WriteLine($"[PaymentService] Using Stripe API key: {StripeApiKey.Substring(0, 15)}...");
            Console.WriteLine($"[PaymentService] Creating Stripe payment intent for ${order.TotalAmount}");
            
            // Simulated Stripe API call
            // In a real application, this would call Stripe's API
            // var stripe = new StripeClient(StripeApiKey);
            // var paymentIntent = stripe.PaymentIntents.Create(...);
            
            Console.WriteLine($"[PaymentService] Stripe payment completed successfully");
            return true;
        }

        private bool ProcessPayPalPayment(Order order)
        {
            Console.WriteLine($"[PaymentService] Using PayPal credentials");
            Console.WriteLine($"[PaymentService] Client ID: {PayPalClientId.Substring(0, 20)}...");
            Console.WriteLine($"[PaymentService] Creating PayPal order for ${order.TotalAmount}");
            
            // Simulated PayPal API call
            // In a real application, this would authenticate and call PayPal's API
            // var auth = PayPalAuth.GetToken(PayPalClientId, PayPalSecret);
            // var payment = PayPal.CreateOrder(...);
            
            Console.WriteLine($"[PaymentService] PayPal payment completed successfully");
            return true;
        }

        public string GenerateTransactionId()
        {
            return $"TXN-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }

        public bool RefundPayment(string orderId, decimal amount)
        {
            Console.WriteLine($"[PaymentService] Processing refund for order {orderId}: ${amount}");
            
            // Simulated refund logic
            Console.WriteLine($"[PaymentService] Refund processed successfully");
            return true;
        }
    }
}
