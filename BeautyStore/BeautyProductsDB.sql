CREATE DATABASE Store;

CREATE TABLE BeautyProducts (
productId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
productName VARCHAR(100) NOT NULL,
price DECIMAL NOT NULL,
brands VARCHAR(250) NOT NULL,
sizes INT NOT NULL,
[description] VARCHAR(250) NOT NULL
)

CREATE TABLE Customers (
customerId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
customerName VARCHAR(50) NOT NULL,
phoneNumber VARCHAR(20) NOT NULL,
emailAddress VARCHAR(100) NOT NULL,
homeAddress VARCHAR(100) NOT NULL,
billingAddress VARCHAR(100) NOT NULL,
)

CREATE TABLE Inventories (
inventoriesId INT NOT NULL PRIMARY KEY IDENTITY,
quantity INT NOT NULL,
productId INT REFERENCES BeautyProducts(productId) NOT NULL,
locationId INT REFERENCES Locations(locationId) NOT NULL
)

CREATE TABLE Locations (
locationId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
locationName VARCHAR(100) NOT NULL,
[address] VARCHAR(100) NOT NULL
)

CREATE TABLE Items (
itemsId INT NOT NULL PRIMARY KEY IDENTITY,
quantity INT NOT NULL,
productId INT REFERENCES BeautyProducts(productId) NOT NULL,
orderId INT REFERENCES Orders(orderId) NOT NULL
)

CREATE TABLE Orders (
-- (1,1)means will increment by 1)
orderId INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
customerId INT,
order_date DATETIME NOT NULL,
locationId INT NOT NULL,
)

CREATE TABLE ShoppingCart (
shoppingCartId INT PRIMARY KEY IDENTITY,
customerId INT REFERENCES Customers(customerId) NOT NULL,
locationId INT REFERENCES Locations(locationId) NOT NULL,
productId INT REFERENCES BeautyProducts(productId) NOT NULL,
quantity INT NOT NULL
);

INSERT INTO Customers (customerName, phoneNumber, emailAddress, homeAddress, billingAddress) values
('Aldo D', '123-456-7890', 'aldoD@dotnet.com', 'sa puso daw niya', 'sa puso ng iba'),
('Yuan Z', '789-456-1230', 'yuanz@dotnet.com', 'sa house', 'sa house daw niya'),
('Aljen A', '456-788-1236', 'aljenA@dotnet.com', 'sa vegas daw', 'sa bahay daw nila');

INSERT INTO BeautyProducts (productName, price, brands, sizes, [description]) values
('Romance Parfum', 64, 'Ralph Lauren', 4, 'A floral perfume for women composed of notes that reflect the complexity of a sensual modern Romance.'),
('Sauvage Eau de Toilette', 80, 'Dior', 7, 'A radically fresh composition, both raw and noble.'),
('Viva La Juicy Le Bubbly Eau de Parfum', 79, 'Juicy Couture', 2, 'An effervescent, cheery, and addictive fragrance for women'),
('Eros Eau de Toilette', 72, 'Versace', 2, 'a fragrance that interprets the sublime masculinity through a luminous aura with an intense, vibrant and glowing freshness obtained from the combination of mint leaves, Italian lemon zest and green apple.');

INSERT INTO Locations (locationName, [address]) values
('Philippines', 'Sa dati kong bahay'),
('Texas', 'Sa bahay ko'),
('California', 'Sa bahay ni Niv');

INSERT INTO Orders (customerId, locationId, order_date) values
(1, 3, '20210201 01:31:01 PM'), (2, 2, '20200201 01:32:02 PM'), (3, 1, '20210101 02:31:01 AM'), (3, 2, '20210203 06:23:04 AM');

INSERT INTO Items (orderId, productId, quantity) values
(1, 2, 3),
(2, 3, 4),
(2, 1, 5),
(3, 4, 6);

INSERT INTO Inventories (locationId, productId, quantity) values
(1, 2, 25),
(2, 3, 50),
(3, 1, 100);

SELECT * FROM customers
SELECT * FROM BeautyProducts
SELECT * FROM Locations
SELECT * FROM Orders
SELECT * FROM Inventories
SELECT * FROM Items
SELECT * FROM ShoppingCart
GO;

--Drop all tables
drop table Customers;
drop table BeautyProducts;
drop table Orders;
drop table Locations;
drop table Inventories;
drop table Items;
drop table ShoppingCart;



