set transaction isolation level read uncommitted
set transaction isolation level read committed
begin transaction 
select * from Products where ProductID = 1
rollback tran


/*
prod
pid  .... qty
1         100
A						B
100 <---- 100
            --------> 100
-20
80 ----->  80   update prods set qty = 80 whre pid = 1 and qty = 100
                      -30
		   ?? <------  70  update prods set qty = 70 where pid = 1 and qty = 100
		   80 ------>  80 
		                   update prods set qty = 50 where pid = 1 and qty = 80



1	100     A    B    C     D   E
		   100  100  100  100   99
A
begin tran
   select X-lock  100
   update 99
commit tran;; -- unluck
B:
begin tran
   select X-lock  99
   update 98
commit tran;; -- unluck
C:
begin tran
   select X-lock  98
                          -----> dirty read 98
   update 97
commit tran;; -- unluck


*/


