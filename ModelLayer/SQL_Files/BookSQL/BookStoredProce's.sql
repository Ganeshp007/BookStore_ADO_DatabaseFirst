use BookStore_ADO
--stored procedure for AddBook
create procedure AddBookSP(
@BookName varchar(255),
@Author varchar(255),
@Description Nvarchar(255),
@Quantity int,
@Price money,
@DiscountPrice money,
@TotalRating float,
@RatingCount int,
@BookImg varchar(255)
)
As
Begin try
insert into Books(BookName,Author,Description,Quantity,Price,DiscountPrice,TotalRating,RatingCount,BookImg) values(@BookName,@Author,@Description,@Quantity,@Price,@DiscountPrice,@TotalRating,@RatingCount,@BookImg)
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

Exec AddBookSP [Don't Think, Revisited: A Common Sense Approach to Web Usability (3rd Edition) (Voices That Matter) 3rd Edition],'Sveg','Since Don’t Make Me Think was first published in 2000, hundreds of thousands of Web designers and developers have relied on usability guru Steve Krug’s guide to help them understand the principles of intuitive navigation and information design. Witty, commonsensical, and eminently practical, it’s one of the best-loved and most recommended books on the subject.',2,3035.58,2800,4.6,2455,[https://www.amazon.in/Dont-Make-Think-Revisited-Usability-ebook/dp/B00HJUBRPG]

--======================================================================

--stored procedure for GetALlBooks
create procedure GetAllBooksSP
As
Begin try
select * from Books
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--======================================================================

--stored procedure for AddBook
create procedure UpdateBooksSP(
@BookId int,
@BookName varchar(255),
@Author varchar(255),
@Description Nvarchar(255),
@Quantity int,
@Price money,
@DiscountPrice money,
@TotalRating float,
@RatingCount int,
@BookImg varchar(255)
)
As
Begin try
update Books set BookName=@BookName,Author=@Author,Description=@Description,Quantity=@Quantity,Price=@Price,DiscountPrice=@DiscountPrice,TotalRating=@TotalRating,RatingCount=@RatingCount,BookImg=@BookImg where BookId=@BookId
select * from Books where BookId=@BookId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

Exec UpdateBooksSP 1,[Don't Think, Revisited: A Common Sense Approach to Web Usability (3rd Edition) (Voices That Matter)],'Sveg','Since Don’t Make Me Think was first published in 2000, hundreds of thousands of Web designers and developers have relied on usability guru Steve Krug’s guide to help them understand the principles of intuitive navigation and information design. Witty, commonsensical, and eminently practical, it’s one of the best-loved and most recommended books on the subject.',2,3035.58,2800,4.6,2455,[https://www.amazon.in/Dont-Make-Think-Revisited-Usability-ebook/dp/B00HJUBRPG]
--======================================================================

--stored procedure for GetBooksByIdSP
create procedure GetBooksByIdSP(
@BookId int
)
As
Begin try
select * from Books where BookId=@BookId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

--======================================================================

--stored procedure for deleteBook
create procedure deleteBookSP(
@BookId int
)
As
Begin try
delete from Books where BookId=@BookId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH
