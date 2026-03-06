 
--Level-1: Problem 2 - Product Price Listing by Category 
--Scenario: 
--The sales team wants a product listing categorized by product category along with brand details to understand product distribution. 
--📌 Requirements 
--1. Display product_name, brand_name, category_name, model_year, and list_price. 
--2. Filter products with list_price greater than 500. 
--3. Sort results by list_price in ascending order. 
 

 --category table
 create table categories (
    category_id int primary key,
    category_name varchar(50) not null
);

--data
insert into categories values
(1,'sports'),
(2,'fitness'),
(3,'casual');


--brands table
create table brands (
    brand_id int primary key,
    brand_name varchar(50) not null
);

--data
insert into brands values
(1,'nike'),
(2,'adidas'),
(3,'puma');



--product table
create table products (
    product_id int primary key,
    product_name varchar(50) not null,
    brand_id int not null,
    category_id int not null,
    model_year int,
    list_price decimal(10,2),
    constraint fk_products_brand
        foreign key (brand_id) references brands(brand_id),
    constraint fk_products_category
        foreign key (category_id) references categories(category_id)
);

--data

insert into products values
(1,'running shoes',1,1,2024,800),
(2,'training shoes',2,2,2023,650),
(3,'casual sneakers',3,3,2022,450),
(4,'sports jacket',1,1,2024,1200);



--result q

select
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
from products p
inner join brands b
    on b.brand_id = p.brand_id
inner join categories c
    on c.category_id = p.category_id
where p.list_price > 500
order by p.list_price asc;