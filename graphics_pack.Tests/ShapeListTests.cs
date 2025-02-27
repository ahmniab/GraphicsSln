namespace graphics_pack.Tests;
using Moq;
using Xunit;
using graphics_pack.Models;

public class ShapeListTests
{
    [Fact]
    public void Can_Add_Element()
    {
        // Arrange
        var shape = new Mock<IShape>();
        shape.Setup(s => s.name).Returns("Line1");
        LineModel line = new LineModel();
        var shapeList = new ShapeList();

        // Act
        shapeList.AddShape(line);
        Assert.Single(shapeList.Shapes);

        shapeList.Shapes = new List<IShape>();
        (shapeList.Shapes as List<IShape>).Add(line);
        // Assert
        Assert.Single(shapeList.Shapes);
    }

    
}
