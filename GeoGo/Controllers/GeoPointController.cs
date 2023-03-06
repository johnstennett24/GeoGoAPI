using GeoGo.Models;
using GeoGo.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoGo.Controllers;

[ApiController]
[Route("points")]
public class GeoPointController : ControllerBase
{
  [HttpGet]
  public ActionResult<List<GeoPoint>> GetAll() => GeoPointServices.GetAll;

  [HttpGet("{id}")]
  public ActionResult<GeoPoint> Get(int id)
  {
    var point = GeoPointServices.Get(id);

    if (point is null)
    {
      return NotFound();
    }

    return point;
  }

  [HttpPost]
  public IActionResult Create(GeoPoint point)
  {
    GeoPointServices.Add(point);
    return CreatedAtAction(nameof(Create), new { id = point.Id }, point);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, GeoPoint point)
  {
    if (id != point.Id)
    {
      return BadRequest();
    }

    var existingPoint = GeoPointServices.Get(id);
    if (existingPoint is null)
    {
      return NotFound();
    }
    
    GeoPointServices.Update(point);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var point = GeoPointServices.Get(id);

    if (point is null)
    {
      return NotFound();
    }
    GeoPointServices.Delete(id);
    return NoContent();
  }
}