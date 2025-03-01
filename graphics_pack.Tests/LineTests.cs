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
        l.Algorithm = AlgorithmType.DDALine;
        
        PointInfo [] referencePoints = new PointInfo[]
        {
            new PointInfo {x = 3, y = 3.71},
            new PointInfo {x = 4, y = 4.43},
            new PointInfo {x = 5, y = 5.14},
            new PointInfo {x = 6, y = 5.86},
            new PointInfo {x = 7, y = 6.57},
            new PointInfo {x = 8, y = 7.29},
            new PointInfo {x = 9, y = 8   },
        };
        PointInfo[] outputPoints = l.GetIndexes().ToArray();
        //Assert
        Assert.Equal(referencePoints.Length, outputPoints.Length);
        
        for (int i = 0; i < referencePoints.Length; i++)
        {
            Assert.Equal ((int) Math.Round(referencePoints[i].x),(int) Math.Round(outputPoints[i].x));
            Assert.Equal ((int)Math.Round(referencePoints[i].y), (int)Math.Round(outputPoints[i].y));
        }
                
    }
}