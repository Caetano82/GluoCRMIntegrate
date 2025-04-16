# 🔗 ERP - Gluo CRM Integration (C#)

This project provides an integration between an internal ERP system and **Gluo CRM**, developed entirely in **C#**. It enables seamless data synchronization, allowing both platforms to stay in sync and operate more efficiently.

## 🧩 Purpose

The goal of this project is to automate the flow of business information between the ERP and Gluo CRM, ensuring consistency across systems without manual intervention.

## 🚀 Features

- Authentication and secure communication with Gluo CRM API  
- Data mapping and transformation between ERP and CRM formats  
- Scheduled or on-demand synchronization of customer, sales, and product data  
- Error handling, retries, and logging for audit and traceability  
- Modular architecture ready for scaling and new data types

## 🛠️ Technologies

- **C# (.NET 6/7/8)**  
- **HttpClient** for API communication  
- **Entity Framework Core** (optional, if persistence is needed)  
- **FluentValidation** for input validation  
- **Serilog / Microsoft.Extensions.Logging** for structured logging  
- **AutoMapper** for object mapping  
- **JWT / OAuth 2.0** support (if required by the Gluo CRM API)

## 📦 Project Structure

