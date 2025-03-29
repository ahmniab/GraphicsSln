using System.ComponentModel.DataAnnotations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace graphics_pack.Models;

public class RotationModel : ITransformation
{
    
    [Required(ErrorMessage = "Please provide an angle in degrees.")]
    public double AngleDeg { get; set; }
    public string Name { get; set; } = "Rotation";
    public void Apply(Rgba32[,] input, Rgba32[,] output)
    {
        int width = input.GetLength(0);
        int height = input.GetLength(1);
    
        double radians = -AngleDeg * Math.PI / 180;
        double cos = Math.Cos(radians);
        double sin = Math.Sin(radians);
    
        double centerX = (width - 1) / 2.0;
        double centerY = (height - 1) / 2.0;
    
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                double dx = x - centerX;
                double dy = y - centerY;
            
                int srcX = (int)Math.Round(centerX + dx * cos - dy * sin);
                int srcY = (int)Math.Round(centerY + dx * sin + dy * cos);
            
                output[x, y] = (srcX >= 0 && srcX < width && srcY >= 0 && srcY < height) 
                    ? input[srcX, srcY] 
                    : Color.Transparent;
            }
        }
    }
}