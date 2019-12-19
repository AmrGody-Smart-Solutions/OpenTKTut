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
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTKTut.Shapes;
namespace OpenTKTut
{
    partial class SceenEngine
    {
        private List<OGLShape> _drawingList;
        float angle = 50.0f;
        private void InitializeObjects()
        {
            _drawingList = new List<OGLShape>();
        }

        private void SetEvents()
        {
            _window.RenderFrame += _window_RenderFrame;
            _window.Resize += _window_Resize;
            _window.Load += _window_Load;
        }

        private void _window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            //Lights
            GL.Enable(EnableCap.Lighting);

            GL.Enable(EnableCap.ColorMaterial);

            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 0.0f, 10.0f,15f});
            GL.Light(LightName.Light0, LightParameter.SpotDirection, new float[] { 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 10.0f, 0.0f, 0.0f});
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.1f, 0.05f, 0.015f });
            GL.Enable(EnableCap.Light0);

            GL.ShadeModel(ShadingModel.Smooth);

            GL.Enable(EnableCap.Texture2D);
        }

        private void _window_Resize(object sender, EventArgs e)
        {

            GL.Viewport(0, 0, _window.Width, _window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 prespective = Matrix4.CreatePerspectiveFieldOfView(50.0f * 3.14f / 180.0f, _window.Width / _window.Height, 1.0f, 100.0f);

            GL.LoadMatrix(ref prespective);
            GL.MatrixMode(MatrixMode.Modelview);
        }


        KeyboardState lastKeyPressed;
        private void _window_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            for (int i = 0; i < _drawingList.Count; i++)
            {
                _drawingList[i].Draw();
            }

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Key.Escape))
            {
                _window.Exit();
            }

            if (state.IsKeyDown(Key.R) && lastKeyPressed.IsKeyUp(Key.R))
            {
                
                Random rand = new Random();
                Sphere randomSphere = new Sphere(new Vector3(rand.Next(0, 20), rand.Next(0, 5), rand.Next(50, 60)),
                                                 rand.Next(1, 4), true, new float[] {rand.Next(0,10)/10f,
                                                                                  rand.Next(0,10)/10f,
                                                                                  rand.Next(0,10)/10f}) { 
                RotateAround = new Vector3(0.0f,0.0f,0.50f),
                RotationVector = rand.Next(0, 2) * Vector3.UnitY + rand.Next(0, 2) * Vector3.UnitZ  
                };
                AddShape(randomSphere);
            }
            lastKeyPressed = state;
            _window.SwapBuffers();
        }
    }
}
