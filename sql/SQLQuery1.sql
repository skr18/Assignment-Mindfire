CREATE PROCEDURE SelectAllCustomers @Age int
AS
SELECT * FROM UserDetails WHERE Age = @Age


EXEC SelectAllCustomers @Age = 23;