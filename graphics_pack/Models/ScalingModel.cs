using System.ComponentModel.DataAnnotations;
using SixLabors.ImageSharp.PixelFormats;

namespace graphics_pack.Models;

public class ScalingModel : ITransformation
{
    public string Name { get; set; } = "Scale";
    [Required(ErrorMessage = "Please provide a value for the scale X.")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Value must be at least 0.1 to prevent division by zero.")]

    public double ScaleX { get; set; }
    [Required(ErrorMessage = "Please provide a value for the scale Y.")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Value must be at least 0.1 to prevent division by zero.")]
    public double ScaleY { get; set; }
    public void Apply(Rgba32[,] input, Rgba32[,] output)
    {
        int width = input.GetLength(0);
        int height = input.GetLength(1);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                double originalX = x / ScaleX;
                double originalY = y / ScaleY;
            
                int sourceX = (int)Math.Clamp(originalX, 0, width - 1);
                int sourceY = (int)Math.Clamp(originalY, 0, height - 1);
            
                output[x, y] = input[sourceX, sourceY];
            }
        }
    }
}