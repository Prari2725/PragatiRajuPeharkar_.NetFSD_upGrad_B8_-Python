-- Problem 2 - Product Stock and Sales Analysis 
--Scenario: 
--The inventory manager wants to compare stock availability and total quantity sold for each product. 
--📌 Requirements 
--1. Display product_name, store_name, available stock quantity, and total quantity sold. 
--2. Include products even if they have not been sold (use appropriate join). 
--3. Group results by product_name and store_name. 
--4. Sort results by product_name.


--stock table
create table stocks (
    store_id int not null,
    product_id int not null,
    quantity int not null,
    constraint pk_stocks primary key (store_id, product_id),
    constraint fk_stocks_store
        foreign key (store_id) references stores(store_id),
    constraint fk_stocks_product
        foreign key (product_id) references products(product_id)
);

--data

insert into stocks values
(1,1,200),
(1,2,15),
(2,3,300),
(2,4,180);


--result query

select p.product_name,s.store_name,st.quantity as available_stock_quantity,isnull(sum(oi.quantity),0) as total_quantity_sold
from stocks st
inner join products p
on p.product_id=st.product_id
inner join stores s
on s.store_id=st.store_id
left join order_items oi
on oi.product_id=st.product_id
group by
p.product_name,
s.store_name,
st.quantity
order by p.product_name;
