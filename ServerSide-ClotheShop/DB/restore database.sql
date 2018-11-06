--a
--create bak file


--b
--get the file names from disk
RESTORE FILELISTONLY
FROM DISK = 'C:\CafeteriaBak.bak'


--c
--restore the database
restore database ServerSide
from disk = 'C:\CafeteriaBak.bak'
WITH MOVE 'CafeteriaB' TO 'C:\Users\אורלי\Documents\SQL Server Management Studio:\DataYourMDFFile.mdf',
MOVE 'CafeteriaB_log' TO 'C:\Users\אורלי\Documents\SQL Server Management Studio:\DataYourLDFFile.ldf'



