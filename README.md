# E-commerce Microservices

### Deploy to Azure Kubernetes Services (AKS) through CI/CD Azure Pipelines
| Image | Status|
| ------------- | ------------- |
| Catalog API | [![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/catalogapi-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=15&branchName=main) |
| Basket API | [![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/basketapi-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=5&branchName=main) |
| Discount API | [![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/discountapi-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=7&branchName=main) |
| Ordering API | [![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/orderingapi-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=8&branchName=main) |
| Discount GRPC |[![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/discountgrpc-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=13&branchName=main) |
| Ocelot API Gateway |[![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/ocelotapigw-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=14&branchName=main) |
| Shopping Agreggator |[![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/shoppingaggregatorgateway-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=12&branchName=main) |
|Shopping Web |[![Build Status](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_apis/build/status/shoppingwebapp-pipeline?branchName=main)](https://dev.azure.com/riannegreiros/EcommerceMicroservices/_build/latest?definitionId=6&branchName=main) |

## Features

### Catalog microservice which includes

* ASP.NET Core Web API application
* REST API principles, CRUD operations
* **MongoDB database** connection and containerization
* Repository Pattern Implementation
* Swagger Open API implementation

### Basket microservice which includes

* ASP.NET Web API application
* REST API principles, CRUD operations
* **Redis database** connection and containerization
* Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**
  
### Discount microservice which includes

* ASP.NET **Grpc Server** application
* Build a Highly Performant **inter-service gRPC Communication** with Basket Microservice
* Exposing Grpc Services with creating **Protobuf messages**
* Using **Dapper for micro-orm implementation** to simplify data access and ensure high performance
* **PostgreSQL database** connection and containerization

### Microservices Communication

* Sync inter-service **gRPC Communication**
* Async Microservices Communication with **RabbitMQ Message-Broker Service**
* Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
* Using **MassTransit** for abstraction over RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices
* Create **RabbitMQ EventBus.Messages library** and add references Microservices

### Ordering Microservice

* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, FluentValidation and AutoMapper packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup

### API Gateway Ocelot Microservice

* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways
* Run multiple different **API Gateway/BFF** container types 
* The Gateway aggregation pattern in Shopping.Aggregator

### WebUI ShoppingApp Microservice

* ASP.NET Core Web Application with Bootstrap 4 and Razor template
* Call **Ocelot APIs with HttpClientFactory** and **Polly**

## How to run

### Prerequesites

* [.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Docker](https://docs.docker.com/get-docker/)

1 - At the root directory which include docker-compose.yml, run:

```bash
docker-compose up --build
```

2 - Wait for docker compose all microservices.

3 - You can launch the microservices in the URLS below:

* **Catalog API -> <http://localhost:8000/swagger/index.html>**
* **Basket API -> <http://localhost:8001/swagger/index.html>**
* **Discount API -> <http://localhost:8002/swagger/index.html>**
* **Ordering API -> <http://localhost:8004/swagger/index.html>**
* **Shopping.Aggregator -> <http://localhost:8005/swagger/index.html>**
* **API Gateway -> <http://localhost:8010/Catalog>**
* **Rabbit Management Dashboard -> <http://localhost:15672>**   -- guest/guest
* **Portainer -> <http://localhost:9000>**   -- admin/admin1234
* **pgAdmin PostgreSQL -> <http://localhost:5050>**   -- admin@admin.com/admin1234

* **Web UI -> <http://localhost:8006>**

![Web UI Screenshot](/WebApps/Shopping/Public/documentation/images/shoppingappScreenshot.png)
