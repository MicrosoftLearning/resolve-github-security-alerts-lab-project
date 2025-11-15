using System.Data.SqlClient;
using ContosoOrderProcessor.Models;

namespace ContosoOrderProcessor.Services
{
    public class DatabaseService
    {
        // SECURITY ISSUE: Hard-coded database connection string with credentials
        private const string ConnectionString = "Server=tcp:contoso-orders.database.windows.net,1433;Initial Catalog=ContosoOrdersDB;User ID=orderadmin;Password=C0nt0s0P@ssw0rd2024!;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=False;Connection Timeout=30;";

        public bool SaveOrder(Order order)
        {
            try
            {
                Console.WriteLine($"[DatabaseService] Connecting to database...");
                Console.WriteLine($"[DatabaseService] Connection string: {ConnectionString.Substring(0, 50)}...");
                
                // Simulated database operation
                Console.WriteLine($"[DatabaseService] Saving order {order.OrderId} to database");
                Console.WriteLine($"[DatabaseService] Customer ID: {order.CustomerId}");
                Console.WriteLine($"[DatabaseService] Order Amount: ${order.TotalAmount}");
                Console.WriteLine($"[DatabaseService] Order Items: {order.Items.Count}");
                
                // In a real application, this would execute SQL commands
                // using (SqlConnection connection = new SqlConnection(ConnectionString))
                // {
                //     connection.Open();
                //     // Insert order into database
                // }
                
                Console.WriteLine($"[DatabaseService] Order {order.OrderId} saved successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DatabaseService] Error saving order: {ex.Message}");
                return false;
            }
        }

        public Customer? GetCustomer(int customerId)
        {
            try
            {
                Console.WriteLine($"[DatabaseService] Retrieving customer {customerId} from database");
                
                // Simulated database retrieval
                // In a real application, this would query the database
                
                return new Customer(
                    customerId, 
                    "Lee Gu", 
                    "lee.gu@example.com",
                    "+1-555-0123",
                    "123 Main St, Seattle, WA 98765"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DatabaseService] Error retrieving customer: {ex.Message}");
                return null;
            }
        }

        public bool LogTransaction(string orderId, string transactionType, decimal amount)
        {
            try
            {
                Console.WriteLine($"[DatabaseService] Logging transaction: {transactionType} for order {orderId}");
                
                // Simulated transaction logging
                // using (SqlConnection connection = new SqlConnection(ConnectionString))
                // {
                //     connection.Open();
                //     // Insert transaction log
                // }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DatabaseService] Error logging transaction: {ex.Message}");
                return false;
            }
        }
    }
}
