using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {
        // acesso ao banco de dados
        public class ArtistaRepository
        {
            private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=RoteiroFilmes;User Id=sa;Pwd=132;";

            public List<FilmeDomain> Listar()
            {
                List<FilmeDomain> filmes = new List<FilmeDomain>();

                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string Query = "SELECT F.IdFilme, F.Titulo, F.IdGenero, G.Nome AS NomeGenero FROM Filmes A INNER JOIN Generos E ON F.IdGenero = G.IdGenero;";

                    con.Open();

                    SqlDataReader sdr;

                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        sdr = cmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                GeneroId = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["NomeEstilo"].ToString()
                                }
                            };
                            filmes.Add(filme);
                        }

                    }
                }
                return filmes;
            }

            public void Cadastrar(FilmeDomain filme)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string Query = "INSERT INTO Artistas (Nome, IdGenero) VALUES (@Nome, @IdGenero);";

                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@Nome", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.GeneroId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
