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
        public Cube(Vector3 center, double length,bool enableRotation = false)
        {
            Center = center;
            Length = length;
            EnableAutoRotate = enableRotation;
        }

       
        public double Length { get; set; }

        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.Begin(BeginMode.Quads);

            //Front Face

            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(-Length / 2, -Length / 2, Length / 2);
            GL.Vertex3(Length / 2, -Length / 2, Length / 2);
            GL.Vertex3(Length / 2, Length / 2, Length / 2);
            GL.Vertex3(-Length / 2, Length / 2, Length / 2);
            //Rear Face

            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Vertex3(-Length / 2, -Length / 2, -Length / 2);
            GL.Vertex3(Length / 2, -Length / 2, -Length / 2);
            GL.Vertex3(Length / 2, Length / 2, -Length / 2);
            GL.Vertex3(-Length / 2, Length / 2, -Length / 2);

            //Rear Left

            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-Length / 2, -Length / 2, -Length / 2);
            GL.Vertex3(-Length / 2, -Length / 2, Length / 2);
            GL.Vertex3(-Length / 2, Length / 2, Length / 2);
            GL.Vertex3(-Length / 2, Length / 2, -Length / 2);

            //Rear Right

            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(Length / 2, -Length / 2, -Length / 2);
            GL.Vertex3(Length / 2, -Length / 2, Length / 2);
            GL.Vertex3(Length / 2, Length / 2, Length / 2);
            GL.Vertex3(Length / 2, Length / 2, -Length / 2);

            //Rear bottom

            GL.Color3(0.0f, 1.0f, 1.0f);
            GL.Vertex3(-Length / 2, -Length / 2, -Length / 2);
            GL.Vertex3(-Length / 2, -Length / 2, Length / 2);
            GL.Vertex3(Length / 2, -Length / 2, Length / 2);
            GL.Vertex3(Length / 2, -Length / 2, -Length / 2);

            //Rear Up

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(-Length / 2, Length / 2, -Length / 2);
            GL.Vertex3(-Length / 2, Length / 2, Length / 2);
            GL.Vertex3(Length / 2, Length / 2, Length / 2);
            GL.Vertex3(Length / 2, Length / 2, -Length / 2);


            GL.End();
        }

        //public override void Draw()
        //{
            
        //    GL.PushMatrix();
        //    base.Draw();
            

        //    GL.Begin(BeginMode.Quads);

        //    //Front Face
           
        //    GL.Color3(1.0f, 0.0f, 0.0f);
        //    GL.Vertex3(-Length / 2, -Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, -Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, Length / 2, Length / 2);
        //    GL.Vertex3(-Length / 2, Length / 2, Length / 2);
        //    //Rear Face
            
        //    GL.Color3(1.0f, 1.0f, 0.0f);
        //    GL.Vertex3(-Length / 2, -Length / 2, -Length / 2);
        //    GL.Vertex3(Length / 2, -Length / 2, -Length / 2);
        //    GL.Vertex3(Length / 2, Length / 2, -Length / 2);
        //    GL.Vertex3(-Length / 2, Length / 2, -Length / 2);

        //    //Rear Left

        //    GL.Color3(1.0f, 1.0f, 1.0f);
        //    GL.Vertex3(-Length / 2, -Length / 2, -Length / 2);
        //    GL.Vertex3(-Length / 2, -Length / 2, Length / 2);
        //    GL.Vertex3(-Length / 2, Length / 2, Length / 2);
        //    GL.Vertex3(-Length / 2, Length / 2, -Length / 2);

        //    //Rear Right

        //    GL.Color3(0.0f, 1.0f, 0.0f);
        //    GL.Vertex3(Length / 2, -Length / 2, -Length / 2);
        //    GL.Vertex3(Length / 2, -Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, Length / 2, -Length / 2);

        //    //Rear bottom

        //    GL.Color3(0.0f, 1.0f, 1.0f);
        //    GL.Vertex3(-Length / 2, -Length / 2, -Length / 2);
        //    GL.Vertex3(-Length / 2, -Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, -Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, -Length / 2, -Length / 2);

        //    //Rear Up

        //    GL.Color3(0.0f, 0.0f, 1.0f);
        //    GL.Vertex3(-Length / 2, Length / 2, -Length / 2);
        //    GL.Vertex3(-Length / 2, Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, Length / 2, Length / 2);
        //    GL.Vertex3(Length / 2, Length / 2, -Length / 2);


        //    GL.End();



        //    GL.PopMatrix();
        //}

    }
}
