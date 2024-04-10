using Dapper;
using locadora.Domain.Interfaces.Repositories;
using locadora.Domain.Models;
using locadora.Domain.ViewModels.Location;
using locadora.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Infra.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _context;

        public LocationRepository(DataContext context   )
        {
            _context = context;
        }

        public async Task<int> Save(Location location)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var id = await sqlConn.ExecuteScalarAsync(
                    @"INSERT INTO [tb_Locacoes] VALUES (@clienteId, @filmeId, @locacaoData, @devolucaoData, @entradaData)
                    SELECT SCOPE_IDENTITY()",
                        new { @clienteId = location.CustomerId, @filmeId = location.MovieId, @locacaoData = location.LocationDate,
                              @devolucaoData = location.DevolutionDate, @entradaData = (String)null});

                    return Convert.ToInt32(id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LocationQuery> GetById(int id)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.QueryFirstOrDefaultAsync<LocationQuery>(
                    @"  SELECT 
	                        L.ID AS Id,
	                        C.NOME AS CustomerName,
	                        F.NOME AS MovieName,
	                        L.DT_LOCACAO AS LocationDate,
	                        L.DT_DEVOLUCAO AS DevolutionDate
                        FROM tb_Locacoes L
                        INNER JOIN tb_Cliente C
	                        ON L.ID_CLIENTE = C.ID
                        INNER JOIN tb_Filme F
	                        ON L.ID_FILME = F.ID
                        WHERE L.ID = @id",
                        new { @id = id });

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CustomerHasLocation(int id)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    var result = await sqlConn.ExecuteScalarAsync<bool>(
                    @"  SELECT
                           1
                        FROM tb_Locacoes
                        WHERE ID_CLIENTE = @id
                        AND DT_ENTRADA IS NULL",
                        new { @id = id });

                    return await Task.FromResult(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DevolutionLocation(int id, DateTime date)
        {
            try
            {
                using (var sqlConn = _context.OpenConn())
                {
                    await sqlConn.ExecuteAsync(
                    @"  UPDATE tb_Locacoes
	                        SET DT_ENTRADA = @date
                        WHERE ID = @id",
                        new { @id = id, @date = date});
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
