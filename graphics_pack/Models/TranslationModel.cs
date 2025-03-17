using SixLabors.ImageSharp.PixelFormats;

namespace graphics_pack.Models;

public class TranslationModel : ITransformation
{
    public string Name { get; set; } = "Translation";
    public int delta_x;
    public int delta_y;
    
    public void Apply(Rgba32[,] input, Rgba32[,] output)
    {
        for (int x = 0; x < input.GetLength(0); x++)
        {
            for (int y = 0; y < input.GetLength(1); y++)
            {
                try
                {
                    output[x + delta_x, y + delta_y] = input[x, y];
                }
                catch (IndexOutOfRangeException e)
                {
                    if (x + delta_x > input.GetLength(0) - 1 
                     || y + delta_y > input.GetLength(1) - 1)
                        break;
                    if (x + delta_x < 0 || y + delta_y < 0)
                        continue;
                    
                }
            }
        }
    }

}