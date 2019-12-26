using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{
    public class Texture
    {
        private Texture()
        {
        }
        public static int LoadTexture(String textureName)
        {
            Bitmap bitmap;

            bitmap = new Bitmap(Path.Combine("texture", textureName));

            GL.GenTextures(1, out int texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            Console.Write("\nbefore: " + texture + "\n");
            GL.TexParameter(TextureTarget.Texture2D,
                            TextureParameterName.TextureMinFilter,
                            (int)TextureMinFilter.Linear);
            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width,
                                                                           bitmap.Height),
                                                                           ImageLockMode.ReadOnly,
                                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            return texture;
        }
    }
}
