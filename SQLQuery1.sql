Create Procedure sp_IPL_InsertUser
@UserName varchar(30),
@Pass varchar(30),
@FirstName varchar(30),
@LastName varchar(30)
as
Begin 
Begin Transaction
Begin Try
Insert into IPL_MGMT_SYSTEM.Users(UserName,Pass,FirstName,LastName)
values(@UserName,@Pass,@FirstName,@LastName)

IF @@TRANCOUNT > 0
 BEGIN commit TRANSACTION;
 END
 END TRY 
BEGIN CATCH
IF @@TRANCOUNT > 0
 BEGIN rollback TRANSACTION;
 END
 
 END CATCH
END 

drop procedure sp_IPL_InsertUser

Exec sp_IPL_InsertUser 'ashwin','ash','ashwin','m';


CREATE PROCEDURE sp_IPL_UpdateUser
@UserId int,
@UserName varchar(30),
@Pass varchar(30),
@FirstName varchar(100),
@LastName varchar(100)
AS
BEGIN
 BEGIN TRANSACTION 
 BEGIN TRY
 Update IPL_MGMT_SYSTEM.Users set UserName=@UserName, Pass=@Pass,FirstName=@FirstName,LastName=@LastName
 Where UserId=@UserId 
 IF @@TRANCOUNT > 0
 BEGIN commit TRANSACTION;
 END
 END TRY
 BEGIN CATCH
IF @@TRANCOUNT > 0
 BEGIN rollback TRANSACTION; 
 END
 END CATCH
 END 


 exec sp_IPL_UpdateUser 1,'ashwin','chicken','ashwin','Nair'


