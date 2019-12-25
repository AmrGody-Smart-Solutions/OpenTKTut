using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTut.Shapes
{
    class Orbit : OGLShape
    {
        float[] color;
        public Orbit(
                      Vector3 center,
                      double radius,
                      bool autoRotate,
                      float[] color) : base(center)
        {
            Center = center;
            this.color = color;
            Radius = radius;
            EnableAutoRotate = autoRotate;
         //  GL.BindTexture(TextureTarget.Texture2D, 0);

        }

        public double Radius { get; set; }
        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(BeginMode.Points);
           // GL.BindTexture(TextureTarget.Texture2D, 0);

            GL.Color3(color);
            float x, z, i;


            for ( i = 0; i < 2*Math.PI; i=i + 0.0001f)
            {
                // GL.Normal3(MeshPolygons[i].Normal);
                x = (float) (Radius * Math.Cos(i));
                z = (float)(Radius * Math.Sin(i));

                GL.Vertex3((double)x, -1.0,z);

      

            }
            GL.End();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);


        }
    }
}
