INSERT INTO app.Customer
VALUES
    ('Kevin', 'McCallister','671 Lincoln Ave','Winnetka','IL',60093),
    ('Long', 'Silvers','700 W Abram St', 'Arlington','TX',76013),
    ('Nancy','Drew','9909 Mystery Ave', 'Springfield', 'MO', '65619');

-- More names for testing if needed
    --('Phil','Young'),
    --('Wendy','Lou'),
    --('Susan','Barter'),
    --('Gwenneth','Jones'),
    --('Joe','Schmo');

INSERT INTO app.Store
VALUES
    ('99 Wayford Way', 'Arlington', 'TX',76013, 20, 40, 35),
    ('420 Chill Place', 'Denver', 'CO', 80239, 30, 10, 35);

-- OrderID auto incremented, insert customerID, StoreNumber, BurgerAmount, FriesAmount, and SodaAmount
INSERT INTO app.Orders
VALUES
    (1,1,3,2,1),
    (1,1,1,2,0),
    (3,2,3,2,1),
    (3,2,0,0,1);

SELECT * FROM app.Customer;
SELECT * FROM app.Orders;
SELECT * FROM app.Store;