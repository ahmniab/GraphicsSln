using graphics_pack.Models;
using SixLabors.ImageSharp;

namespace graphics_pack.Graphics;

public static class ImageHelper
{
    private static int ImageId = 0;

    public static void Save(this ImageBuilder ImageBuilder)
    {
        
        ImageBuilder.Shape.ImgSrc = $"/Generated/{ImageBuilder.Shape.name}-{ImageId++}.png";
        ImageBuilder.ImageMatrex.Save($"wwwroot/assets{ImageBuilder.Shape.ImgSrc}");
        
    }

    public static bool DeleteAllGeneratedFiles()
    {
        try
        {
            string[] Images = Directory.GetFiles("wwwroot/assets/Generated");

            foreach (string Image in Images)
            {
                File.Delete(Image);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool DeleteImage(this IShape Shape)
    {
        try
        {
            File.Delete($"wwwroot/assets{Shape.ImgSrc}");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}