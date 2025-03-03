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
    
    public IEnumerable<PointInfo> GetIndexes()
    {
        switch(Algorithm)
        {
            case AlgorithmType.DDALine :
                return DDA();
            case AlgorithmType.BresenhamLine :
                return Bresenham();
            default:
                throw new NonValidAlgorithmException();
                
        }
    }

    private IEnumerable<BresPointInfo> Bresenham()
    {
        BresPointInfo PointInfo = new BresPointInfo();
            int dx = Math.Abs(XEnd - XStart),  dy = Math.Abs(YEnd - YStart);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy,  twoDyMinusDx = 2 * (dy - dx);

            /* Determine which endpoint to use as start position.  */
            if (XStart > XEnd) {
                x = XEnd;    
                y = YEnd;   
                XEnd = XStart;
            }
            else {
                x = XStart;    
                y = YStart;
            }

            while (x < XEnd) {
                PointInfo.Pk = p;
                x++;
                if (p < 0)
                    p += twoDy;
                else {
                    y++;
                    p += twoDyMinusDx;
                }

                PointInfo.x = x;
                PointInfo.y = y;
                yield return PointInfo;
            }
        
    }
    private IEnumerable<PointInfo> DDA()
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
            yield return new PointInfo
            {
                x = x,
                y = y,
            };
        }

    }
}