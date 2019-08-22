USE RoteiroFilmes;

SELECT F.*, G.*
	FROM Filmes F
	JOIN Generos G
	ON F.IdGenero = G.IdGenero;