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
        public bool EnableAutoRotate { get; set; }
        public Vector3 RotateAround { get; set; }
        public bool IsAnchor = true;
        public Vector3 RotationVector = Vector3.UnitY;
        public Vector3 Center { get; set; }
        public int speed = 1;
        public MeshElement[] MeshPolygons { get => meshPolygons; set => meshPolygons = value; }

        public OGLShape(Vector3 center)
        {
            RotateAround = center;
        }

        protected float _rotateAngle;
        private MeshElement[] meshPolygons;

        public virtual void Draw()
        {
            GL.PushMatrix();
            GL.Translate(Center.X, Center.Y, -Center.Z);

            if (EnableAutoRotate)
            {
                /////////////remove the following comment
                /*if (IsAnchor)
                {
                        GL.Rotate(_rotateAngle, RotationVector);
                        _rotateAngle = _rotateAngle < 360 ? _rotateAngle + (speed < 10 ? speed : 1) : _rotateAngle - 360;
                }

                else
                {
                */

                //1- Translate to the origin [reverse the previous translation]
                GL.Translate(-Center.X, -Center.Y, Center.Z);
                //2- Translate to the new center
                GL.Translate(RotateAround.X,
                             RotateAround.Y,
                             -RotateAround.Z);
                //rotate in the new axes 
                GL.Rotate(_rotateAngle, RotationVector);
                // this (speed < 10 ? speed : 1) is there because for speeds 
                // more than 10 my machine faced a wierd glitches
                _rotateAngle = _rotateAngle < 360 ? _rotateAngle + (speed < 10 ? speed : 1) : _rotateAngle - 360;
                /////////////// reverse //////////////////
                //2- Translate to the new center
                GL.Translate(-RotateAround.X,
                             -RotateAround.Y,
                             RotateAround.Z);
                //1-reverse translation
                GL.Translate(Center.X, Center.Y, -Center.Z);

                //////////////and remove this comment one too
                // }
            }

            ShapeDrawing();
            GL.PopMatrix();
        }

        protected virtual void ShapeDrawing()
        {
            // Add any common drawing for all shapes in this part
        }


    }
}
