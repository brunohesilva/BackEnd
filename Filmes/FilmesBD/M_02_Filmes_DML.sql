USE RoteiroFilmes;

INSERT INTO Generos (Nome)
VALUES ('A��o'), ('Aventura'), ('Sci-Fi'), ('Fantasia'), ('Anima��es'), ('Anime'), ('Com�dia'), ('Drama'), ('Horror'), ('Romanticas'), ('Terror'), ('Document�rio'), ('Fic��o Cient�fica');

SELECT * FROM Generos ORDER BY IdGenero;

INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('Vingadores Ultimato', 2), ('Avatar', 3);

SELECT * FROM Filmes ORDER BY IdFilme;