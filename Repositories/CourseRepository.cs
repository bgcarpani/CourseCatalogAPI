using CourseCatalogAPI.Models.Courses;
using CourseCatalogAPI.Models.Professors;
using CourseCatalogAPI.Models.Rooms;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CourseCatalogAPI.Repositories
{
    public class CourseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            using var connection = Connection;
            connection.Open();
            return await connection.QueryAsync<CourseDTO>(@"SELECT C.CourseId, C.CourseName, P.ProfessorId, P.ProfessorName, P.ProfessorEmail, R.RoomId, R.RoomNumber, C.Monday, C.Tuesday, C.Wednesday, C.Thursday, C.Friday, C.Saturday, C.Sunday
                FROM Courses C
                LEFT JOIN Professors P on C.ProfessorId = P.ProfessorId
                LEFT JOIN Rooms R on C.RoomId = R.RoomId");
        }

        public async Task<Course> GetCourseById(int id)
        {
            using var connection = Connection;
            connection.Open();
            return await connection.QueryFirstOrDefaultAsync<Course>("SELECT * FROM Courses WHERE CourseId = @id", new { id });
        }

        public async Task<int> CreateCourse(CourseCreateCommand course)
        {
            using var connection = Connection;
            connection.Open();
            var sql = @"INSERT INTO Courses (CourseName, ProfessorId, RoomId, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday)
                        VALUES (@CourseName, @ProfessorId, @RoomId, @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Saturday, @Sunday);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(sql, course);
        }

        public async Task<bool> UpdateCourse(CourseUpdateCommand course)
        {
            using var connection = Connection;
            connection.Open();
            var sql = @"UPDATE Courses
                        SET CourseName = @CourseName, ProfessorId = @ProfessorId, RoomId = @RoomId,
                            Monday = @Monday, Tuesday = @Tuesday, Wednesday = @Wednesday, Thursday = @Thursday,
                            Friday = @Friday, Saturday = @Saturday, Sunday = @Sunday
                        WHERE CourseId = @CourseId";
            return await connection.ExecuteAsync(sql, course) > 0;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            using var connection = Connection;
            connection.Open();
            var sql = "DELETE FROM Courses WHERE CourseId = @id";
            return await connection.ExecuteAsync(sql, new { id }) > 0;
        }
    }
}