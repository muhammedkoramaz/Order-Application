# OrderProductApplication
Basic microservice application.
 ## 3rd Party Libraries

- MongoDB
- FluentValidation
- FluentAssertions
- Moq
- Ocelot
- Swagger

# Endpoints

## Customers
| Method | Endpoint                | Desc                                                     |
| -----------|-------------------------|----------------------------------------------------------|
| GET | /api/Customer| Get customers
| GET | /api/Customer/Search/{id}| Get by id                            
| POST | /api/Customer| Create customer 
| DELETE | /api/Customer/{id}| Delete customer  
| PUT | /api/Customer| Update customer       


## Orders
| Method | Endpoint                | Desc                                                     |
| -----------|-------------------------|----------------------------------------------------------|
| GET  | /api/Order| Get orders
| GET | /api/Order/{id}| Get by order id                            
| POST | /api/Order| Create order 
| DELETE | /api/Order/{id}| Delete order  
| PUT | /api/Order| Update content


## Gateway Api
| Method | Endpoint                |      Desc                                                |
| -----------|-------------------------|----------------------------------------------------------|
| GET POST | /customer-service| Get, Post Customer
| GET DELETE PUT| /customer-service/{id}| Get, Delete, Put customer
| GET POST  | /order-service| Get, Post Order
| GET PUT DELETE | /order-service/{id}| Get, Delete, Put order
  
