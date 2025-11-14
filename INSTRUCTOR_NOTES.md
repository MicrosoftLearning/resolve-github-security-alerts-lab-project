# Instructor Notes - Contoso Order Processor Lab

## Lab Overview

This training lab teaches developers how to identify and resolve GitHub Secret Scanning alerts using GitHub Copilot. The ContosoOrderProcessor is a realistic .NET 9.0 e-commerce application with intentional security vulnerabilities.

## Learning Objectives

By completing this lab, students will:

1. Understand common security vulnerabilities in enterprise applications
2. Use GitHub Secret Scanning to identify exposed credentials
3. Leverage GitHub Copilot to assist with secure code refactoring
4. Implement secure configuration management in .NET applications
5. Apply security best practices for credential storage
6. Validate that security fixes don't break functionality

## Lab Duration

**Estimated Time:** 90-120 minutes

- Setup and familiarization: 15 minutes
- Identifying exposed secrets: 15 minutes
- Planning remediation: 10 minutes
- Implementation: 45 minutes
- Testing and verification: 15 minutes
- Documentation and review: 10 minutes

## Prerequisites for Students

### Required Knowledge

- Basic C# and .NET development
- Understanding of Object-Oriented Programming
- Familiarity with Visual Studio Code or Visual Studio
- Basic understanding of environment variables and configuration

### Required Tools

- .NET 9.0 SDK installed
- Git installed
- Visual Studio Code or Visual Studio 2022
- GitHub account with Secret Scanning enabled
- GitHub Copilot subscription (or trial)

### Optional but Helpful

- Azure account (for Azure Key Vault demonstration)
- Understanding of dependency injection
- Experience with API integrations

## Technical Details

### Application Architecture

```plaintext
ContosoOrderProcessor/
├── Configuration/       # App configuration with exposed secrets
├── Models/             # Data models (Customer, Order, OrderItem)
├── Security/           # Security validation and fraud detection
├── Services/           # Business logic services
│   ├── DatabaseService.cs    # Database operations
│   ├── PaymentService.cs     # Payment processing
│   └── EmailService.cs       # Notification services
└── Program.cs          # Application entry point and orchestration
```

### Intentional Vulnerabilities

The application contains **10 types** of exposed secrets across 4 files:

#### High-Priority Secrets (Critical Impact)

1. **SQL Server Connection String** (DatabaseService.cs, line 9)

   - Type: Azure SQL Database credentials
   - Risk: Database access, data breach
   - Detection: GitHub Secret Scanning ✓

2. **Stripe Live API Key** (PaymentService.cs, line 9)

   - Type: Payment processor credentials
   - Risk: Unauthorized charges, financial fraud
   - Detection: GitHub Secret Scanning ✓

3. **PayPal API Credentials** (PaymentService.cs, lines 12-13)

   - Type: Client ID and Secret
   - Risk: Unauthorized payment access
   - Detection: GitHub Secret Scanning ✓

4. **SendGrid API Key** (EmailService.cs, line 9)

   - Type: Email service credentials
   - Risk: Spam sending, reputation damage
   - Detection: GitHub Secret Scanning ✓

5. **AWS Credentials** (AppConfig.cs, lines 10-11)

   - Type: Access Key ID and Secret Access Key
   - Risk: AWS resource access, cost impact
   - Detection: GitHub Secret Scanning ✓

6. **Azure Storage Connection String** (AppConfig.cs, line 15)

   - Type: Storage account credentials
   - Risk: Data access, storage manipulation
   - Detection: GitHub Secret Scanning ✓

#### Medium-Priority Secrets

1. **SMTP Credentials** (EmailService.cs, lines 12-14)

   - Type: Email server credentials
   - Risk: Email spoofing

2. **Twilio Credentials** (AppConfig.cs, lines 18-19)

   - Type: Account SID and Auth Token
   - Risk: SMS/phone service abuse
   - Detection: GitHub Secret Scanning ✓

3. **JWT Secret Key** (AppConfig.cs, line 23)

   - Type: Token signing key
   - Risk: Token forgery, authentication bypass

