--create procedure sp_get_products
--as
--begin
--select * from Products
--end

--exec sp_get_products

----------------------------------

--create procedure sp_get_products_by_id
--@id int
--as
--begin
--select * from Products
--where Id=@id
--end

--exec sp_get_products_by_id 4

----------------------------------

--create procedure sp_insert_product
--@name varchar(100),
--@price decimal(18,2),
--@stock int,
--@addedId int output
--as
--begin

--insert into Products([Name], Price, Stock, SalesPrice, Kdv, CreatedDate, Barcode)
--values(@name, @price, @stock, 11, 1, '2022-11-11', 11)

--set @addedId=SCOPE_IDENTITY();
--return @addedId;

--end

--declare @addedId int;
--exec sp_insert_product 'cihat', 500, 23, @addedId output;
--select @addedId;
