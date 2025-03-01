using graphics_pack.Models;

namespace graphics_pack.Graphics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public class ImageBuilder
{
    public Image<Rgba32> ImageMatrex { get; } = new Image<Rgba32>(500, 500);
    private Rgba32 BgColor = new Rgba32(0, 0, 0, 0);
    private Rgba32 FgColor;
    public IShape Shape;

    public ImageBuilder SetBgColor(Rgba32 color)
    {
        BgColor = color;
        return this;
    }

    public ImageBuilder SetBgColor(string color)
    {
        BgColor = Color.ParseHex(color);
        return this;
    }

    public ImageBuilder SetFgColor(string color)
    {
        FgColor = Color.ParseHex(color);
        return this;
    }

    public ImageBuilder SetShape(IShape shape)
    {
        Shape = shape;
        return this;
    }

    private void FillBg()
    {
        for (int x = 0; x < ImageMatrex.Width; x++)
        {
            for (int y = 0; y < ImageMatrex.Height; y++)
            {
                ImageMatrex[x, y] = BgColor;
            }
        }
    }
    
    private void FillShape()
    {
        foreach (var p in Shape.GetIndexes())
        {
            try
            {
                ImageMatrex[p.GetXOnImageMatrex(), p.GetYOnImageMatrex()] = FgColor;
            }
            catch (OutOfImageBoundException) { }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }
    }
    
    public ImageBuilder Builed()
    {
        FillBg();
        SetFgColor(Shape.color ?? "#000000");
        FillShape();
        return this;
    }


}