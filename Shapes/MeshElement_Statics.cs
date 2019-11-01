using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{
    partial class MeshElement
    {
        private static  double _converter_factor = Math.PI / 180;
        public static MeshElement[] Sphere(double radius)
        {
            List<MeshElement> res = new List<MeshElement>();
            
            int dlta = 10;
            double delta = Convert.ToDouble(dlta) * _converter_factor;
            for (int theta = 0;theta<=180-dlta;theta += dlta )
            {
                for (int phi = 0; phi <= 360 - dlta; phi += dlta)
                {


                    // 1 ===== 4
                    // |       |
                    // 2 ===== 3

                    Vector3 _1 = GetCartezianOf(radius, theta, phi);
                    Vector3 _2 = GetCartezianOf(radius, theta + dlta, phi);
                    Vector3 _3 = GetCartezianOf(radius, theta + dlta, phi + dlta);
                    Vector3 _4 = GetCartezianOf(radius, theta, phi + dlta);

                    Vector3 normal = GetNormal(_1, _2, _4);
                    Vector3[] vertices = { _1, _2, _3, _4 };
                    res.Add(new MeshElement(4, normal, vertices));

                }
            }


            return res.ToArray();
        }
        /// <summary>
        /// Loads a bitmap image into bitmapData object. It assumes 24 bit bmp format
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="bitmapData"></param>
        /// <returns></returns>
        public static bool LoadImageIntoBitMapData_rgb24bit(string imagePath,out  System.Drawing.Imaging.BitmapData bitmapData)
        {
            bool res = true;
            bitmapData = new System.Drawing.Imaging.BitmapData();
            var bmp = new System.Drawing.Bitmap(imagePath);
            var imageRect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            bitmapData = bmp.LockBits(imageRect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmp.UnlockBits(bitmapData);
            res = bitmapData.Width == bmp.Width && bitmapData.Height == bmp.Height;
            return res;
        }
        private static Vector3 GetNormal(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Vector3 res = new Vector3();
            //    b
            // 1 ---> 3
            // |a
            // 7
            // 2
            var _p1 = new  Vector3d(p1.X, p1.Y, p1.Z);
            var _p2 = new Vector3d(p2.X, p2.Y, p2.Z);
            var _p3 = new Vector3d(p3.X, p3.Y, p3.Z);
            Vector3d a = _p2 - _p1;
            Vector3d b = _p3 - _p1;
            var temp = Vector3d.Cross(a, b);
            temp.Normalize();
            res.X = Convert.ToSingle( temp.X);
            res.Y = Convert.ToSingle(temp.Y);
            res.Z = Convert.ToSingle(temp.Z);

            return res;
        }

        private static Vector3 GetCartezianOf(double radius, int theta, int phi)
        {
            double th = Convert.ToDouble(theta) * _converter_factor;
            double ph = Convert.ToDouble(phi) * _converter_factor;
            float x = Convert.ToSingle(radius * Math.Sin(th) * Math.Cos(ph));
            float y = Convert.ToSingle(radius * Math.Sin(th) * Math.Sin(ph));
            float z = Convert.ToSingle(radius * Math.Cos(th));
            Vector3 _1 = new Vector3(x, y, z);
            return _1;
        }

    }
}
