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
using System.Drawing;
using System.Drawing.Imaging;
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
        public bool EnableAutoRotate_at_other_place_sun { get; set; }
        public bool EnableAutoRotate_at_other_place_plant { get; set; }

        public Vector3 Center { get; set; }
        public Vector3 Center_rotate_sun { get; set; }
        public Vector3 Center_rotate_plant { get; set; }
        public Vector3 angle_rotate_far_center_sun { get; set; }
        public Vector3 angle_rotate_far_center_plant { get; set; }
        public float speed_plant{ get; set; }


        public float[ ] Color { get; set; }


        public float speed_sun;
       // public float speed_plant;
        public MeshElement[] MeshPolygons { get => meshPolygons; set => meshPolygons = value; }

        protected float _rotateAngle;
        protected float _rotateAngle_other_place_plant;
        protected float _rotateAngle_other_place_sun;

        private MeshElement[] meshPolygons;

        public virtual void Draw()
        {
            GL.PushMatrix();
            // GL.Color3(Color[0],Color[1],Color[2]  );


            if (EnableAutoRotate_at_other_place_sun)
            {
                GL.Translate(Center_rotate_sun.X, Center_rotate_sun.Y, -Center_rotate_sun.Z);
                //GL.Rotate(90, Vector3.UnitX);
                GL.Rotate(angle_rotate_far_center_sun.X, Vector3.UnitX);
                GL.Rotate(angle_rotate_far_center_sun.Z, Vector3.UnitZ);
                GL.Rotate(angle_rotate_far_center_sun.Y, Vector3.UnitY);
                //rotate object around axis
                GL.Rotate(_rotateAngle_other_place_sun, Vector3.UnitZ);
                GL.Rotate(-angle_rotate_far_center_sun.Y, Vector3.UnitY);
                GL.Rotate(-angle_rotate_far_center_sun.Z, Vector3.UnitZ);
                GL.Rotate(-angle_rotate_far_center_sun.X, Vector3.UnitX);

                GL.Translate(-Center_rotate_sun.X, -Center_rotate_sun.Y, Center_rotate_sun.Z);
                _rotateAngle_other_place_sun  = _rotateAngle_other_place_sun  <= 360 ? _rotateAngle_other_place_sun + 1*speed_sun : _rotateAngle_other_place_sun - 360;
            }

            if (EnableAutoRotate_at_other_place_plant)
            {
                GL.Translate(Center_rotate_plant.X, Center_rotate_plant.Y, -Center_rotate_plant.Z);
                //GL.Rotate(90, Vector3.UnitX);
                //rotate axis to Y
                GL.Rotate(angle_rotate_far_center_plant.X, Vector3.UnitX);
                GL.Rotate(angle_rotate_far_center_plant.Z, Vector3.UnitZ);
                GL.Rotate(angle_rotate_far_center_plant.Y, Vector3.UnitY);
                //rotate object around axis
                GL.Rotate(_rotateAngle_other_place_plant*2, Vector3.UnitZ);
                GL.Rotate(-angle_rotate_far_center_plant.Y, Vector3.UnitY);
                GL.Rotate(-angle_rotate_far_center_plant.Z, Vector3.UnitZ);
                GL.Rotate(-angle_rotate_far_center_plant.X, Vector3.UnitX);
                GL.Translate(-Center_rotate_plant.X, -Center_rotate_plant.Y, Center_rotate_plant.Z);
                _rotateAngle_other_place_plant = _rotateAngle_other_place_plant <= 360 ? _rotateAngle_other_place_plant + 1 * speed_plant : _rotateAngle_other_place_plant - 360;
            }

            GL.Translate(Center.X, Center.Y, -Center.Z);

            if (EnableAutoRotate)
                {
                //     GL.Translate(Center.X, Center.Y, Center.Z);
                GL.Rotate(_rotateAngle, Vector3.UnitY);
                //  GL.Rotate(_rotateAngle, Vector3.UnitY);
                    _rotateAngle = _rotateAngle < 360 ? _rotateAngle + 1 : _rotateAngle - 360;
                }
            
            ShapeDrawing();
            GL.PopMatrix();
        }
        public void tex_load(String path)
        {
            tex_id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, tex_id);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToBorder);
            Bitmap bitmap = new Bitmap(path);
            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data); GL.Enable(EnableCap.Texture2D);

        }
        public int tex_id { get; private set; }
        public bool tex_enable { get; set; }


        protected virtual void ShapeDrawing()
        {
            //Add any common drawing for all shapes in this part
        }


    }
}
