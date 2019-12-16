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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{
    class Sphere : OGLShape
    {
        public Vector3 Color {get; set;}
        public Sphere(Vector3 center, double radius,bool AutoRotate = false,Vector3 color = default(Vector3))
        {
            Center = center;
            Radius = radius;
            EnableAutoRotate = AutoRotate;
            Color = color;
            rotation_speed = 1;
            rotationAxis = new Vector3(1f, 1f, 0f);
        }

        
        public double Radius { get; set; }
       
        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            MeshPolygons= MeshElement.Sphere(Radius);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color);
            for(int i=0;i< MeshPolygons.Length;i++)
            {
                for (int j=0;j< MeshPolygons[i].Vertices.Length;j++)
                {
                    // set point normal and postion
                    GL.Normal3(MeshPolygons[i].Vertices[j].Normalized());
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
