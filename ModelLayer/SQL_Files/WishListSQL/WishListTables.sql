use BookStore_ADO

create table WishList(
WishListId int primary key identity,
UserId int  not null FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId int  not null FOREIGN KEY (BookId) REFERENCES Books(BookId),
)

