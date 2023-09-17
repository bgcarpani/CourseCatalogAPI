using System.Data;
using System.Data.SqlClient;
using Dapper;
using CourseCatalogAPI.Models.Rooms;

namespace CourseCatalogAPI.Repositories
{
    public class RoomRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public RoomRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            using var connection = Connection;
            connection.Open();
            return await connection.QueryAsync<Room>("SELECT * FROM Rooms");
        }
        public async Task<int> CreateRoom(string roomNumber)
        {
            using var connection = Connection;
            connection.Open();
            var sql = @"INSERT INTO Rooms (RoomNumber)
                        VALUES (@RoomNumber);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(sql, new {RoomNumber = roomNumber});
        }
    }
}