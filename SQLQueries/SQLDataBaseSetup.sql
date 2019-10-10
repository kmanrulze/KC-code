CREATE SCHEMA app;
GO

CREATE TABLE app.Customer
(
    CustomerID INT PRIMARY KEY,
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25)
);
CREATE TABLE app.CustomerAddress
(
    CustomerID INT FOREIGN KEY REFERENCES app.Customer(CustomerID),
    Street NVARCHAR(50),
    City NVARCHAR(25),
    State NVARCHAR(25),
    Zip NVARCHAR(9)
);
CREATE TABLE app.Product
(
    ProductID INT PRIMARY KEY,
    Burgers INT,
    Fries INT,
    Sodas INT
);
CREATE TABLE app.CustomerProduct
(
    CustomerID INT FOREIGN KEY REFERENCES app.Customer(CustomerID),
    ProductID INT FOREIGN KEY REFERENCES app.Product(ProductID)
);
CREATE TABLE app.CustomerHistory
(
    OrderID INT PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES app.Customer(CustomerID),
    Burgers INT,
    Fries INT,
    Soda INT
);
CREATE TABLE app.Store
(
    StoreNumber INT PRIMARY KEY,
    Street NVARCHAR(50),
    City NVARCHAR(25),
    State NVARCHAR(25),
    Zip NVARCHAR(9)
);
CREATE TABLE app.ProductLocation
(
    StoreNumber INT FOREIGN KEY REFERENCES app.Store(StoreNumber),
    ProductID INT FOREIGN KEY REFERENCES app.Product(ProductID)
);
CREATE TABLE app.Manager
(
    ManagerID INT PRIMARY KEY,
    StoreNumber INT FOREIGN KEY REFERENCES app.Store(StoreNumber),
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25)
);