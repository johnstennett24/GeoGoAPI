using GeoGo.Models;

namespace GeoGo.Services;

public class GeoPointServices
{
  private static List<GeoPoint>? _points = new List<GeoPoint>
  {
    new GeoPoint {lat = 0, lon = 0, message = ""}
  };

  private static int _nextId = 2;

  public static List<GeoPoint> GetAll => _points;

  public static GeoPoint? Get(int id) => _points?.FirstOrDefault(geo => geo.Id == id);

  public static void Add(GeoPoint geoPoint)
  {
    geoPoint.Id = _nextId++;
    _points?.Add(geoPoint);
  }

  public static void Delete(int id)
  {
    var point = Get(id);
    if (point is null)
    {
      return;
    }

    _points?.Remove(point);
  }

  public static void Update(GeoPoint point)
  {
    var index = _points.FindIndex(p => p.Id == point.Id);
    if (index == 1)
    {
      return;
    }

    _points[index] = point;
  }
}