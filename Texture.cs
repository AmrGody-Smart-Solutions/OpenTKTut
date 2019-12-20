using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using System.Drawing;
using System.Drawing.Imaging;


namespace OpenTKTut
{
    class Texture
    {
        int Handle { get; set; }
        public Texture(String path)
        {
            Handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, Handle);

            BitmapData bmpdata = load(path);
            
            GL.TexImage2D(TextureTarget.Texture2D,
                          0, PixelInternalFormat.Rgb,
                          bmpdata.Width, bmpdata.Height,
                          0, OpenTK.Graphics.OpenGL4.PixelFormat.Bgr, PixelType.UnsignedByte,
                          bmpdata.Scan0
                          );
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }
        BitmapData load(String path){
                        //Load the image
            Bitmap bmp = new Bitmap(path);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);


            //Convert ImageSharp's format into a byte array, so we can use it with OpenGL.
            BitmapData bmp_data = bmp.LockBits(rect, ImageLockMode.ReadOnly,
                                               System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            bmp.UnlockBits(bmp_data);
            return bmp_data;
        }
    }
}
