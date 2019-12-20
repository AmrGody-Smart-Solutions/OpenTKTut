/*H**********************************************************************
* FILENAME :        MeshElement_Statics.cs             DESIGN REF: OGLTUT01
*
* DESCRIPTION :
*       Mesh object base functions of all shapes.
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
    partial class MeshElement
    {
        private static  double _converter_factor = Math.PI / 180;
        public static MeshElement[] Sphere(double radius)
        {
            List<MeshElement> res = new List<MeshElement>();
            
            int dlta = 10;
            double delta = Convert.ToDouble(dlta) * _converter_factor;
            for (int theta = 0;theta<=180-dlta;theta += dlta )
            {
                for (int phi = 0; phi <= 360 - dlta; phi += dlta)
                {


                    // 1 ===== 4
                    // |       |
                    // 2 ===== 3

                    Vector3 _1 = GetCartezianOf(radius, theta, phi);
                    Vector3 _2 = GetCartezianOf(radius, theta + dlta, phi);
                    Vector3 _3 = GetCartezianOf(radius, theta + dlta, phi + dlta);
                    Vector3 _4 = GetCartezianOf(radius, theta, phi + dlta);
                    Vector3 normal = theta == 0 ? Vector3.UnitZ : theta == 180 ? -Vector3.UnitZ : GetNormal(_1, _2, _4);
                    //Vector3 normal = GetNormal(_1, _2, _4);
                    Vector3[] vertices = { _1, _2, _3, _4 };
                    res.Add(new MeshElement(4, normal, vertices));

                }
            }


            return res.ToArray();
        }

        public static MeshElement[] Cube(float len)
        {
            // 1 ===== 4
            // |       |
            // 2 ===== 3


              /*  
             *  
             *    5 -- - - - 8
             *  / |        / |
             * 1 - - - - 4   |
             * |  |      |   |
             * |  6 - -- | - 7
             * |/        | /  
             * 2 - - - - 3
             * 
             */
            List<MeshElement> res = new List<MeshElement>();

           //front 
            Vector3 _1 =new Vector3(-len / 2, len / 2, len / 2);
            Vector3 _2 =new Vector3(-len / 2, -len / 2, len / 2);
            Vector3 _3 =new Vector3(len / 2, -len / 2, len / 2);
            Vector3 _4 =new Vector3(len / 2, len / 2, len / 2);
            //rear
            Vector3 _5 =new Vector3(-len / 2, len / 2, -len / 2);
            Vector3 _6 =new Vector3(-len / 2, -len / 2, -len / 2);
            Vector3 _7 =new Vector3(len / 2, -len / 2, -len / 2);
            Vector3 _8 =new Vector3(len / 2, len / 2, -len / 2);
            
            Vector3[] vertices_front = { _1, _2, _3, _4 };
            Vector3 normal_front1234 = GetNormal(_1, _2, _3);

            Vector3[] vertices_rear = { _5, _8, _7, _6 };
            Vector3 normal_rear5876 = GetNormal(_5, _8, _7);

            Vector3[] vertices_right = { _1, _5, _6, _2 };
            Vector3 normal_right1562 = GetNormal(_1, _5, _6);

            Vector3[] vertices_left = { _3, _7, _8, _4 };
            Vector3 normal_left3784 = GetNormal(_3, _7, _8);

            Vector3[] vertices_down = { _2, _6, _7, _3 };
            Vector3 normal_down2673 = GetNormal(_2, _6, _7);

            Vector3[] vertices_up = { _1, _4, _8, _5 };
            Vector3 normal_up1485 = GetNormal(_1, _4, _8);

            Vector3[] points_normals(int[] vertixs, Vector3[][] normal){
            /*get normal for every vertex in polygon
            arguments:
            int[] vertixs : vertix number as indexed at normals array
            Vector3[][] normal : 2d array every row contains the normals of polygon
                                this vertix is part of

            out:
            Vector3[] : array of normal with same order as vertixs
            */ 
                Vector3[] points_normal = new Vector3[4];
                for (int i = 0;i < vertixs.Length;i++){
                    points_normal[i]=AvgNormal(normal[vertixs[i]-1]);
                }
                return points_normal;
            }

            Vector3[][] normals = {
                new Vector3[] {normal_front1234,normal_up1485,normal_right1562},
                new Vector3[] {normal_front1234,normal_right1562,normal_down2673},
                new Vector3[] {normal_front1234,normal_left3784,normal_down2673},
                new Vector3[] {normal_front1234,normal_left3784,normal_up1485},
                new Vector3[] {normal_rear5876,normal_right1562,normal_up1485},
                new Vector3[] {normal_rear5876,normal_right1562,normal_down2673},
                new Vector3[] {normal_rear5876,normal_left3784,normal_down2673},
                new Vector3[] {normal_rear5876,normal_left3784,normal_up1485},
            };

            Vector3[] normals_front = points_normals(new int[] {1,2,3,4},normals);
            Vector3[] normals_rear  = points_normals(new int[] {5,8,7,6},normals);
            Vector3[] normals_right = points_normals(new int[] {1,5,6,2},normals);
            Vector3[] normals_left  = points_normals(new int[] {3,7,8,4},normals);
            Vector3[] normals_down  = points_normals(new int[] {2,6,7,3},normals);
            Vector3[] normals_up    = points_normals(new int[] {1,4,8,5},normals);

            res.Add(new MeshElement(4, normals_front, vertices_front));
            res.Add(new MeshElement(4, normals_rear, vertices_rear));
            res.Add(new MeshElement(4, normals_right, vertices_right));
            res.Add(new MeshElement(4, normals_left, vertices_left));
            res.Add(new MeshElement(4, normals_down, vertices_down));
            res.Add(new MeshElement(4, normals_up, vertices_up));

            //res.Add(new MeshElement(4, normal_front1234, vertices_front ));
            //res.Add(new MeshElement(4, normal_rear5876, vertices_rear));
            //res.Add(new MeshElement(4, normal_right1562, vertices_right));
            //res.Add(new MeshElement(4, normal_left3784, vertices_left));
            //res.Add(new MeshElement(4, normal_down2673, vertices_down));
            //res.Add(new MeshElement(4, normal_up1485, vertices_up));



            return res.ToArray();
        }
        private static Vector3 AvgNormal(Vector3[] normals){
            var sum = new Vector3();
            for (int i = 0; i < normals.Length;i++){
                sum += normals[i];
            }
            var avg_norm = sum / normals.Length;
            return avg_norm.Normalized();
        }

        private static Vector3 GetNormal(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Vector3 res = new Vector3();
            //    b
            // 1 ---> 3
            // |a
            // 7
            // 2
            var _p1 = new  Vector3d(p1.X, p1.Y, p1.Z);
            var _p2 = new Vector3d(p2.X, p2.Y, p2.Z);
            var _p3 = new Vector3d(p3.X, p3.Y, p3.Z);
            Vector3d a = _p2 - _p1;
            Vector3d b = _p3 - _p1;
            var temp = Vector3d.Cross(a, b);
            temp.Normalize();
            res.X = Convert.ToSingle( temp.X);
            res.Y = Convert.ToSingle(temp.Y);
            res.Z = Convert.ToSingle(temp.Z);

            return res;
        }

        private static Vector3 GetCartezianOf(double radius, int theta, int phi)
        {
            double th = Convert.ToDouble(theta) * _converter_factor;
            double ph = Convert.ToDouble(phi) * _converter_factor;
            float x = Convert.ToSingle(radius * Math.Sin(th) * Math.Cos(ph));
            float y = Convert.ToSingle(radius * Math.Sin(th) * Math.Sin(ph));
            float z = Convert.ToSingle(radius * Math.Cos(th));
            Vector3 _1 = new Vector3(x, y, z);
            return _1;
        }
    }
}
