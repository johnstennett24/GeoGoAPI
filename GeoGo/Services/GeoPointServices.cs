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
}