# Lab Quick Start Guide

## Objective
Learn to identify and resolve GitHub Secret Scanning alerts using GitHub Copilot in a realistic e-commerce application.

## Before You Start

### 1. Verify Application Works
```powershell
cd ContosoOrderProcessor
dotnet build
dotnet run
```

**Expected Output:**
- Complete order processing workflow
- Order ID, Customer info, Total amount ($148.94)
- Transaction and tracking numbers
- Success message at the end

### 2. Document Baseline Output
Save the console output for comparison after remediation.

## Lab Steps

### Step 1: Identify Exposed Secrets (15 minutes)

**Using GitHub Secret Scanning:**
1. Navigate to your repository on GitHub
2. Go to Security → Secret scanning alerts
3. Review all detected secrets

**Using GitHub Copilot:**
1. Open the Copilot Chat panel
2. Ask: "Scan this codebase for exposed secrets and security vulnerabilities"
3. Review the identified issues

**Expected Findings:**
- Database connection strings (DatabaseService.cs)
- Payment API keys - Stripe, PayPal (PaymentService.cs)
- Email service credentials - SendGrid, SMTP (EmailService.cs)
- AWS credentials (AppConfig.cs)
- Azure Storage connection strings (AppConfig.cs)
- Twilio credentials (AppConfig.cs)
- JWT secret keys (AppConfig.cs)
- Encryption keys (AppConfig.cs)

### Step 2: Plan Remediation Strategy (10 minutes)

**Ask GitHub Copilot:**
- "What's the best approach to securely manage these credentials in a .NET application?"
- "How should I implement configuration management for this application?"
- "Show me how to use .NET User Secrets for local development"

**Key Concepts to Implement:**
- Environment variables
- .NET User Secrets (for local dev)
- Configuration interfaces
- Dependency injection
- Azure Key Vault or AWS Secrets Manager (for production)

### Step 3: Implement Secure Configuration (45 minutes)

#### Create Configuration Structure

1. **Create appsettings.json:**
   - Ask Copilot: "Create an appsettings.json file for this application with all required configuration sections (without secrets)"

2. **Create Configuration Models:**
   - Ask Copilot: "Create strongly-typed configuration classes for database, payment, email, and cloud services"

3. **Initialize User Secrets:**
   ```powershell
   dotnet user-secrets init
   dotnet user-secrets set "DatabaseConfig:ConnectionString" "your-connection-string"
   # Repeat for all secrets
   ```

#### Refactor Each Service

**For each service file (DatabaseService, PaymentService, EmailService):**

1. Select the class with hard-coded secrets
2. Ask Copilot: "Refactor this class to use dependency injection and load credentials from configuration"
3. Review and apply the suggested changes
4. Verify the class no longer contains hard-coded secrets

**For AppConfig.cs:**

1. Ask Copilot: "Convert AppConfig to use IConfiguration and remove all hard-coded secrets"
2. Apply changes

#### Update Program.cs

1. Ask Copilot: "Update Program.cs to configure dependency injection and load configuration from appsettings and user secrets"
2. Ensure all services receive configuration through constructor injection

### Step 4: Verify Remediation (15 minutes)

#### Check for Remaining Secrets

1. **Using GitHub Copilot:**
   - Ask: "Scan the codebase again for any remaining exposed secrets"
   
2. **Using grep/search:**
   - Search for patterns like: "Password=", "Key=", "Secret=", "AKIA", "sk_live", "SG."

3. **Using GitHub Secret Scanning:**
   - Push your changes to a branch
   - Verify no new secret scanning alerts

#### Test Application Functionality

```powershell
dotnet build
dotnet run
```

**Verify:**
- ✓ Application builds without errors
- ✓ Application runs successfully
- ✓ Output matches baseline (same order flow)
- ✓ All services function correctly
- ✓ No secrets visible in console output

### Step 5: Document Changes (10 minutes)

Create a summary of:
1. Secrets identified
2. Remediation approach used
3. Configuration management strategy
4. Testing results
5. Lessons learned

## Common Issues and Solutions

### Issue: Application can't find configuration
**Solution:** Ensure user secrets are set correctly
```powershell
dotnet user-secrets list
```

### Issue: Dependency injection errors
**Solution:** Verify service registration in Program.cs
- Check that all configuration classes are registered
- Ensure services are registered with the correct lifetime

### Issue: NullReferenceException at runtime
**Solution:** 
- Verify all configuration values are set in user secrets
- Check that configuration binding is working correctly
- Use null-coalescing operators for optional config values

## Success Criteria

- [ ] No exposed secrets in any code files
- [ ] All configuration loaded from secure sources
- [ ] Application builds without errors
- [ ] Application runs and produces expected output
- [ ] GitHub Secret Scanning shows no alerts
- [ ] Code follows .NET security best practices
- [ ] Services use dependency injection
- [ ] Configuration is strongly-typed

## Additional Resources

- [.NET User Secrets Documentation](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [Configuration in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration)
- [Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [GitHub Secret Scanning](https://docs.github.com/en/code-security/secret-scanning)

## Need Help?

Use GitHub Copilot Chat to:
- Ask for clarification on any security concept
- Get code suggestions for specific patterns
- Debug configuration issues
- Learn more about best practices

Example prompts:
- "Explain why hard-coding secrets is dangerous"
- "Show me how to test if my configuration is loaded correctly"
- "What's the difference between User Secrets and environment variables?"
- "How do I implement Azure Key Vault in this application?"
