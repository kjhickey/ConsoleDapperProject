CREATE PROCEDURE [dbo].[spEmployee_DeleteEmployee]
    @id int
AS
begin
--Dont forget the WHERE statement when working with delete 
--Potentially use Archive instead of delete
    delete
    from dbo.[Employee]
    where id = @id;
end