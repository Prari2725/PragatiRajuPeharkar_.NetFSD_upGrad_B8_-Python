
--5. Add entity class SessionInfo and add below public properties. 
--Property Name 
--Type 
--Constraints 
--SessionId 
--int 
--PK 
--EventId 
--int 
--Not Null (FK) 
--SessionTitle 
--varchar 
--Not Null, Length: 1 to 50 char. 
--SpeakerId 
--int 
--Not Null (FK) 
--Description 
--varchar 
--Nullable 
--SessionStart 
--datetime 
--Not Null (Time Slot) 
--SessionEnd 
--datetime 
--Not Null (Time Slot) 
--SessionUrl 
--varchar 
 use eventdb;
 --seesion table
 
create table sessioninfo (
    sessionid int not null,
    eventid int not null,
    sessiontitle varchar(50) not null,
    speakerid int not null,
    description varchar(500) null,
    sessionstart datetime not null,
    sessionend datetime not null,
    sessionurl varchar(300) null,
    constraint pk_sessioninfo primary key (sessionid),
    constraint fk_sessioninfo_eventdetails foreign key (eventid) references eventdetails(eventid),
    constraint fk_sesnspeakersdetails foreign key (speakerid) references speakersdetails(speakerid),
    constraint ck_sesnsessiontitle_len check (len(sessiontitle) between 1 and 50),
    constraint ck_sesnimes check (sessionend > sessionstart)
);


--seesion table data

insert into sessioninfo
(sessionid, eventid, sessiontitle, speakerid, description, sessionstart, sessionend, sessionurl)
values
(1001, 101, 'MOTIVATION', 1, 'MOTIVATION Tricks', '2026-03-10 10:15:00', '2026-03-10 11:00:00', 'https://example.com/s1'),
(1002, 101, 'CULTURE', 2, null, '2026-03-10 11:15:00', '2026-03-10 12:00:00', 'https://example.com/s2'),
(2001, 102, 'FOCUs', 3, 'FOCUs execution plans', '2026-03-20 09:30:00', '2026-03-20 10:30:00', 'https://example.com/s3');

select * from sessioninfo;