using Microsoft.AspNetCore.Mvc;
using CourseCatalogAPI.Repositories;
using CourseCatalogAPI.Models.Rooms;
using CourseCatalogAPI.Models.Professors;

namespace CourseCatalogAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly RoomRepository _repository;

        public RoomsController(RoomRepository roomRepository)
        {
            _repository = roomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _repository.GetAllRooms();
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRoom(string roomNumber)
        {
            try
            {
                var createdRoom = await _repository.CreateRoom(roomNumber);
                return Ok("Room created succesfully, Id: " + createdRoom);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}