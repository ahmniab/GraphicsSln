using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace graphics_pack.Models;

public class LineModel : IShape
{

    public int XStart   { get; set; }
    public int YStart   { get; set; }
    public int XEnd     { get; set; }
    public int YEnd     { get; set; }

    public string name  { get; set; } = "Line";
    public string? color { get; set; }
    
    public string? ImgSrc { get; set; }
    public bool IsDDA { get; set; }
    
    public IEnumerable<Point> GetIndexes()
    {
        if (IsDDA)
        {
            return DDA();
        }
        else
        {
            throw new Exception();
        }
    }
    private IEnumerable<Point> DDA()
    {
        int dx = XEnd - XStart, dy = YEnd - YStart, steps, k;
        double xIncrement, yIncrement, x = XStart, y = YStart;

        if (Math.Abs(dx) > Math.Abs(dy))
            steps = Math.Abs(dx);
        else
            steps = Math.Abs(dy);

        xIncrement = (double)dx / steps;
        yIncrement = (double)dy / steps;
        
        for (k = 0; k < steps; k++)
        {
            x += xIncrement;
            y += yIncrement;
            yield return new Point
            {
                x = x,
                y = y,
            };
        }

    }
}