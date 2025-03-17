using SixLabors.ImageSharp.PixelFormats;

namespace graphics_pack.Models;

public interface ITransformation
{
    public string Name { get; set; }
    public void Apply(Rgba32 [,] input, Rgba32 [,] output);
}