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
using System.Drawing;
namespace OpenTKTut.Shapes
{
    public class OGLShape
    {
        public OGLShape(){}
        public bool EnableAutoRotate { get; set; }
        public bool EnableMasterRotate { get; set; }

        public Vector3 Color_ {get; set;}
        public Color Color_sys {get; set;}
        public OGLShape Master { get; set; }
        public Vector3 Center { get; set; }
        
        public MeshElement[] MeshPolygons { get => meshPolygons; set => meshPolygons = value; }

        // self rotating
        protected float _rotateAngle {get; set;}
        protected float rotation_speed{get; set;}
        protected Vector3 rotationAxis { get; set; }

        // rotating angle around master
        protected float _rotateAngle_master {get; set;}
        protected float rotation_speed_master{get; set;}
        protected  Vector3 rotationAxisMaster{get; set;}

        private MeshElement[] meshPolygons;

        public int Tex_index { get; set; }
        public virtual void Draw()
        {
            void recursiveRotate(OGLShape shape=null, OGLShape shape_slave = null)
            {
            // rotate starting from top master to lowest
            // if there is master go deeper
            // else do rotation 
                if (shape.Master != null)
                {
                    recursiveRotate(shape.Master, shape);
                }
                Rotate(shape_slave, shape, shape_slave.rotation_speed_master, shape_slave.rotationAxisMaster);
            }

            void Rotate(OGLShape shape, OGLShape rotateMaster, float speed, Vector3 axis){

                GL.Translate(rotateMaster.Center.X, rotateMaster.Center.Y, -rotateMaster.Center.Z);
                
                float angle = 0;
                if (rotateMaster == this)
                {
                    angle = shape._rotateAngle;
                    shape._rotateAngle = shape._rotateAngle < 360 ? shape._rotateAngle + shape.rotation_speed : shape._rotateAngle - 360;
                }
                else
                {
                    angle = shape._rotateAngle_master;
                    if (shape == this)
                    {
                        shape._rotateAngle_master = shape._rotateAngle_master < 360 ? shape._rotateAngle_master + shape.rotation_speed_master : shape._rotateAngle_master - 360;
                    }
                }

                GL.Rotate(angle, axis);
                GL.Translate(-rotateMaster.Center.X, -rotateMaster.Center.Y, rotateMaster.Center.Z);

            }

            GL.PushMatrix();

            if (this.Master != null)
                recursiveRotate(this.Master, this);


            if (EnableAutoRotate)
            {
                Vector3 axis = this.rotationAxis;
                float speed = this.rotation_speed;
                Rotate(this,this, speed, axis);
            }

            GL.Translate(Center.X, Center.Y, -Center.Z);
            ShapeDrawing();
            // get model_matrix
            // multiply center by it 
            // save point 
            // darw last 100 points
            GL.PopMatrix();
        }
        public virtual void Rotate(OGLShape rotateMaster = null,float distance =0, float speed = 1, Vector3 axis = default(Vector3)){
            if (axis == default(Vector3)){
                axis = new Vector3(1f, 1f, 0f);
            }
            
            if (rotateMaster == null | rotateMaster == this)
            {
                this.EnableAutoRotate = true;                
                this.rotation_speed = speed;
                this.rotationAxis = axis;
            }
            else{
                this.Master = rotateMaster;
                this.rotation_speed_master = speed;
                this.rotationAxisMaster = axis;
                if (distance > 0)
                {
                    this.Center = reotation_point(Master.Center, axis, distance);
                }
            }

            Vector3 reotation_point(Vector3 master_center, Vector3 norm, float raduis)
            {
                // assume passing x-axis
                // X^2+y^2+z^2 = distance^2
                // norm.x(X)+norm.y(Y)+norm.z(Z)= constant
                // put x = 0
                if (norm == Vector3.UnitZ)
                {
                    return master_center + (Vector3.UnitX * raduis);
                }
                else if (norm == new Vector3(1f, 1f, 0))
                {
                    return master_center + (Vector3.UnitZ * raduis);
                }
                else
                {
                    return this.Center;

                }
            }

        }

        protected virtual void ShapeDrawing()
        {
            //Add any common drawing for all shapes in this part
        }


    }
}
