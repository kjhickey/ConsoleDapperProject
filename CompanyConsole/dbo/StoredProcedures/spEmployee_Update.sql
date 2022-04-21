CREATE PROCEDURE [dbo].[spEmployee_Update]
    @id int,
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @PhoneNumber nvarchar(50),
    @EmailAddress nvarchar(50)
AS
begin
    update dbo.[Employee]
    set FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, EmailAddress = @EmailAddress
    where id = @id;
end