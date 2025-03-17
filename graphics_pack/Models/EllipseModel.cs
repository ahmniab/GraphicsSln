namespace graphics_pack.Models;

public class EllipseModel : IShape
{
    public IEnumerable<PointInfo> GetIndexes()
    {
        if (Algorithm == AlgorithmType.MidPointEllipse)
        {
            return midptellipse();
        }
        else
            throw new NonValidAlgorithmException();
    }

    public string name { get; set; } = "Ellipse";
    public string color { get; set; }
    public string? ImgSrc { get; set; }
    public AlgorithmType Algorithm { get; set; } = AlgorithmType.MidPointEllipse;
    public double X { get; set; }
    public double Y { get; set; }
    public double RX { get; set; }
    public double RY { get; set; }
    
    IEnumerable<PointInfo> midptellipse()
    {
     
        double dx, dy, d1, d2, x, y;
        x = 0;
        y = RY;
     
        // Initial decision parameter of region 1
        d1 = (RY * RY) - (RX * RX * RY) +
                        (0.25f * RX * RX);
        dx = 2 * RY * RY * x;
        dy = 2 * RX * RX * y;
         
        // For region 1
        while (dx < dy)
        {
         
            // points based on 4-way symmetry
            yield return new PointInfo {x = ( x + X)  , y = ( y + Y)};
            yield return new PointInfo {x = (-x + X) , y =  ( y + Y)};
            yield return new PointInfo {x = ( x + X)  , y = (-y + Y)};
            yield return new PointInfo {x = (-x + X)  , y = (-y + Y)};
            
     
            // Checking and updating value of
            // decision parameter based on algorithm
            if (d1 < 0) 
            {
                x++;
                dx = dx + (2 * RY * RY);
                d1 = d1 + dx + (RY * RY);
            }
            else
            {
                x++;
                y--;
                dx = dx + (2 * RY * RY);
                dy = dy - (2 * RX * RX);
                d1 = d1 + dx - dy + (RY * RY);
            }
        }
     
        // Decision parameter of region 2
        d2 = ((RY * RY) * ((x + 0.5f) * (x + 0.5f)))
            + ((RX * RX) * ((y - 1) * (y - 1)))
            - (RX * RX * RY * RY);
     
        // Plotting points of region 2
        while (y >= 0)
        {
     
            // points based on 4-way symmetry
            yield return new PointInfo {x = ( x + X)  , y = ( y + Y)};
            yield return new PointInfo {x = (-x + X) , y =  ( y + Y)};
            yield return new PointInfo {x = ( x + X)  , y = (-y + Y)};
            yield return new PointInfo {x = (-x + X)  , y = (-y + Y)};

            // Checking and updating parameter
            // value based on algorithm
            if (d2 > 0)
            {
                y--;
                dy = dy - (2 * RX * RX);
                d2 = d2 + (RX * RX) - dy;
            }
            else
            {
                y--;
                x++;
                dx = dx + (2 * RY * RY);
                dy = dy - (2 * RX * RX);
                d2 = d2 + dx - dy + (RX * RX);
            }
        }
    }
}