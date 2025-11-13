namespace ContosoOrderProcessor.Configuration
{
    public static class AppConfig
    {
        // Application configuration constants
        public const string ApplicationName = "Contoso Order Processor";
        public const string ApplicationVersion = "2.1.0";
        public const string Environment = "Production";

        // SECURITY ISSUE: Hard-coded AWS credentials
        public const string AwsAccessKeyId = "AKIAIOSFODNN7EXAMPLE";
        public const string AwsSecretAccessKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        public const string AwsRegion = "us-west-2";
        public const string AwsS3Bucket = "contoso-order-documents";

        // SECURITY ISSUE: Hard-coded Azure Storage connection string
        public const string AzureStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=contosostorageacct;AccountKey=abc123XYZ789+defGHI456/jklMNO012+pqrSTU345/vwxYZ678+abcDEF901==;EndpointSuffix=core.windows.net";

        // SECURITY ISSUE: Hard-coded API keys for third-party services
        public const string TwilioAccountSid = "AC1234567890abcdef1234567890abcdef";
        public const string TwilioAuthToken = "1234567890abcdef1234567890abcdef";
        public const string TwilioPhoneNumber = "+1-555-0199";

        // SECURITY ISSUE: Hard-coded JWT secret key
        public const string JwtSecretKey = "ThisIsAVerySecretKeyForJwtTokenGeneration2024!";
        public const int JwtExpirationMinutes = 60;

        // SECURITY ISSUE: Hard-coded encryption key
        public const string EncryptionKey = "E4B7C9D2F6A8E3C1B5D7F9A2C4E6B8D0";
        public const string EncryptionIV = "A1B2C3D4E5F6G7H8";

        // Application settings
        public const int MaxOrderRetries = 3;
        public const int OrderTimeoutSeconds = 30;
        public const decimal MinimumOrderAmount = 5.00m;
        public const decimal MaximumOrderAmount = 10000.00m;

        // Feature flags
        public const bool EnableEmailNotifications = true;
        public const bool EnableSmsNotifications = true;
        public const bool EnableOrderTracking = true;
        public const bool EnableFraudDetection = true;

        public static void PrintConfiguration()
        {
            Console.WriteLine("=== Application Configuration ===");
            Console.WriteLine($"Application: {ApplicationName} v{ApplicationVersion}");
            Console.WriteLine($"Environment: {Environment}");
            Console.WriteLine($"AWS Region: {AwsRegion}");
            Console.WriteLine($"AWS S3 Bucket: {AwsS3Bucket}");
            Console.WriteLine($"Email Notifications: {EnableEmailNotifications}");
            Console.WriteLine($"SMS Notifications: {EnableSmsNotifications}");
            Console.WriteLine($"Fraud Detection: {EnableFraudDetection}");
            Console.WriteLine("==================================\n");
        }

        public static string GetAwsCredentials()
        {
            return $"Access Key: {AwsAccessKeyId}, Secret Key: {AwsSecretAccessKey}";
        }

        public static bool ValidateConfiguration()
        {
            // Basic configuration validation
            if (string.IsNullOrEmpty(AwsAccessKeyId) || string.IsNullOrEmpty(AwsSecretAccessKey))
            {
                Console.WriteLine("[AppConfig] Warning: AWS credentials are not configured");
                return false;
            }

            if (string.IsNullOrEmpty(AzureStorageConnectionString))
            {
                Console.WriteLine("[AppConfig] Warning: Azure Storage connection string is not configured");
                return false;
            }

            if (string.IsNullOrEmpty(JwtSecretKey))
            {
                Console.WriteLine("[AppConfig] Warning: JWT secret key is not configured");
                return false;
            }

            Console.WriteLine("[AppConfig] Configuration validation passed");
            return true;
        }
    }
}
