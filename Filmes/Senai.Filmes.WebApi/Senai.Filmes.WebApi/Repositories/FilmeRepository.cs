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
                                Genero = new GeneroDomain
                                {
                                    IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                    Nome = sdr["NomeEstilo"].ToString()
                                }
                            };
                            artistas.Add(artista);
                        }

                    }
                }
                return artistas;
            }

            public void Cadastrar(ArtistaDomain artista)
            {
                // declarar a conexao
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string Query = "INSERT INTO Artistas (Nome, IdEstiloMusical) VALUES (@Nome, @IdEstiloMusical);";

                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@Nome", artista.Nome);
                    // cmd.Parameters.AddWithValue("@IdEstiloMusical", artista.Estilo.IdEstilo);
                    cmd.Parameters.AddWithValue("@IdEstiloMusical", artista.EstiloId);
                    // abre a conexao
                    con.Open();
                    // qtd de registros
                    cmd.ExecuteNonQuery();
                }
            }
        }
}
