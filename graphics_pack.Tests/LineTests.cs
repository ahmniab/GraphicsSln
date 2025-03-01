namespace graphics_pack.Tests;
using Xunit;
using graphics_pack.Models;
public class LineTests
{
    [Fact]
    public void DDA_is_working_fine()
    {
        LineModel l = new();
        l.XStart = 2;
        l.YStart = 3;
        l.XEnd = 9;
        l.YEnd = 8;
        l.Algorithm = AlgorithmType.LineDDA;
        
        Point [] referencePoints = new Point[]
        {
            new Point {x = 3, y = 3.71},
            new Point {x = 4, y = 4.43},
            new Point {x = 5, y = 5.14},
            new Point {x = 6, y = 5.86},
            new Point {x = 7, y = 6.57},
            new Point {x = 8, y = 7.29},
            new Point {x = 9, y = 8   },
        };
        Point[] outputPoints = l.GetIndexes().ToArray();
        //Assert
        Assert.Equal(referencePoints.Length, outputPoints.Length);
        
        for (int i = 0; i < referencePoints.Length; i++)
        {
            Assert.Equal ((int) Math.Round(referencePoints[i].x),(int) Math.Round(outputPoints[i].x));
            Assert.Equal ((int)Math.Round(referencePoints[i].y), (int)Math.Round(outputPoints[i].y));
        }
                
    }
}