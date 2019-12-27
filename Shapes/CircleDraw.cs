using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;


namespace OpenTKTut.Shapes
{
    class CircleDraw : OGLShape
    {
        public CircleDraw(Vector3 center, double radius, bool AutoRotate, bool orbiting, bool moon, float rotatingSpeed, float RotatingRadius, float orbitingSpeed, float moonorbit, float moonSpeed, int textype)
        {
            _Center = center;
            Radius = radius;
            EnableAutoRotate = false;
            Orbiting = false;
            Moon = false;
            RotatingSpeed = rotatingSpeed;
            Rotatingradius = RotatingRadius;
            OrbitingSpeed = orbitingSpeed;
            MoonOrbit = moonorbit;
            MoonSpeed = moonSpeed;

            //calculate positions 

            for (int phi = 0; phi < 361; phi++)
            {

                position[phi].X = (float)(Radius * Math.Cos(phi * Math.PI / 180));
                position[phi].Z = (float)(Radius * Math.Sin(phi * Math.PI / 180));
                position[phi].Y = 0;
            }
        }

        public double Radius { get; set; }
        public Vector3[] position = new Vector3[361];

        protected override void ShapeDrawing()
        {


            GL.LineWidth(2);
            GL.Begin(PrimitiveType.LineStrip);

            GL.Color3(1.0f, 1.0f, 1.0f);

            for (int phi = 0; phi < 361; phi++)
            {

                GL.Vertex3(position[phi]);
            }

            GL.End();
        }


    }

}
