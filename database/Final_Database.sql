CREATE DATABASE car_traders;
USE car_traders;

CREATE TABLE users(
	UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100)
);

CREATE TABLE Cars (
    CarID INT PRIMARY KEY AUTO_INCREMENT,
    Brand VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL
);

CREATE TABLE CarParts (
    PartID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status ENUM('Pending', 'Processing', 'Shipped', 'Delivered','Cancelled') DEFAULT 'Pending',
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY AUTO_INCREMENT,
    OrderID INT,
    ItemType ENUM('Car', 'CarPart') NOT NULL,
    ItemID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);




INSERT INTO users (Username, Password, FirstName, LastName, Email)
VALUES ('admin', 'admin123', 'John', 'Doe', 'admin@example.com');

INSERT INTO users (Username, Password, FirstName, LastName, Email)
VALUES ('customer1', 'customer123', 'Jane', 'Smith', 'customer1@example.com');

CREATE DATABASE car_traders;
USE car_traders;

CREATE TABLE users(
	UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100)
);

CREATE TABLE Cars (
    CarID INT PRIMARY KEY AUTO_INCREMENT,
    Brand VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL
);

CREATE TABLE CarParts (
    PartID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status ENUM('Pending', 'Processing', 'Shipped', 'Delivered','Cancelled') DEFAULT 'Pending',
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY AUTO_INCREMENT,
    OrderID INT,
    ItemType ENUM('Car', 'CarPart') NOT NULL,
    ItemID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);




INSERT INTO users (Username, Password, FirstName, LastName, Email)
VALUES ('admin', 'admin123', 'John', 'Doe', 'admin@example.com');

INSERT INTO Cars (Brand, Model, Year, Price, StockQuantity)
VALUES 
('Toyota', 'Corolla', 2021, 20000.00, 15),
('Honda', 'Civic', 2022, 22000.00, 10),
('Ford', 'Mustang', 2020, 30000.00, 5),
('Chevrolet', 'Camaro', 2021, 35000.00, 8),
('BMW', 'X5', 2023, 60000.00, 7),
('Audi', 'A4', 2022, 40000.00, 12),
('Mercedes-Benz', 'C-Class', 2021, 45000.00, 6),
('Hyundai', 'Elantra', 2023, 21000.00, 20),
('Nissan', 'Altima', 2022, 23000.00, 14),
('Tesla', 'Model 3', 2023, 55000.00, 9);


INSERT INTO CarParts (Name, Description, Price, StockQuantity) VALUES
('Brake Pad', 'High-quality brake pad for cars', 29.99, 150),
('Oil Filter', 'Oil filter for various car models', 14.99, 200),
('Headlight Bulb', 'LED headlight bulb', 19.99, 75),
('Air Filter', 'Engine air filter', 12.49, 100),
('Spark Plug', 'Iridium spark plug', 8.99, 250),
('Battery', 'Car battery 12V', 89.99, 60),
('Alternator', '12V alternator', 139.99, 30),
('Radiator', 'Cooling radiator for cars', 199.99, 20),
('Brake Rotor', 'Front brake rotor', 89.99, 40),
('Transmission Fluid', 'Automatic transmission fluid', 24.99, 120);



INSERT INTO users (Username, Password, FirstName, LastName, Email) VALUES
('customer1', 'customer123', 'Jane', 'Smith', 'customer1@example.com'),
('customer2', 'pass456', 'Mike', 'Johnson', 'mike.j@example.com'),
('customer3', 'securepass', 'Emily', 'Brown', 'emily.b@example.com'),
('customer4', 'car123', 'David', 'Wilson', 'david.w@example.com'),
('customer5', 'parts789', 'Sarah', 'Taylor', 'sarah.t@example.com');


INSERT INTO Orders (UserID, TotalAmount, Status) VALUES
(2, 20000.00, 'Delivered'),
(3, 23999.98, 'Shipped'),
(4, 35000.00, 'Processing'),
(5, 22089.98, 'Pending'),
(2, 55000.00, 'Delivered'),
(3, 40149.97, 'Shipped');


INSERT INTO OrderItems (OrderID, ItemType, ItemID, Quantity, Price) VALUES
(1, 'Car', 1, 1, 20000.00),
(2, 'Car', 2, 1, 22000.00),
(2, 'CarPart', 1, 4, 29.99),
(2, 'CarPart', 2, 10, 14.99),
(3, 'Car', 3, 1, 30000.00),
(3, 'CarPart', 6, 1, 89.99),
(4, 'Car', 2, 1, 22000.00),
(4, 'CarPart', 3, 3, 19.99),
(4, 'CarPart', 4, 2, 12.49),
(5, 'Car', 10, 1, 55000.00),
(6, 'Car', 6, 1, 40000.00),
(6, 'CarPart', 5, 10, 8.99),
(6, 'CarPart', 7, 1, 139.99);
