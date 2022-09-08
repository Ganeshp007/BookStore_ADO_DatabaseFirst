Use BookStore_ADO

create table Cart(
CartId int primary key identity,
UserId int  not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId int  not null FOREIGN KEY (BookId) REFERENCES Books(BookId),
BookQuantity int not null
)
drop table Cart
Exec sp_help Cart
select * from Cart
truncate table Cart