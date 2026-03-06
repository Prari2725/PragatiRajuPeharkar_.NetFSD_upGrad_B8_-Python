--6. Add entity class ParticipantEventDetails and add below public properties. 
--Property Name 
--Type 
--Constraints 
--Id 
--int 
--(PK) 
--ParticipantEmailId 
--varchar  
--Not Null (FK) 
--EventId 
--int 
--Not Null (FK) 
--SessionId 
--Int 
--Not Null (FK) 
--IsAttended 
--bit 
--Yes or No, CHECK 

create table participanteventdetails (
    id int not null,
    participantemailid varchar(50) not null,
    eventid int not null,
    sessionid int not null,
    isattended bit not null,
    constraint pk_pevtdtls primary key (id),
    constraint fk_pevtdtlsuserinfo foreign key (participantemailid) references userinfo(emailid),
    constraint fk_pevtdtls foreign key (eventid) references eventdetails(eventid),
    constraint fk_pevtdtlssessioninfo foreign key (sessionid) references sessioninfo(sessionid),
    constraint ck_ppevtdtlsisattended check (isattended in (0,1))
);


--table data

insert into participanteventdetails (id, participantemailid, eventid, sessionid, isattended) values
(1, 'pragati@gmail.com', 101, 1001, 1),
(2, 'neha@gmail.com', 101, 1002, 0),
(3, 'pragati@gmail.com', 101, 1002, 1),
(4, 'neha@gmail.com', 102, 2001, 0);


select * from participanteventdetails;