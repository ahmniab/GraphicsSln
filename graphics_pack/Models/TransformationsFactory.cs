using System.Collections;
using graphics_pack.Graphics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace graphics_pack.Models;

public class TransformationsFactory : IEnumerable<ITransformation>
{
    public string ImageSrc { get; set; } = "assets/imgs/penguin.png";
    Image<Rgba32> image;
    private Rgba32[,] input, output;
    public TransformationsFactory()
    {
        ImageSrc  = "assets/imgs/penguin.png";
        image = ImageHelper.LoadPenguinImage();
        input = new Rgba32[image.Width, image.Height];
        ResetInput();
        output = new Rgba32[image.Width, image.Height];
    }

    private List<ITransformation> Transformations { get; set; } 
        = new List<ITransformation>();

    public void AddTransformation(ITransformation transformation)
    {
        Transformations.Add(transformation);
    }
    
    public void Reset()
    {
        ImageSrc = "assets/imgs/penguin.png";
        Transformations.Clear();
    }

    public void DeleteTransformation(ITransformation t)
    {
        Transformations.Remove(t);
    }


    private void ResetInput()
    {
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                input[x, y] = image[x, y];
            }
        }
    }

    private void ResetOutput()
    {
        Rgba32 color = new Rgba32 {R = 0, G = 0, B = 0, A = 0};
        
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                output[x, y] = color;
            }
        }
    }

    private void SwapIO()
    {
        (input, output) = (output, input);
    }

    public void ApplyAndSave()
    {
        Apply();
        SaveImage();
    }

    public void Apply()
    {
        ResetInput();
        ResetOutput();
        foreach (var t in Transformations)
        {
            t.Apply(input, output);
            SwapIO();
            ResetOutput();
        }
        
    }

    public void SaveImage()
    {
        using (Image<Rgba32> OutputImage = new Image<Rgba32>(image.Width, image.Height))
        {
            for (int y = 0; y < OutputImage.Height; y++)
            {
                for (int x = 0; x < OutputImage.Width; x++)
                {
                    OutputImage[x, y] = input[x, y];
                }
            }

            ImageSrc = "/Generated/penguin.png";
            OutputImage.Save($"wwwroot/assets{ImageSrc}");
        }
    }
    public IEnumerator<ITransformation> GetEnumerator()
    {
        return Transformations.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}