/*H**********************************************************************
* FILENAME :        OGLShape.cs             DESIGN REF: OGLTUT04
*
* DESCRIPTION :
*       OGLShape object base functions of all shapes.
*
* PUBLIC FUNCTIONS :
*       void     Draw()
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
    class OGLShape
    {
        public bool EnableAutoRotate { get; set; }
        public bool Orbiting, Moon;
        public float RotatingSpeed;
        public Vector3 _Center;
        public float Rotatingradius;
        public float OrbitingSpeed;
        public float MoonOrbit;
        public float MoonSpeed;

        public MeshElement[] MeshPolygons { get => meshPolygons; set => meshPolygons = value; }

        public float _rotateAngle;
        public float _orbitAngle;
        public float _moonAngle;
        public float x1, z1, x2, y2, z2;
        private MeshElement[] meshPolygons;

        public virtual void Draw()
        {
            
            GL.PushMatrix();
            GL.Translate(_Center.X, _Center.Y, -_Center.Z);
            

            if (EnableAutoRotate)
                {
                
                //GL.Rotate(90, Vector3.UnitZ);
                GL.Rotate(_rotateAngle, Vector3.UnitY);
                _rotateAngle = _rotateAngle < 360 ? _rotateAngle + RotatingSpeed : _rotateAngle - 360;


                if (Orbiting)
                {
                    _Center.X -= x1;
                    _Center.Z -= z1;
                    x1 = Rotatingradius * (float)Math.Cos(_orbitAngle * Math.PI / 180);
                    z1 = Rotatingradius * (float)Math.Sin(_orbitAngle * Math.PI / 180);
                    _Center.X += x1;
                    _Center.Z += z1;
                    _orbitAngle = _orbitAngle < 360 ? _orbitAngle + OrbitingSpeed : _orbitAngle - 360;

                    if (Moon)
                    {
                        _Center.X -= x2;
                        _Center.Y -= y2;
                        _Center.Z -= z2;
                        x2 = MoonOrbit * (float)Math.Cos(_moonAngle * Math.PI / 180);
                        y2 = MoonOrbit * (float)Math.Cos(_moonAngle * Math.PI / 180);
                        z2 = MoonOrbit * (float)Math.Sin(_moonAngle * Math.PI / 180);
                        _Center.X += x2;
                        _Center.Y += y2;
                        _Center.Z += z2;
                        _moonAngle = _moonAngle < 360 ? _moonAngle + MoonSpeed : _moonAngle - 360;
                    }
                }

            }
            
            ShapeDrawing();
            GL.PopMatrix();
        }

        protected virtual void ShapeDrawing()
        {
            //Add any common drawing for all shapes in this part
        }


    }
}
