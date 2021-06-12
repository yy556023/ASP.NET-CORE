use northwind
go

update Products set UnitsInStock = 100 where ProductID = 1
select UnitsInStock from Products where ProductID = 1

-- Wrong stock when multi-user shopping together
set transaction isolation level read uncommitted
begin tran
declare @count int
select @count = UnitsInStock from Products where ProductID = 1
waitfor delay '00:00:15'
update Products set UnitsInStock = @count - 1 where ProductID = 1
commit tran


-- ====================
-- Solution:
-- ====================

-- customer view our web site:
set transaction isolation level read uncommitted
begin tran
select * from Products where ProductID = 1
commit tran


-- customer click OK to buy a ticket:
set transaction isolation level read committed
begin tran
declare @count int
select @count = UnitsInStock from Products with (xlock) where ProductID = 1
-- if @count <= 0 rollback;
waitfor delay '00:00:20'
update Products set UnitsInStock = @count - 1 where ProductID = 1
commit tran



