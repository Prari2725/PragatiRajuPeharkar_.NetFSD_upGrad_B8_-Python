--4. Add entity class SpeakersDetails and add below public properties. 
--Property Name 
--Type 
--Constraints 
--SpeakerId 
--int 
--PK 
--SpeakerName 
--varchar 
--Not Null, Length: 1 to 50 char.

use eventdb;

--//SpeakersDetails table

create table SpeakersDetails (
speakerid int not null,
    speakername varchar(50) not null,
    constraint pk_speakersdetails primary key (speakerid),
    constraint ck_speakersdetails_speakername_len check (len(speakername) between 1 and 50)
);

--SpeakersDetails table data
insert into speakersdetails (speakerid, speakername) values
(1, 'Akshay Kumar'),
(2, 'Salman Khan'),
(4,'Khan Sir'),
(3, 'Raj Shamani');

select * from speakersdetails;