4. **Encryption Keys** (AppConfig.cs, lines 26-27)

    - Type: Symmetric encryption keys
    - Risk: Data decryption, privacy breach

## Application Functionality

### Normal Operation Flow

1. **Configuration Loading**: Loads app configuration and validates settings
2. **Customer Retrieval**: Fetches customer data from database
3. **Customer Validation**: Validates customer information and email format
4. **Order Creation**: Creates order with multiple items ($148.94 total)
5. **Order Validation**: Validates order amount, items, and payment method
6. **Fraud Detection**: Performs risk assessment on order
7. **Payment Processing**: Processes payment via Stripe
8. **Database Persistence**: Saves order and logs transaction
9. **Email Notification**: Sends order confirmation via SendGrid
10. **Shipping Notification**: Updates status and sends tracking info

### Verifiable Output

The application produces consistent, verifiable output including:

- **Order ID**: Dynamic (timestamp-based)
- **Customer**: John Doe (john.doe@example.com)
- **Total Amount**: $148.94 (fixed)
- **Items**: 3 items (Mouse, Cable, Stand)
- **Payment Method**: Stripe
- **Status Progression**: Pending → Payment Confirmed → Confirmed → Shipped
- **Transaction ID**: Dynamic (timestamp + GUID)
- **Tracking Number**: Dynamic (GUID-based)

## Teaching Strategy

### Phase 1: Discovery (15 minutes)

**Instructor Actions:**

1. Have students clone/fork the repository
2. Guide them to run the application to see it works
3. Demonstrate GitHub Secret Scanning in the repository
4. Show how to use GitHub Copilot to identify issues

**Key Points to Emphasize:**

- Real-world applications often have similar vulnerabilities
- Secrets can be accidentally committed by anyone
- GitHub tools help identify issues automatically
- Manual code review is still important

### Phase 2: Analysis (10 minutes)

**Instructor Actions:**

1. Review the identified secrets together
2. Discuss the risk level of each type of secret
3. Explain real-world consequences of exposed secrets
4. Introduce secure configuration concepts

**Discussion Topics:**

- "What could an attacker do with these credentials?"
- "Why is hard-coding secrets problematic?"
- "What's the difference between secrets and configuration?"
- "Where should secrets be stored?"

### Phase 3: Implementation (45 minutes)

**Instructor Actions:**

1. Demonstrate creating appsettings.json (without secrets)
2. Show .NET User Secrets initialization
3. Guide refactoring of one service class
4. Have students complete remaining refactoring
5. Circulate to help with issues

**Common Student Challenges:**

- Understanding dependency injection
- Configuration binding syntax
- Debugging NullReferenceException errors
- Knowing which values are secrets vs. config

**Instructor Tips:**

- Pair students for peer learning
- Use GitHub Copilot extensively for suggestions
- Show how to test configuration loading
- Emphasize the importance of small, testable changes

### Phase 4: Verification (15 minutes)

**Instructor Actions:**

1. Show how to verify no secrets remain
2. Demonstrate running and comparing output
3. Review GitHub Secret Scanning results
4. Test different configuration scenarios

**Verification Checklist:**

- [ ] Application builds successfully
- [ ] Application runs without errors
- [ ] Output matches original behavior
- [ ] No hard-coded secrets in any file
- [ ] Configuration properly structured
- [ ] GitHub Secret Scanning shows 0 alerts

### Phase 5: Reflection (10 minutes)

**Instructor Actions:**

1. Facilitate group discussion
2. Review best practices learned
3. Discuss production deployment strategies
4. Q&A session

**Discussion Questions:**

- "What was the most challenging part?"
- "How would you handle secrets in production?"
- "What other security issues might exist?"
- "How can we prevent secrets from being committed?"

## Extension Activities

### For Advanced Students

1. **Implement Azure Key Vault Integration**

   - Add Azure.Security.KeyVault packages
   - Configure Key Vault client
   - Retrieve secrets at runtime

2. **Add Pre-commit Hooks**

   - Install git-secrets or similar
   - Configure to detect secrets before commit
   - Test with sample secrets

3. **Create CI/CD Pipeline**

   - Add GitHub Actions workflow
   - Include secret scanning step
   - Implement automated testing

