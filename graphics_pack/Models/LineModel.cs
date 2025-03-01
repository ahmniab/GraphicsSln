using System.Diagnostics;
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
    public AlgorithmType Algorithm { get; set; }
    
    public IEnumerable<Point> GetIndexes()
    {
        switch(Algorithm)
        {
            case AlgorithmType.LineDDA :
                return DDA();
            case AlgorithmType.LineBresenham :
                return Bresenham();
            default:
                throw new NonValidAlgorithmException();
                
        }
    }

    private IEnumerable<Point> Bresenham()
    {
        return Enumerable.Empty<Point>();
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