/*H**********************************************************************
* FILENAME :        Sphere.cs             DESIGN REF: OGLTUT05
*
* DESCRIPTION :
*       Sphere object  functions.
*
* PUBLIC FUNCTIONS :
*       
*       void     ShapeDrawing(  )
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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{

    class Sphere : OGLShape
    {

        public float[] Color = new float[] { 1.0f, 1.0f, 1.0f };
        private int texture;
        public Sphere(Vector3 center,
                      double radius,
                      bool AutoRotate,
                      String textureName = "meteor.jpg") : base(center)
        {
            Center = center;
            Radius = radius;
            EnableAutoRotate = AutoRotate;

            texture = Texture.LoadTexture(textureName);
        }


        public double Radius { get; set; }

        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            MeshPolygons = MeshElement.Sphere(Radius);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color);

            for (int i = 0; i < MeshPolygons.Length; i++)
            {
                for (int j = 0; j < MeshPolygons[i].Vertices.Length; j++)
                {
                    GL.Normal3(MeshPolygons[i].Vertices[j]);
                    double x = MeshPolygons[i].Vertices[j].Normalized().X;
                    double y = MeshPolygons[i].Vertices[j].Normalized().Y;
                    double z = MeshPolygons[i].Vertices[j].Normalized().Z;

                    double u = 0.5 + Math.Atan2(z, x) / (2 * Math.PI);
                    double v = 0.5 - Math.Asin(y) / Math.PI;

                    GL.TexCoord2(u, v);
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
