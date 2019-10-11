CREATE SCHEMA app;
GO

CREATE TABLE app.Customer
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(25) NOT NULL,
    LastName NVARCHAR(25) NOT NULL,
    Street NVARCHAR(50),
    City NVARCHAR(25),
    State NVARCHAR(25),
    Zip NVARCHAR(5)
);
CREATE TABLE app.Store
(
    StoreNumber INT IDENTITY(1,1) PRIMARY KEY,
    Street NVARCHAR(50),
    City NVARCHAR(25),
    State NVARCHAR(25),
    Zip NVARCHAR(5),
    BurgerAmount INT,
    FriesAmount INT,
    SodaAmount INT
);
CREATE TABLE app.Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES app.Customer(CustomerID),
    StoreNumber INT FOREIGN KEY REFERENCES app.Store(StoreNumber),
    BurgerAmount INT,
    FriesAmount INT,
    SodaAmount INT
);
CREATE TABLE app.Manager
(
    ManagerID INT IDENTITY(1,1) PRIMARY KEY,
    StoreNumber INT UNIQUE FOREIGN KEY REFERENCES app.Store(StoreNumber),
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25)
);