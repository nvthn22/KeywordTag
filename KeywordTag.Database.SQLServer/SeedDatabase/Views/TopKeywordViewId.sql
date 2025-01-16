CREATE VIEW kt.TopKeywordIdView AS
SELECT	TOP (100) c.code_keyword AS [Code], COUNT(c.code) AS [Count]
FROM	kt.Checkins AS c INNER JOIN
		kt.Keywords AS k ON k.code = c.code_keyword
GROUP BY c.code_keyword
ORDER BY [Count] DESC