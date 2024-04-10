using Dapper;
using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using locadora.Domain.ViewModels.Movie;
using locadora.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Infra.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Save(Movie movie)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var id = await sqlConn.ExecuteScalarAsync(
                    @"INSERT INTO [tb_Filme] VALUES (@nome, @disponivel)
                    SELECT SCOPE_IDENTITY()",
                        new { @nome = movie.Name, @disponivel = movie.Available });

                    return Convert.ToInt32(id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> GetByName(string name)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var nameMovie = await sqlConn.ExecuteScalarAsync<string>(
                    @"SELECT 
	                     UPPER(NOME)
                     FROM tb_Filme
                     WHERE NOME = @nome",
                        new { @nome = name });

                    return await Task.FromResult(nameMovie == name ? true : false);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<MovieAvailableQuery>> GetAll()
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var movies = await sqlConn.QueryAsync<MovieAvailableQuery>(
                    @"
                        SELECT 
	                        ID AS Id,
	                        NOME AS Name,
	                        CASE DISPONIVEL 
		                        WHEN 1 THEN 'Disponivel'
		                        WHEN 0 THEN 'Indisponivel'
	                        END AS Status
                        FROM tb_Filme");

                    return await Task.FromResult(movies);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> GetById(int id)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.ExecuteScalarAsync<bool>(
                    @"SELECT 
	                     1
                     FROM tb_Filme
                     WHERE ID = @id",
                        new { @id = id });

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> HasAvailable(int id)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.ExecuteScalarAsync<bool>(
                    @"  SELECT 
	                        1
                        FROM tb_Filme
                        WHERE ID = @id
                        AND DISPONIVEL = 1",
                        new { @id = id });

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateSattus(int id, bool status)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    await sqlConn.ExecuteAsync(
                    @"  UPDATE tb_Filme
	                        SET DISPONIVEL = @status
                        WHERE ID = @id",
                        new { @id = id, @status = status });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
