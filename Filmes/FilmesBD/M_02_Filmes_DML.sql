USE RoteiroFilmes;

INSERT INTO Generos (Nome)
VALUES ('Ação'), ('Aventura'), ('Sci-Fi'), ('Fantasia'), ('Animações'), ('Anime'), ('Comédia'), ('Drama'), ('Horror'), ('Romanticas'), ('Terror'), ('Documentário'), ('Ficção Científica');

SELECT * FROM Generos ORDER BY IdGenero;

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('Vingadores Ultimato', 2), ('Avatar', 3);

SELECT * FROM Filmes ORDER BY IdFilme;