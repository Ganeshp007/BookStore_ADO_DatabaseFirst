Use BookStore_ADO

create table Feedbacks(
FeedbackId int primary key identity,
Rating float not null,
Comment varchar(max) not null,
BookId int not null foreign key (BookId) references Books(BookId),
UserId int not null foreign key (UserId) references Users(UserId)
)