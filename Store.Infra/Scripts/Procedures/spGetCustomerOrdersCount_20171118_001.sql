CREATE PROCEDURE spCheckDocument
	@Document CHAR(11)
AS
	SELECT CASE WHEN EXISTS (
		SELECT 
			[Id],
			CONCAT([c.FirstName], ' ', [c.LastName]) as [Name],
			c.[Document],
			COUNT(o.Id)
		FROM 
			[Customer] c 
		INNER JOIN 
			[Order] o 
		ON 
			o.[CustomerId] = c.[Id]
	)