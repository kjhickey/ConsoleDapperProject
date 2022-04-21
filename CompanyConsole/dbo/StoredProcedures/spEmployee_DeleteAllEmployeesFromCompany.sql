CREATE PROCEDURE [dbo].[spEmployee_DeleteAllEmployeesFromCompany]
    @CompanyID int
AS
begin
--Dont forget the WHERE statement when working with delete 
--Potentially use Archive instead of delete
    delete
    from dbo.[Employee]
    where CompanyID = @CompanyID;
end