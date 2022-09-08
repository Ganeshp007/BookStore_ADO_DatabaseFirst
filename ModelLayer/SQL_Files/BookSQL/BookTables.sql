use BookStore_ADO

create table Books(
BookId int primary key identity,
BookName varchar(255) unique not null,
Author varchar(255) unique not null,
Description varchar(255) not null,
Quantity int not null,
Price money not null,
DiscountPrice money not null,
TotalRating float,
RatingCount int,
BookImg varchar(255)
)
Exec sp_help Books
select * from Books
