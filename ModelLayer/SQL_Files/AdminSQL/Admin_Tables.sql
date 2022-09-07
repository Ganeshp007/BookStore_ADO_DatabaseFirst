use BookStore_ADO

create table Admin(
AdminId int primary key identity,
AdminName varchar(255) not null,
AdminEmailId varchar(255) unique not null,
AdminAddress varchar(255) not null,
AdminMobile bigint unique not null,
AdminPassword varchar(255) not null
)

Exec sp_help Admin

insert into Admin(AdminName,AdminEmailId,AdminAddress,AdminMobile,AdminPassword) values('Shree Potdar','shree@gmail.com','Kothrud,Pune',9511949586,'Shree@1234')

select * from Admin