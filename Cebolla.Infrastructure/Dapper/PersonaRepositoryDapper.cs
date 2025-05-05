using Cebolla.Domain.Entities;
using Cebolla.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cebolla.Infrastructure.Dapper
{
    public class PersonaRepositoryDapper : IPersonaRepository
    {
        private readonly string _connectionString;

        public PersonaRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            var sql = "SELECT * FROM Personas";
            using var db = Connection;
            return await db.QueryAsync<Persona>(sql);
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Personas WHERE Id = @Id";
            using var db = Connection;
            return await db.QueryFirstOrDefaultAsync<Persona>(sql, new { Id = id });
        }

        public async Task AddAsync(Persona entity)
        {
            var sql = "INSERT INTO Personas (Nombre, Apellido, FechaNacimiento) VALUES (@Nombre, @Apellido, @FechaNacimiento)";
            using var db = Connection;
            await db.ExecuteAsync(sql, entity);
        }

        public async Task UpdateAsync(Persona entity)
        {
            var sql = @"UPDATE Personas 
                        SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento 
                        WHERE Id = @Id";
            using var db = Connection;
            await db.ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Personas WHERE Id = @Id";
            using var db = Connection;
            await db.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Persona>> ObtenerPorApellidoAsync(string apellido)
        {
            var sql = "SELECT * FROM Personas WHERE Apellido LIKE @Apellido";
            using var db = Connection;
            return await db.QueryAsync<Persona>(sql, new { Apellido = $"%{apellido}%" });
        }
    }
}
