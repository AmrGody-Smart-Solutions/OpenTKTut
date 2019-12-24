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
        public Sphere(Vector3 center, double radius,bool AutoRotate = false)
        {
            EnableAutoRotate_at_other_place_plant = false;
            Color = new float[3] { 0.5f, 0.5f, 0.5f };

            Center = center;
            Radius = radius;
            EnableAutoRotate = AutoRotate;
            EnableAutoRotate_at_other_place_sun = false;
            angle_rotate_far_center_sun = new Vector3(45, 45, 45);
            speed_sun = 1.0f;
        }
        public Sphere(Vector3 center, double radius, Vector3 center_r, bool AutoRotate = false, bool AutoRotate_c = false)
        {
            EnableAutoRotate_at_other_place_plant = false;

            Center = center;
            Radius = radius;
            EnableAutoRotate = AutoRotate;
            Center_rotate_sun = center_r;
            EnableAutoRotate_at_other_place_sun = AutoRotate_c;
            angle_rotate_far_center_sun = new Vector3(45, 45, 45);
            Color = new float[3] { .5f, 0.5f, 0.5f };
            speed_sun = 1.0f;
        }
        public Sphere(Vector3 center, double radius, Vector3 center_r, Vector3 center_r_rotate_angle, bool AutoRotate = false, bool AutoRotate_c = false)
        {
            EnableAutoRotate_at_other_place_plant = false;

            Center = center;
            Radius = radius;
            EnableAutoRotate = AutoRotate;
            Center_rotate_sun = center_r;
            EnableAutoRotate_at_other_place_sun = AutoRotate_c;
            angle_rotate_far_center_sun = center_r_rotate_angle;
            Color = new float[3] { 0.5f, 0.5f, 0.5f };
            speed_sun = 1.0f;

        }
        public double Radius { get; set; }
       
        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            MeshPolygons = MeshElement.Sphere(Radius);

            GL.Begin(BeginMode.Quads);
            // Console.WriteLine(c);
            Vector2 p = new Vector2();
            Vector3 p3 = new Vector3();
            // List <Vector2> p2 = new List<Vector2>();
            GL.Color3(new float[] { 1.0f, 1.0f, 0.0f });
            for (int i = 0; i < MeshPolygons.Length; i++)
            {
                for (int j = 0; j < MeshPolygons[i].Vertices.Length; j++)
                {
                    GL.Normal3(MeshPolygons[i].Vertices[j]);
                    p3 = MeshPolygons[i].Vertices[j];
                    if (tex_enable)
                    {
                        p3.Normalize();
                        p.X = 0.5f + Convert.ToSingle(Math.Atan2(p3.X, p3.Z)) / (2.0f * Convert.ToSingle(Math.PI));
                        p.Y = 0.5f - Convert.ToSingle(Math.Asin(p3.Y)) / (Convert.ToSingle(Math.PI));
                        GL.TexCoord2(p);
                    }
                    else

                    {
                        GL.Color3(Color);
                    }
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
