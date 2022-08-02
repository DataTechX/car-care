create database ChibaDB1 collate thai_ci_as
go
use ChibaDB1
go
create table Pet
(
	Pet_Id int identity (100000, 1) primary key,
	Pet_Name nvarchar  (50) not null,
	Pet_Type nvarchar  (50) not null,
	Pet_Colour nvarchar  (50) not null,
	Pet_TypeName nvarchar  (50) not null,
)
go
insert into Pet values('3ฒม2048', 'Dog', 'Book', 'SUfV')
insert into Pet values('3ฒมt4r2048', 'Do15gt', 'Boosertk', 'SfUV')
insert into Pet values('3ฒม20gawe48', 'D13og', 'Book', 'SUV')
insert into Pet values('3ฒม2gawe048', 'D235og', 'Bohsok', 'SUV')
insert into Pet values('3ฒม20gaw48', 'Do52g', 'Bhdrook', 'SUV')
insert into Pet values('3ฒม20jdrt48', 'Da3g', 'Bhdrook', 'SUV')
insert into Pet values('3ฒม20fty48', 'Dog', 'Bohdrok', 'SUV')
go
select *from Pet