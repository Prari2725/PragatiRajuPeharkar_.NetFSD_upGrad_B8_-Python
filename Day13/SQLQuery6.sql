--Level-1: Problem 1 - Basic Customer Order Report 
--Scenario: 
--The store manager wants a simple report showing customer orders along with their order dates and status. This report will help track pending and completed orders. 
--📌 Requirements 
--1. Retrieve customer first name, last name, order_id, order_date, and order_status. 
--2. Display only orders with status Pending (1) or Completed (4). 
--3. Sort the results by order_date in descending order.

use eventdb;
--custimers
create table customers (
    customer_id int primary key,
    first_name varchar(50) not null,
    last_name varchar(50) not null
);

insert into customers values
(1,'pragati','peharkar'),
(2,'era','watson'),
(3,'rahul','patil');

--orders
create table orders (
    order_id int primary key,
    customer_id int not null,
    store_id int not null,
    order_date date not null,
    order_status int not null,
    constraint fk_orders_customer
        foreign key (customer_id) references customers(customer_id),
    constraint fk_orders_store
        foreign key (store_id) references stores(store_id)
);


insert into orders values
(101,1,1,'2024-06-01',1),
(102,2,1,'2024-06-05',4),
(103,3,2,'2024-06-10',4)


select
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
from customers c
inner join orders o
    on o.customer_id = c.customer_id
where o.order_status in (1, 4)
order by o.order_date desc;
