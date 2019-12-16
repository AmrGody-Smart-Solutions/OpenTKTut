/*H**********************************************************************
* FILENAME :        Cube.cs             DESIGN REF: OGLTUT00
*
* DESCRIPTION :
*       Cube create using OpenTK.
*
* PUBLIC FUNCTIONS :
*       void     ShapeDrawing( FileHandle )
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
    class Cube : OGLShape
    {
        public Cube(Vector3 center, float length,bool enableRotation = false)
        {
            Center = center;
            Length = length;
            EnableAutoRotate = enableRotation;
            rotation_speed = 1;
            rotationAxis = new Vector3(1f, 1f, 0f);
        }

       
        public float Length { get; set; }

        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            MeshPolygons = MeshElement.Cube(Length);
            
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(System.Drawing.Color.Red);
            for (int i = 0; i < MeshPolygons.Length; i++)
            {

                for (int j = 0; j < MeshPolygons[i].Vertices.Length; j++)
                {
                    GL.Normal3(MeshPolygons[i].Normal);
                    GL.Vertex3(MeshPolygons[i].Vertices[j]);
                }

            }
            GL.End();

        }

    }
}
