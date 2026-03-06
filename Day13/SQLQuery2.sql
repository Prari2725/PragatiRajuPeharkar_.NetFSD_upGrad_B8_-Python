--2. Add entity class EventDetails and add below public properties. 
--Property Name 
--Type 
--Constraint 
--EventId 
--int 
--PK 
--EventName 
--varchar 
--Not Null, Length: 1 to 50 char. 
--EventCategory 
--varchar 
--Not Null, Length: 1 to 50 char. 
--EventDate 
--datetime 
--Not Null 
--Description 
--varchar 
--Nullable 
--Status 
--varchar 
--Active or In-Active, CHECK 
 use eventdb;

 --EventDetails table
 create table EventDetails (
    eventid int not null,
    eventname varchar(50) not null,
    eventcategory varchar(50) not null,
    eventdate datetime not null,
    description varchar(500) null,
    status varchar(20) not null,
    constraint pk_evtdtls primary key (eventid),
    constraint ck_entnamelen check (len(eventname) between 1 and 50),
    constraint ck_evtcatlen check (len(eventcategory) between 1 and 50),
    constraint ck_evtstus check (status in ('active','in-active'))
);

--EventDetails table data

insert into EventDetails (eventid, eventname, eventcategory, eventdate, description, status) values
(101, 'Sports Day', 'technology', '2026-03-10 10:00:00', 'annual sports event', 'active'),
(102, 'Science Exhibition', 'technology', '2026-03-20 09:00:00', null, 'active'),
(103, 'Annual Gathering', 'Extra curriculum', '2026-03-20 09:00:00', 'annual gathering', 'in-active'),
(104, 'parents meet', 'general', '2026-02-01 11:00:00', 'current event', 'in-active');


select * from EventDetails;