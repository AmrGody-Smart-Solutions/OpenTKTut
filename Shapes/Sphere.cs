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
using System.Drawing;
using System.Drawing.Imaging;

namespace OpenTKTut.Shapes
{
    class Sphere : OGLShape
    {
        public Sphere(Vector3 center, double radius, bool AutoRotate,bool orbiting ,bool moon ,float rotatingSpeed, float RotatingRadius , float orbitingSpeed, float moonorbit , float moonSpeed, int textype)
        {
            _Center = center;
            Radius = radius;
            MeshPolygons = MeshElement.Sphere(Radius); //compute meshpolygons only one time
            EnableAutoRotate = AutoRotate;
            Orbiting = orbiting;
            Moon = moon;
            RotatingSpeed = rotatingSpeed;
            Rotatingradius = RotatingRadius;
            OrbitingSpeed = orbitingSpeed;
            MoonOrbit = moonorbit;
            MoonSpeed = moonSpeed;
            Textype = textype;
        }

        
        public double Radius { get; set; }
        public int Textype;

        protected override void ShapeDrawing()
        {
            //base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindTexture(TextureTarget.Texture2D, Textype);


            GL.Begin(PrimitiveType.Quads);
            GL.Color3(new float[] { 1.0f, 1.0f, 1.0f });
            for (int i=0;i< MeshPolygons.Length;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GL.Normal3(MeshPolygons[i].Vertices[j]);
                    GL.TexCoord2(MeshPolygons[i].Texcoord[j]);
                    GL.Vertex3(MeshPolygons[i].Vertices[j]);
                }
               
            }
            GL.End();
            
            
        }

       
    }
}
