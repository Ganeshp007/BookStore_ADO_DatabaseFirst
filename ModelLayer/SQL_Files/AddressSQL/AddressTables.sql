create table Address(
AddressId int primary key identity,
UserId int  not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
AddressType int not null FOREIGN KEY (AddressType) REFERENCES AddressType(AddressTypeId),
FullAddress varchar(255) unique not null,
City varchar(255) not null,
State varchar(255) not null,
)

select * from Address
Exec sp_help Address
drop table Address

create table AddressType(
AddressTypeId int primary key identity,
AddressType varchar(20) not null
)

select * from AddressType

insert into AddressType(AddressType) values ('Other')