/*
prods
pid      qty
1        100
           --------> 100
		             -20
		 80 <-------- 80
80 <----- read un-committed / dirty read
                     -10
	     70# <-------

// ==============================================
prods
pid      qty
1        100

100 <------
         80# <----------- A
80  <------
         60# <----------- B
60 <------
         90# <----------- C
90 <------
// non-repeatable data

prods
pid      qty
1        100
           --------> 100
100 <-----
		             -20
		 80 <-------- 80
-30
OK button clicked
80 <------
-30
50 ----> 50



shared lock    (S) = read-lock
exclusive lock (X) = write-lock

---- begin tran ----------------------------------
  select												S ---> unlock
    1) lock in shared mode
	2) read data from server
	3) unlock

  update														X
    1) lock in X mode                                           |
	2) update data                                              |
	3) unlock when transaction end (rollback or commit)         |
	                                                            |
---- end tran  --------------------------------------------- unLock


----------- begin tran ---------------------
select                                   
   1) request a shared lock              S
   2) lock until tran end.               |
                                         |
                                         |
                                         |
                                         |
----------- tran end ------------------ unlock --

*/