4. **Implement Rotation Strategy**

   - Design secret rotation process
   - Add configuration for multiple key versions
   - Document rotation procedures

### For Struggling Students

1. **Start with One Service**

   - Focus on DatabaseService only
   - Complete refactoring with instructor help
   - Apply same pattern to other services

2. **Use Template Code**

   - Provide sample configuration class
   - Give example dependency injection code
   - Focus on understanding over implementation

## Assessment Criteria

### Core Requirements (Must Complete)

- [ ] All hard-coded secrets removed
- [ ] Application builds without errors
- [ ] Application runs and produces correct output
- [ ] GitHub Secret Scanning shows 0 alerts
- [ ] Basic configuration structure implemented

### Advanced Requirements (Optional)

- [ ] Strongly-typed configuration classes
- [ ] Proper dependency injection throughout
- [ ] Configuration validation implemented
- [ ] Error handling for missing configuration
- [ ] Documentation of changes made

## Troubleshooting Guide

### Common Issues

**Issue:** "Configuration value is null"

- **Cause:** User secret not set or wrong key name
- **Solution:** Use `dotnet user-secrets list` to verify

**Issue:** "Service not registered for dependency injection"

- **Cause:** Missing service registration in Program.cs
- **Solution:** Add `services.AddSingleton<IService, Service>()`

**Issue:** "Cannot find appsettings.json"

- **Cause:** File not copied to output directory
- **Solution:** Verify .csproj includes the file

**Issue:** "Application still shows secrets in output"

- **Cause:** Logging configuration values
- **Solution:** Remove or sanitize configuration logging

## Additional Resources for Students

### Documentation Links

- [Microsoft: Configuration in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration)
- [Microsoft: Safe Storage of App Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [GitHub: About Secret Scanning](https://docs.github.com/en/code-security/secret-scanning/about-secret-scanning)
- [OWASP: Sensitive Data Exposure](https://owasp.org/www-project-top-ten/2017/A3_2017-Sensitive_Data_Exposure)

### Video Tutorials

- .NET User Secrets overview
- Dependency Injection in .NET
- Azure Key Vault integration

## Lab Variants

### Variant 1: Full Production Deployment

- Add Azure Key Vault integration
- Configure managed identities
- Deploy to Azure App Service
- Implement secret rotation

### Variant 2: Multi-Environment Configuration

- Create dev/staging/prod configurations
- Implement environment-specific settings
- Use Azure DevOps variable groups
- Configure deployment pipelines

### Variant 3: Security Audit Focus

- Identify ALL security issues (not just secrets)
- Implement comprehensive security fixes
- Add security testing
- Create security documentation

## Success Metrics

Students successfully complete the lab when they:

1. ✓ Identify all 10 types of exposed secrets
2. ✓ Understand why each secret poses a risk
3. ✓ Successfully refactor code to remove secrets
4. ✓ Implement secure configuration management
5. ✓ Verify application functionality is preserved
6. ✓ Pass GitHub Secret Scanning with 0 alerts
7. ✓ Can explain their approach and decisions
8. ✓ Apply lessons to their own projects

## Instructor Checklist

**Before the Lab:**

- [ ] Verify all prerequisites are installed
- [ ] Test the application on target environment
- [ ] Ensure GitHub Secret Scanning is enabled
- [ ] Prepare demo environment
- [ ] Review GitHub Copilot features
- [ ] Set up timer for activities

**During the Lab:**

- [ ] Demonstrate initial application run
- [ ] Guide through discovery phase
- [ ] Monitor student progress
- [ ] Provide hints without giving answers
- [ ] Encourage use of GitHub Copilot
- [ ] Take notes on common issues

**After the Lab:**

- [ ] Collect feedback from students
- [ ] Review challenging areas
- [ ] Update lab materials as needed
- [ ] Share additional resources
- [ ] Assess learning outcomes

## Feedback and Improvements

This lab is designed to be updated based on:

- Student feedback and difficulty levels
- Changes in GitHub Security features
- Updates to .NET and dependencies
- Emerging security best practices
- Real-world incident examples

Please document any issues or suggestions for future iterations.
