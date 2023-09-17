using CourseCatalogAPI.Models.Courses;
using CourseCatalogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly CourseRepository _repository;

    public CoursesController(CourseRepository courseRepository)
    {
        _repository = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _repository.GetAllCourses();
        return Ok(courses);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourse(int id)
    {
        var course = await _repository.GetCourseById(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseCreateCommand course)
    {
        var courseId = await _repository.CreateCourse(course);
        return CreatedAtAction("GetCourse", new { id = courseId }, course);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCourse(CourseUpdateCommand course)
    {
        var foundCourse = await _repository.GetCourseById(course.CourseId);
        if (foundCourse == null)
        {
            return BadRequest("There is no Course with the Id sent.");
        }
        var updated = await _repository.UpdateCourse(course);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var deleted = await _repository.DeleteCourse(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}