/*H**********************************************************************
* FILENAME :        SceenEngine_Private.cs             DESIGN REF: OGLTUT05
*
* DESCRIPTION :
*       SceenEngine_Private
*
* PUBLIC FUNCTIONS :
*       
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
using OpenTK.Input;
using OpenTKTut.Shapes;
using System.Drawing.Imaging;

namespace OpenTKTut
{
    partial class SceenEngine
    {
        private List<OGLShape> _drawingList;
        public Key _keyPressed;
        int  texture1, texture2, texture3, texture4, texture5;

        
        private void InitializeObjects()
        {
            _drawingList = new List<OGLShape>();
        }
        
        private void SetEvents()
        {
            _window.RenderFrame += _window_RenderFrame;
            _window.Resize += _window_Resize;
            _window.Load += _window_Load;
            _window.KeyDown += _window_KeyDown;
            _window.UpdateFrame += _window_UpdateFrame;


        }

        private void _window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            //Lights

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 20.0f, 0.0f,40.0f });
            //GL.Light(LightName.Light0, LightParameter.Diffuse,new float[] { 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 1.0f, 0.0f, 0.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.75f, 0.75f, 0.75f });
            GL.Enable(EnableCap.Light0);
            //GL.ShadeModel(ShadingModel.Smooth);
            
            //Textures
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1, out texture1);
            GL.GenTextures(1, out texture2);
            GL.GenTextures(1, out texture3);
            GL.GenTextures(1, out texture4);
            GL.GenTextures(1, out texture5);
            
            GL.BindTexture(TextureTarget.Texture2D, 1);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData1.Width, texData1.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData1.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 2);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData2.Width, texData2.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData2.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData3.Width, texData3.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData3.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 4);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData4.Width, texData4.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData4.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 5);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData5.Width, texData5.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData5.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        private void _window_Resize(object sender, EventArgs e)
        {
            if (_window.Height != 0)//this would cause a DivideByZeroException if I minimize openTK Game Window
            { 
            GL.Viewport(0, 0, _window.Width, _window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //GL.Ortho(0, 100, 0, 100, -1, 1);
            //GL.Frustum(0, 100, 0, 100, 1, 100);
            Matrix4 prespective = Matrix4.CreatePerspectiveFieldOfView(45.0f * 3.14f / 180.0f, _window.Width / _window.Height, 1.0f, 100.0f);

            // Matrix4 prespective = Matrix4.CreatePerspectiveOffCenter(-150.0f, 150.0f, -150.0f, 150.0f, 1.0f, 100.0f);
            GL.LoadMatrix(ref prespective);
            GL.MatrixMode(MatrixMode.Modelview);
             MoveModelDown(5);
            }
        }

        private void _window_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Draw Stars
            GL.PointSize(2);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(1.0f, 1.0f, 1.0f);
            foreach (var item in starposition)
            {
                GL.Vertex3(item.X, item.Y, item.Z);
            }
            GL.End();

            for (int i=0;i<_drawingList.Count;i++)
            {
                _drawingList[i].Draw();
            }
            
            _window.SwapBuffers();
        }


        private void _window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            
            _keyPressed = e.Key;
        }


        private void _window_UpdateFrame(object sender, FrameEventArgs e)
        {
            

            switch (_keyPressed)
            {
                case Key.Right:
                    MoveModelLeft(1);
                    break;
                case Key.Left:
                    MoveModelRight(1);
                    break;
                case Key.Down:
                    MoveTheModeltome(1);
                    break;
                case Key.Up:
                    MoveTheModelAway(1);
                    break;
                case Key.W:
                    MoveModelDown(1);
                    break;
                case Key.S:
                    MoveModelUp(1);
                    break;
                case Key.AltLeft:
                    RotateModelRight(1);
                    break;
                case Key.AltRight:
                    RotateModelLeft(1);
                    break;
                case Key.ControlLeft:
                    RotateModelDown(1);
                    break;
                case Key.ControlRight:
                    RotateModelUp(1);
                    break;

            }
        }

        public void RotateModelRight(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, -Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RotateModelLeft(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RotateModelUp(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, -Vector3.UnitX);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RotateModelDown(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, Vector3.UnitX);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveTheModelAway(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(Vector3.UnitZ * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveTheModeltome(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(-Vector3.UnitZ * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveModelRight(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(Vector3.UnitX * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveModelLeft(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(-Vector3.UnitX * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }


        public void MoveModelUp(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(Vector3.UnitY * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveModelDown(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(-Vector3.UnitY * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        
    }
}
