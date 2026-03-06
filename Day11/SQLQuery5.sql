--Employees and Departments (LEFT JOIN)--Tables:--Employees (EmpID, EmpName, Salary, DeptID)--Departments (DeptID, DeptName)--Problem Statement:--Write a query to display all employees along with their department names.--If an employee is not assigned to any department, still display the employee details.use sql;create table employees(EmpID int not null primary key identity(1,1),EmpName varchar(10),Salary int,DeptID int constraint fr_ky references Departments(DeptID));insert  into Employees (EmpName, Salary, DeptID)
values 
('rahul', 75000, 102),
('nita', 60000, 101),
('soha', 85000, 102),
('ved', 55000, 104),
('sanvi', 65000, 103);

insert  into Employees (EmpName, Salary)
values 
('Bhushan', 75000),
('ketan', 45000);
select * from Employees;create table  Departments(DeptID int  primary key ,DeptName varchar(20));insert into Departments (DeptID, DeptName)
values 
(101, 'Human Resources'),
(102, 'Engineering'),
(103, 'Marketing'),
(104, 'Finance'),
(105, 'Sales');

select * from Departments;

select e.EmpName,d.DeptName
from employees e
LEFT JOIN Departments d
on e.DeptID= d.DeptID;
--3️⃣ Orders and Customers (INNER JOIN with Condition)--Tables:--Customers (CustomerID, CustomerName, City)create table Customers(CustomerID int not null primary key identity(1,1),CustomerName varchar(10),City varchar(10));insert into Customers (CustomerName, City)
values 
('John Doe', 'New York'),
('Jane Smith', 'London'),
('Sam Wilson', 'Mumbai'),
('Emma Brown', 'Sydney'),
('Chris Lee', 'Tokyo');select * from Customers;--Orders (OrderID, CustomerID, OrderDate, Amount)create table Orders(OrderID int not null primary key identity(1,1),CustomerID int constraint Cfr_ky references Customers(CustomerID),Amount  int );ALTER TABLE Orders ADD OrderDate DATE;INSERT INTO Orders (CustomerID, Amount, OrderDate)
VALUES 
(1, 500, '2025-02-15'),
(2, 1200, '2025-03-10'),
(3, 300, '2024-12-20'), 
(5, 450, '2025-04-22');select * from Orders;select c.CustomerName, o.OrderDate, o.Amount
from Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '2025-01-01';--Problem Statement:--Write a query to display Customer Name, Order Date, and Amount for all orders placed after '2025-01-01'.--4️⃣ Product and Category (RIGHT JOIN)--Tables:--Products (ProductID, ProductName, CategoryID, Price)--Categories (CategoryID, CategoryName)--Problem Statement:--Write a query to display all categories and their products.--Include categories even if they do not have any products.create table Categories (
    CategoryID int not null primary key identity(1,1),
    CategoryName varchar(20)
);

insert into Categories (CategoryName)
values 
('Electronics'),
('Clothing'),
('Books'),
('Toys'),
('Home Decor');

select * from Categories;

create table Products (
    ProductID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    ProductName varchar(20),
    CategoryID int CONSTRAINT Pfr_ky REFERENCES Categories(CategoryID),
    Price int
);

insert into Products (ProductName, CategoryID, Price)
values 
('Smartphone', 1, 6999),
('Laptop', 1, 9999),
('Watch', 2, 250),
('pendrive', 3, 899),
('ps5', 4, 50000);
select * from Products;select c.CategoryName, p.ProductName,p.Price
from Products p
right join Categories c ON p.CategoryID = c.CategoryID;--5️⃣ Self Join (Employee – Manager)--Table:--Employees (EmpID, EmpName, ManagerID)--Problem Statement:--Write a query to display Employee Name and their Manager Name using a self join.alter table Employees ADD ManagerID int;alter table Employees
add constraint FK_Manager 
foreign key (ManagerID) REFERENCES Employees(EmpID);select* from employees;update Employees 
set ManagerID = 1 
where EmpID IN (2, 3);update Employees 
set ManagerID = 2 
where EmpID IN (4, 5);update Employees 
set ManagerID = 3
where EmpID IN (1, 6);--self joinselect  e.EmpName as Employee,  M.EmpName as Manager
from Employees E
left join Employees M ON E.ManagerID = M.EmpID;--6️⃣ Multiple JOIN (Banking System)--Tables:--Customers (CustomerID, CustomerName)--Accounts (AccountID, CustomerID, BranchID, Balance)--Branches (BranchID, BranchName)--Problem Statement:--Write a query to display Customer Name, Account ID, Branch Name, and Balance for all customers who have accounts.--If you want, I can also provide:--✔ Sample table creation scriptscreate table customerss (
    customerid int primary key,
    customername varchar(255)
);
insert into customerss (customerid, customername) values 
(10, 'amit sharma'),
(11, 'priya nair'),
(12, 'rohan gupta'),
(13, 'sneha patil'),
(14, 'vikram singh');
create table branches (
    branchid int primary key,
    branchname varchar(255)
);

insert into branches (branchid, branchname) values 
(1, 'downtown'),
(2, 'east side'),
(3, 'west park'),
(4, 'north ridge'),
(5, 'south shore');

create table accountss (
    accountid int primary key,
    customerid int references customerss(customerid),
    branchid int references branches(branchid),
    balance decimal(15, 2)
);


insert into accountss (accountid, customerid, branchid, balance) values 
(1001, 10, 1, 50000.00),
(1002, 11, 2, 25000.50),
(1003, 12, 1, 7500.00),
(1004, 13, 3, 120000.00),
(1005, 14, 5, 3200.75);

select c.customername, a.accountid, b.branchname,a.balance
from customerss c
join accountss a on c.customerid = a.customerid
join branches b on a.branchid = b.branchid;
