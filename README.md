# Contoso Order Processor - Training Lab Project

## ⚠️ Educational Use Only

This project is intended **exclusively for educational purposes** and should **NOT** be used in production environments or as a model for production code. The codebase contains intentional security vulnerabilities designed for learning how to identify and resolve security issues using GitHub Copilot and GitHub Security features.

## Overview

Contoso Order Processor is a realistic e-commerce order processing application that demonstrates common security vulnerabilities found in real-world applications. This project is designed as a training lab for developers learning to:

- Identify exposed secrets using GitHub Secret Scanning
- Resolve security alerts using GitHub Copilot
- Implement secure configuration management practices
- Apply security best practices in .NET applications

## Application Features

The application simulates a complete e-commerce order processing workflow including:

- **Customer Management**: Customer data retrieval and validation
- **Order Processing**: Order creation, validation, and tracking
- **Payment Processing**: Integration with Stripe and PayPal payment gateways
- **Email Notifications**: Order confirmation and shipping notifications via SendGrid and SMTP
- **Security Validation**: Input validation, fraud detection, and security checks
- **Database Operations**: Order persistence and transaction logging
- **Cloud Integration**: AWS and Azure cloud service configurations

## Project Structure

``` plaintext
ContosoOrderProcessor/
├── Configuration/
│   └── AppConfig.cs              # Application configuration (contains exposed secrets)
├── Models/
│   ├── Customer.cs               # Customer entity model
│   └── Order.cs                  # Order and OrderItem models
├── Security/
│   └── SecurityValidator.cs      # Security validation and fraud detection
├── Services/
│   ├── DatabaseService.cs        # Database operations (contains exposed secrets)
│   ├── EmailService.cs           # Email notifications (contains exposed secrets)
│   └── PaymentService.cs         # Payment processing (contains exposed secrets)
└── Program.cs                    # Main application entry point
```

## Intentional Security Vulnerabilities

The application contains the following **intentional** security issues for training purposes:

### Exposed Secrets

- ❌ Hard-coded SQL Server connection strings
- ❌ Hard-coded Stripe API keys
- ❌ Hard-coded PayPal credentials
- ❌ Hard-coded SendGrid API keys
- ❌ Hard-coded SMTP credentials
- ❌ Hard-coded AWS credentials
- ❌ Hard-coded Azure Storage connection strings
- ❌ Hard-coded Twilio credentials
- ❌ Hard-coded JWT secret keys
- ❌ Hard-coded encryption keys

These secrets should be detected by GitHub Secret Scanning and resolved using secure configuration management practices.

## Prerequisites

- .NET 9.0 SDK or later
- Visual Studio Code or Visual Studio 2022
- GitHub account with Secret Scanning enabled
- GitHub Copilot subscription (for AI-assisted remediation)

## Running the Application

### Build the Project

```powershell
cd ContosoOrderProcessor
dotnet build
```

### Run the Application

```powershell
dotnet run
```

### Expected Output

The application produces verifiable console output showing a complete order processing workflow:

``` plaintext
╔════════════════════════════════════════════════════════╗
║   Contoso Order Processor - E-Commerce Application    ║
╚════════════════════════════════════════════════════════╝

=== Application Configuration ===
Application: Contoso Order Processor v2.1.0
Environment: Production
...

╔════════════════════════════════════════════════════════╗
║              ORDER PROCESSING COMPLETED               ║
╚════════════════════════════════════════════════════════╝

✓ Order ID: ORD-20251113202904
✓ Customer: John Doe (john.doe@example.com)
✓ Total Amount: $148.94
✓ Payment Method: Stripe
✓ Status: Shipped
✓ Transaction ID: TXN-20251113202904-7782143D
✓ Tracking Number: TRK-EEC64BA1
```

## Training Lab Objectives

### Part 1: Identify Security Issues

- Use GitHub Secret Scanning to identify exposed secrets
- Review GitHub Security Alerts in your repository
- Understand the risks associated with each exposed secret

### Part 2: Remediate Security Issues

- Use GitHub Copilot to suggest secure alternatives
- Implement environment variables and configuration files
- Utilize .NET User Secrets for local development
- Configure Azure Key Vault or AWS Secrets Manager for production

### Part 3: Verify Remediation

- Confirm all security alerts are resolved
- Run the application to verify it still works correctly
- Compare output before and after remediation
- Ensure no secrets remain in the codebase

## Security Best Practices to Learn

1. **Never commit secrets to source control**
2. **Use environment variables for configuration**
3. **Implement secure secret management** (Azure Key Vault, AWS Secrets Manager)
4. **Use .NET User Secrets** for local development
5. **Configure proper .gitignore patterns**
6. **Implement dependency injection** for configuration
7. **Use configuration interfaces** instead of hard-coded values
8. **Enable GitHub Secret Scanning** and Push Protection
9. **Regular security audits** of dependencies
10. **Follow the principle of least privilege**

## Additional Resources

- [EXPOSED_SECRETS_REFERENCE.md](./EXPOSED_SECRETS_REFERENCE.md) - Detailed list of intentional vulnerabilities
- [GitHub Secret Scanning Documentation](https://docs.github.com/en/code-security/secret-scanning)
- [.NET Configuration Best Practices](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Azure Key Vault for .NET](https://learn.microsoft.com/en-us/azure/key-vault/)

## Notes

- All credentials in this codebase are **fictional** and created for training purposes only
- The application uses simulated external service calls (no real API calls are made)
- Database operations are simulated and do not require an actual database
- This code should never be deployed to production environments

## License

See [LICENSE-CODE](./LICENSE-CODE) for licensing information.

## Security Policy

See [SECURITY.md](./SECURITY.md) for our security policy (part of the training exercise).
