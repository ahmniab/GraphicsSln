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


    [Fact]
    public void BresLine_returns_correct_line_every_function_call()
    {
        LineModel l = new();
        l.XStart = 5;
        l.YStart = 5;
        l.XEnd = 10;
        l.YEnd = 20;
        l.Algorithm = AlgorithmType.BresenhamLine;
        
        PointInfo [] point_arr1 = l.GetIndexes().ToArray();
        PointInfo [] point_arr2 = l.GetIndexes().ToArray();
        
        Assert.Equal(point_arr1.Length, point_arr2.Length);
        
        for (int i = 0; i < point_arr1.Length; i++)
        {
            Assert.Equal (point_arr1[i].x, point_arr2[i].x);
            Assert.Equal (point_arr1[i].y, point_arr2[i].y);
        }

    }
}