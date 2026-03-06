
--ANSI SQL using MS-SQL Server 
--Level-1 and 2 Problem: Create Database EventDb and create tables as per schema given below. 
--📌 Requirements 
--1.Add entity class UserInfo and add public properties: 
--Property Name 
--Type 
--Constraint 
--EmailId 
--varchar 
--PK 
--UserName 
--varchar 
--Not Null, Length: 1 to 50 char. 
--Role 
--varchar  
--Not Null, (Admin,Participant)-CHECK 
--Password 
--varchar 
--Not Null Length: 6 to 20 cha

--1

create database eventdb;

use eventdb;

--userinfo table

create table userinfo(
emailId varchar(50) not null,
username varchar (50) not null,
role varchar(20) not null,
[password]  varchar(20) not null,
constraint pk_uinfo primary key (emailId),
constraint ck_unamelength check(len(username)between 1 and 50),
constraint ck_urole check(role in('admin','participant')),
constraint ck_upass check (len([password]) between 6 and 20),
);


--userinfo data

insert into userinfo (emailid, username, role, [password]) values
('admin@gmail.com', 'system admin', 'admin', 'admin@123'),
('pragati@gmail.com', 'pragati', 'participant', 'pragati@123'),
('Anu@gmail.com', 'Anuja', 'admin', 'anuja@123'),
('neha@gmail.com', 'neha', 'participant', 'neha@123');


select * from userinfo;



