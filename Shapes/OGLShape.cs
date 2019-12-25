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
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{
    class OGLShape
    {
        private int selfSpeed = 1;
        public bool EnableAutoRotate { get; set; }
        public Vector3 planet { get; set; }
        public bool RotateAroundPlanet { get; set; }
        public Vector3 RotateAround { get; set; }
        public bool IsAnchor = true;
        public Vector3 RotationVector = Vector3.UnitY;
        public Vector3 Center { get; set; }
        public float speed = 1;
        public MeshElement[] MeshPolygons { get; set; }
        public bool SelfRotation { get; set; }

        public OGLShape(Vector3 center)
        {
            RotateAround = center;

        }

        protected float _rotateAngle;

        public virtual void Draw()
        {
            GL.PushMatrix();
            GL.Translate(Center.X, Center.Y, -Center.Z);

            if (EnableAutoRotate)
            {
                Rotate(Center, RotateAround, speed);
                if (RotateAroundPlanet)
                {
                    Rotate(Center, planet, speed);
                }
            }

            if (SelfRotation)
            {
                GL.Rotate(_rotateAngle, RotationVector);
                _rotateAngle = _rotateAngle < 360 ? _rotateAngle + (speed < 10 ? speed : 1) : _rotateAngle - 360;

            }


            ShapeDrawing();
            GL.PopMatrix();
        }

        protected virtual void ShapeDrawing()
        {
            // Add any common drawing for all shapes in this part
        }

        private void Rotate(Vector3 center, Vector3 Around, float s)
        {
            //1- Translate to the origin [reverse the previous translation]
            GL.Translate(-center.X, -center.Y, center.Z);
            //2- Translate to the new center
            GL.Translate(Around.X,
                         Around.Y,
                         -Around.Z);
            //rotate in the new axes 
            GL.Rotate(_rotateAngle, RotationVector);
            // this (speed < 10 ? speed : 1) is there because for speeds 
            // more than 10 my machine faced a wierd glitches
            _rotateAngle = _rotateAngle < 360 ? _rotateAngle + (s < 10 ? s : 1) : _rotateAngle - 360;

            /////////////// reverse //////////////////
            //2- Translate to the new center
            GL.Translate(-Around.X,
                         -Around.Y,
                         Around.Z);
            //1-reverse translation
            GL.Translate(center.X, center.Y, -center.Z);
        }

    }
}
