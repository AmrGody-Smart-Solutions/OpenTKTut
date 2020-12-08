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
using System.Drawing;

namespace OpenTKTut.Shapes
{
    class Cube : OGLShape
    {
        public Cube(Vector3 center, float length,
                    bool enableRotation = false, Color color = default(Color))
        {
            Center = center;
            Length = length;
            EnableAutoRotate = enableRotation;
            rotation_speed = 1;
            rotationAxis = new Vector3(1f, 1f, 0f);
            if (color == default(Color))
            {
                color = Color.White;
            }
            Color_sys = color;
        }

       
        public float Length { get; set; }

        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            MeshPolygons = MeshElement.Cube(Length);
            
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color_sys);
            for (int i = 0; i < MeshPolygons.Length; i++)
            {

                for (int j = 0; j < MeshPolygons[i].Vertices.Length; j++)
                {
                    switch (j)
                    {
                        case 0:GL.TexCoord2(0,1);break;
                        case 1:GL.TexCoord2(0,0);break;
                        case 2:GL.TexCoord2(1,0);break;
                        case 3:GL.TexCoord2(1,1);break;
                    }
                    //GL.Normal3(MeshPolygons[i].Normal);
                    GL.Normal3(MeshPolygons[i].Normals[j]);
                    GL.Vertex3(MeshPolygons[i].Vertices[j]);
                }

            }
            GL.End();

        }

    }
}
