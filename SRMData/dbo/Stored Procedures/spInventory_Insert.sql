﻿CREATE PROCEDURE [dbo].[spInventory_Insert]
	@ProductID int,
	@Quantity int,
	@PurchasePrice money,
	@PurchaseDate datetime2
AS
begin
	set nocount on;

	insert into dbo.Inventory(ProductId, Quantity, PurchasePrice, PurchaseDate)
	values (@ProductId, @Quantity, @PurchasePrice, @PurchaseDate);

end
