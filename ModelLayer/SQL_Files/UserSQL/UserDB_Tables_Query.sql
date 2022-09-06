create database BookStore_ADO
Use BookStore_ADO

create table Users(
UserId int primary key identity,
FullName varchar(255) not null,
EmailId varchar(255) unique not null,
Password varchar(255) not null,
MobileNo bigint unique not null
)

Exec sp_help Users