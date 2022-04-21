CREATE PROCEDURE [dbo].[spEmployee_Add]
    @FirstName nvarchar(50),
    @LastName nvarchar(50),
    @PhoneNumber nvarchar(50),
    @EmailAddress nvarchar(50),
    @CompanyID int
AS
begin
    insert into dbo.[Employee] (FirstName, LastName, PhoneNumber, EmailAddress, CompanyID)
    values (@FirstName, @LastName, @PhoneNumber, @EmailAddress, @CompanyID);
end