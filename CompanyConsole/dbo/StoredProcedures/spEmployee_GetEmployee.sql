CREATE PROCEDURE [dbo].[spEmployee_GetEmployee]
    @id int
AS
begin
    select *
    from dbo.[Employee]
    where id = @id;
end