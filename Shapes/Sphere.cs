using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{
    class Sphere : OGLShape
    {
        public Sphere(Vector3 center, double radius,bool AutoRotate = false)
        {
            Center = center;
            Radius = radius;
            EnableAutoRotate = AutoRotate;
        }

        public Vector3 Center { get; set; }
        public double Radius { get; set; }
        

        public override void Draw()
        {
            base.Draw();
            GL.PushMatrix();

            GL.PopMatrix();
        }
    }
}
