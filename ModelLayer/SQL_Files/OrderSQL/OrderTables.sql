Use BookStore_ADO

create table Orders(
OrderId int primary key identity,
UserId int not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId int not null FOREIGN KEY (BookId) REFERENCES Books(BookId),
AddressId int not null FOREIGN KEY (AddressId) REFERENCES Address(AddressId),
OrderQuantity int not null,
TotalOrderPrice money not null,
OrderDate datetime Default getdate()   --sysdatetime and getdate will give same output 
)

select * from Orders
drop table Orders