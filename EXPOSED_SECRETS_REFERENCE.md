# Exposed Secrets Reference - Contoso Order Processor

This document provides a reference for the intentional security vulnerabilities included in the ContosoOrderProcessor application for training purposes.

## Purpose

This application demonstrates common security issues that can be detected by GitHub Secret Scanning. The exposed secrets are intentional and should be identified and remediated as part of the training lab.

## Exposed Secrets by File

### 1. Services/DatabaseService.cs

- **Type**: Database Connection String
- **Issue**: Hard-coded SQL Server connection string with credentials
- **Line**: 9
- **Value Type**: Azure SQL Database credentials
- **Severity**: Critical

### 2. Services/PaymentService.cs

- **Type**: Payment API Keys
- **Issue**: Hard-coded Stripe and PayPal API credentials
- **Lines**: 9, 12-13
- **Value Types**:
  - Stripe Live API Key (sk_live_*)
  - PayPal Client ID and Secret
- **Severity**: Critical

### 3. Services/EmailService.cs

- **Type**: Email Service Credentials
- **Issue**: Hard-coded SendGrid API key and SMTP credentials
- **Lines**: 9, 12-14
- **Value Types**:
  - SendGrid API Key (SG.*)
  - SMTP server credentials
- **Severity**: High

### 4. Configuration/AppConfig.cs

- **Type**: Multiple Cloud and Service Credentials
- **Issue**: Hard-coded credentials for various services
- **Lines**: 10-26
- **Value Types**:
  - AWS Access Key ID and Secret Access Key
  - Azure Storage Connection String
  - Twilio Account SID and Auth Token
  - JWT Secret Key
  - Encryption Key and IV
- **Severity**: Critical

## Expected Detections

GitHub Secret Scanning should detect the following patterns:

1. ✓ Azure SQL Database connection strings
2. ✓ Stripe API keys (live keys)
3. ✓ PayPal API credentials
4. ✓ SendGrid API keys
5. ✓ AWS credentials (Access Key ID and Secret Access Key)
6. ✓ Azure Storage connection strings
7. ✓ Twilio credentials

## Remediation Approach

Students should learn to:

1. Use environment variables for sensitive configuration
2. Implement secure configuration management (e.g., Azure Key Vault, AWS Secrets Manager)
3. Use .NET User Secrets for local development
4. Configure proper .gitignore patterns
5. Implement configuration interfaces and dependency injection

## Verification

After remediation, the application should:

- ✓ Continue to run successfully
- ✓ Produce the same verifiable output
- ✓ Have fewer exposed secrets in the codebase
- ✓ Load credentials from secure configuration sources

## Sample Output

The application produces consistent, verifiable output including:

- Order ID (with timestamp)
- Customer information (Lee Gu, lee.gu@example.com)
- Order amount ($148.94)
- Transaction ID
- Tracking number
- Status updates through the workflow

This output can be verified before and after security remediation to confirm the application functions correctly.

## Note

All credentials shown in this codebase are fictional and created specifically for training purposes. They do not represent real credentials and should not be used in any production environment.
