using System.Data;
using System.Data.SqlClient;
using Dapper;
using CourseCatalogAPI.Models.Professors;

namespace CourseCatalogAPI.Repositories
{
    public class ProfessorRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProfessorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            using var connection = Connection;
            connection.Open();
            return await connection.QueryAsync<Professor>("SELECT * FROM Professors");
        }

        public async Task<int> CreateProfessor(ProfessorCreateCommand professor)
        {
            using var connection = Connection;
            connection.Open();
            var sql = @"INSERT INTO Professors (ProfessorName, ProfessorEmail)
                        VALUES (@ProfessorName, @ProfessorEmail);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(sql, professor);
        }
    }
}