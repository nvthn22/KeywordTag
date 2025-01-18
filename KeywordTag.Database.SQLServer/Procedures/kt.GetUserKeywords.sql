--exec kt.GetUserKeywords @KeywordIds=';C2A8AB22-DD2C-4546-B9C7-0D0E573D2F5F;415F0912-18CC-4C53-9E4D-89BBB8087CA1;'

CREATE PROCEDURE kt.GetUserKeywords
(
	@KeywordIds nvarchar(max)
)
AS
BEGIN

SELECT	c.code_keyword AS [Code],
		COUNT(c.code) AS [Count]

INTO	#keyword_count
FROM	kt.Checkins c
GROUP BY c.code_keyword

select	k.code as [code],
		k.name as [name],
		ISNULL(kc.Count, 0) as [online]
from kt.Keywords k left join #keyword_count kc on k.code = kc.Code
where @KeywordIds like '%;' + cast(k.code as varchar(36)) + ';%'

END;
GO