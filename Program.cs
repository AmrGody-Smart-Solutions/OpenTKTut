/*H**********************************************************************
* FILENAME :        Program.cs             DESIGN REF: OGLTUT05
*
* DESCRIPTION :
*       starting code.
*
* PUBLIC FUNCTIONS :
*       
*       void Main(string[] args)
*      
*
* NOTES :
*       These functions are a part of the Computer Graphics course materias suite;
*      
*
*       Copyright Amr M. Gody. 2019, 2019.  All rights reserved.
*
* AUTHOR :    Amr M. Gody        START DATE :    24 OCT 2019
*
* CHANGES :
*
* REF NO  VERSION DATE    WHO     DETAIL
* 1       1       24OCT19 AG      first working version
*
*******************************************************************************H*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace OpenTKTut
{
    class Program
    {
        static void Main(string[] args)
        {

            string earth = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\earth.bmp";
            Bitmap bitmapearth = new Bitmap(earth);
            Rectangle earthrect = new Rectangle(0, 0, bitmapearth.Width, bitmapearth.Height);
            BitmapData earthdata = bitmapearth.LockBits(earthrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapearth.UnlockBits(earthdata);

            string sun = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\sun.bmp";
            Bitmap bitmapsun = new Bitmap(sun);
            Rectangle sunrect = new Rectangle(0, 0, bitmapsun.Width, bitmapsun.Height);
            BitmapData sundata = bitmapsun.LockBits(sunrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapsun.UnlockBits(sundata);

            string moon = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\moon.bmp";
            Bitmap bitmapmoon = new Bitmap(moon);
            Rectangle moonrect = new Rectangle(0, 0, bitmapmoon.Width, bitmapmoon.Height);
            BitmapData moondata = bitmapmoon.LockBits(sunrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapmoon.UnlockBits(moondata);

            string venus = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\venus.bmp";
            Bitmap bitmapvenus = new Bitmap(venus);
            Rectangle venusrect = new Rectangle(0, 0, bitmapvenus.Width, bitmapvenus.Height);
            BitmapData venusdata = bitmapvenus.LockBits(venusrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapvenus.UnlockBits(venusdata);

            string mars = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\mars.bmp";
            Bitmap bitmapmars = new Bitmap(mars);
            Rectangle marsrect = new Rectangle(0, 0, bitmapmars.Width, bitmapmars.Height);
            BitmapData marsdata = bitmapmars.LockBits(marsrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapmars.UnlockBits(marsdata);


            SceenEngine sceenEngine = new SceenEngine(sundata, venusdata, marsdata, earthdata, moondata);



            Shapes.Sphere sp = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 3, true,false,false, 1, 0, 0, 0,  0, 1); //sun
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 1.25, true,true,false, 1, 6, 3, 0, 0, 2);
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 1.75, true, true, false, 2, 10, 2, 0, 0, 3);
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3( 0.0f,0.0f,43.0f), 2, true, true, false, 3, 15, 1, 0, 0, 4);              //earth
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 0.5, true, true, true, 1, 15, 1, 2, 2.65f, 5);            //moon
            sceenEngine.AddShape(sp);

            Shapes.CircleDraw CD = new Shapes.CircleDraw(new Vector3(0.0f, 0.0f, 43.0f), 6, false, false, false, 1, 15, 1, 2, 2, 5);
            sceenEngine.AddShape(CD);

            CD = new Shapes.CircleDraw(new Vector3(0.0f, 0.0f, 43.0f), 10, false, false, false, 1, 15, 1, 2, 2, 5);
            sceenEngine.AddShape(CD);

            CD = new Shapes.CircleDraw(new Vector3(0.0f, 0.0f, 43.0f), 15, false, false, false, 1, 15, 1, 2, 2, 5);
            sceenEngine.AddShape(CD);

            sceenEngine.Start();
           //sceenEngine.AddShape()
           
        }
    }
}
