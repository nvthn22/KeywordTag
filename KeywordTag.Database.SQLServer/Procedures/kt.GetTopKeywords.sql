--exec kt.GetTopKeywords @Quantity=1

CREATE PROCEDURE kt.GetTopKeywords
(
	@Quantity int
)
AS
BEGIN

if @Quantity = 0 set @Quantity = 1

SELECT	c.code_keyword AS [Code], COUNT(c.code) AS [Count]
INTO	#keyword_count
FROM	kt.Checkins c
GROUP BY c.code_keyword
ORDER BY [Count] DESC
OFFSET     0 ROWS
FETCH NEXT @Quantity ROWS ONLY;

select	k.code as [code],
		k.name as [name],
		kc.Count as [online]
from #keyword_count kc left join kt.Keywords k on kc.code = k.code

END;
GO