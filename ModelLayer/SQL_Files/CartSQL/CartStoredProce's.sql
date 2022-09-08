Use BookStore_ADO

--stored procedure for AddBookTOCart
create procedure AddBookTOCartSP(
@UserId int,
@BookId int,
@BookQuantity int
)
As
Begin try
DECLARE @count int;
SET @count=(select count(CartId) from Cart where UserId IN (@UserId) AND BookId IN (@BookId))
IF(@count = 0)
insert into Cart(UserId,BookId,BookQuantity) values(@UserId,@BookId,@BookQuantity)
ELSE
print'The Book is already in Cart!!'
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH
drop procedure AddBookTOCartSP
Exec AddBookTOCartSP 1,2,2
--======================================================================