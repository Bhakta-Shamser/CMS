# CMS Project

## Overview
The CMS (Candidate Management System) project is a web-based application designed to manage candidate records efficiently. It supports database operations, robust query handling, and centralized logging. The architecture follows Clean Architecture principles, ensuring separation of concerns and scalability.

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
1. **CMS.Domain**: Core business logic and entities (e.g., `Candidate`).
2. **CMS.Contract**: Interfaces and DTOs.
3. **CMS.Application**: Business rules and use case implementations.
4. **CMS.Infrastructure**: Data access and integrations with external systems.
5. **CMS.API**: Endpoints for system interaction.

## Setup and Usage

### Prerequisites
- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or compatible IDE

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Bhakta-Shamser/CMS.git

## Suggested Improvements

- **Caching with Redis**: If the system experiences performance issues due to increased size and slow retrieval times, implementing caching with Redis can significantly speed up data access.
  
- **UnitOfWork Pattern**: Consider adopting the UnitOfWork pattern to manage transactions more effectively, ensuring better consistency and easier management of database operations.
- **Adding Auditing to Domain Entities**: While designing domain entities, we can also create an auditing attribute on the class to track changes such as who created or modified the entity, and when it was created or modified. This can be useful for maintaining historical data, ensuring compliance, and supporting debugging and reporting needs.

## **Development Time Log**

- **1 hour** on _2024-12-07_
- **5 hours** on _2024-12-08_

_**Total time spent:** 6 hours_
