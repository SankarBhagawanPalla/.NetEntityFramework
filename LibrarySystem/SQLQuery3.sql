select * from dbo.Book
select * from dbo.BookCopy 
select * from dbo.BorrowedBook
select * from dbo.Member

select *
from 
(select * from dbo.BorrowedBook 
--where ActualReturnDate IS NOT NULL


SELECT * from (SELECT *
FROM (
   SELECT *,
         ROW_NUMBER() OVER (PARTITION BY BookCopyId ORDER BY ActualReturnDate) AS rn
   FROM dbo.BorrowedBook
)cte
WHERE rn = 1 and ActualReturnDate IS NOT NULL) A join dbo.BookCopy  B ON A.BookCopyId = B.BookCopyId
