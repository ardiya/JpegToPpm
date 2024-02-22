namespace ConsoleApp1;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Pbm;


class ConsoleApp1
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ConsoleApp1.exe /path/to/input.jpg /path/to/output.ppm");
            return;
        }
        for (int i = 0; i < args.Length; i++)
            Console.WriteLine("args[{0}] = {1}", i, args[i]);

        string in_filename = args[0];
        string out_filename = args[1];
        using (Image image = Image.Load(in_filename))
        {
            var ppmEncoder = new PbmEncoder() { ColorType = PbmColorType.Rgb, Encoding = PbmEncoding.Binary };
            image.Save(out_filename, ppmEncoder);
            Console.WriteLine("Saved to {0} with '{1}' '{2}' '{3}'", out_filename, ppmEncoder.ComponentType.ToString(), ppmEncoder.ColorType.ToString(), ppmEncoder.Encoding.ToString());
        }
    }
}
