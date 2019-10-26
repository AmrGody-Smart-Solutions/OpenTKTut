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
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            MeshPolygons= MeshElement.Sphere(Radius);
            GL.Begin(BeginMode.Quads);
            GL.Color3(new float[] { 1.0f, 1.0f, 0.0f });
            for(int i=0;i< MeshPolygons.Length;i++)
            {
                GL.Normal3(MeshPolygons[i].Normal);
                for(int j=0;j< MeshPolygons[i].Vertices.Length;j++)
                {
                    GL.Vertex3(MeshPolygons[i].Vertices[j]);
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
