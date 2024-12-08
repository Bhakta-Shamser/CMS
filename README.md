# CMS Project

## Overview
The CMS (Candidate Management System) project is a web-based application designed to manage candidate records efficiently. It supports CRUD operations, robust query handling, and centralized logging. The architecture follows Clean Architecture principles, ensuring separation of concerns and scalability.

## Features
- **Domain-Driven Design**: Separation of concerns across layers.
- **MediatR**: Implements CQRS for handling commands and queries.
- **Serilog**: Centralized logging with configurable sinks.
- **Integration Tests**: Reliable end-to-end testing.
- **Extensible Repositories**: Flexible data access design.

## Technologies
- **.NET 8**
- **Entity Framework Core**
- **MediatR**
- **Serilog**
- **xUnit** (testing)
- **FluentAssertions**

## Layers
1. **Domain**: Core business logic and entities (e.g., `Candidate`).
2. **Application**: Business rules and use case implementations.
3. **Infrastructure**: Data access and integrations with external systems.
4. **API**: Endpoints for system interaction.

## Setup and Usage

### Prerequisites
- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or compatible IDE

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Bhakta-Shamser/CMS.git
