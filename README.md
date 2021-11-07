REST API methods
- GetProducts 
	v1 - returns list of all products in database
	V2 - returns list of products with pagination, parameters: pageNumber (int, optional, default 1), pageSize (int, optional, represents number of product per page, default 10)
- GetProduct
	- returns product with selected ID, parameters: ID (GUID, required)
- UpdateProductAsync
	- update of product description, parameters: ID (GUID, required), description (string, optional - it is possible to store empty description)

Solution steps
1. Create database with initial data seed
2. Create Web application API project, add versioning
3. Create dbContext, Product model based on DB model and ProductController with http methods
4. Create ProductModule and implement business logic
5. Create XUnit Test project, prepare mock data and implement unit tests
6. Create error logging

I used EntityFramework for data access and Serilog for logging.
For switch between DB and mock data I used dependency injection.




