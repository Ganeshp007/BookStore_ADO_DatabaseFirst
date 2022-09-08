use BookStore_ADO
--stored procedure for Admin Login
create procedure AdminLoginSP(
@AdminEmailId varchar(255),
@AdminPassword varchar(255)
)
As
Begin try
select * from Admin where @AdminEmailId=@AdminEmailId and @AdminPassword=@AdminPassword
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

Exec AdminLoginSP 'shree@gmail.com','Shree@1234'