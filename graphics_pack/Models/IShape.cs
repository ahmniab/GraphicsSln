namespace graphics_pack.Models;

public interface IShape
{
    public IEnumerable<Point> GetIndexes();
    public string name { get; set; } 
    public string color { get; set; }
    public string? ImgSrc { get; set; }
}