CREATE TABLE Customer (
    customerID INT PRIMARY KEY,
    firstName VARCHAR NOT NULL,
    lastName VARCHAR NOT NULL
    );

CREATE TABLE CustomerAddresses (
    customerID INT PRIMARY KEY,
    street VARCHAR NOT NULL,
    city VARCHAR NOT NULL,
    state VARCHAR NOT NULL,
    zip VARCHAR NOT NULL
    );

CREATE TABLE StoreAddresses (
    storeNumber INT PRIMARY KEY,
    street VARCHAR NOT NULL,
    city VARCHAR NOT NULL,
    state VARCHAR NOT NULL,
    zip VARCHAR NOT NULL
    );

