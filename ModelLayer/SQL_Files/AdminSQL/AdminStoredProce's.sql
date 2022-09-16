use BookStore_ADO
--stored procedure for Admin Login
alter procedure AdminLoginSP(
@AdminEmailId varchar(255),
@AdminPassword varchar(255)
)
As
Begin try
select * from Admin where AdminEmailId=@AdminEmailId COLLATE SQL_Latin1_General_CP1_CS_AS and AdminPassword=@AdminPassword COLLATE SQL_Latin1_General_CP1_CS_AS
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
