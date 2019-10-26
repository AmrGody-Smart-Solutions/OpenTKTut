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

        
        public double Radius { get; set; }
       
        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            MeshElement[] shapePolygons = MeshElement.Sphere(Radius);
            GL.Begin(BeginMode.Quads);
            for(int i=0;i< shapePolygons.Length;i++)
            {
                GL.Normal3(shapePolygons[i].Normal);
                for(int j=0;j<shapePolygons[i].Vertices.Length;j++)
                {
                    GL.Vertex3(shapePolygons[i].Vertices[j]);
                }
               
            }
            GL.End();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
        }

        private Vector3[] ConstructMesh()
        {
            throw new NotImplementedException();
        }
    }
}
