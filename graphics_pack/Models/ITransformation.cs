using SixLabors.ImageSharp.PixelFormats;

namespace graphics_pack.Models;

public interface ITransformation
{
    public string Name { get; set; }
    public Rgba32 [,] Apply(Rgba32 [,] input);
}