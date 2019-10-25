using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTKTut.Shapes; 
namespace OpenTKTut
{
    partial class SceenEngine
    {
        private List<OGLShape> _drawingList;
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

            GL.Enable(EnableCap.Texture2D);
        }

        private void _window_Resize(object sender, EventArgs e)
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
        }

        private void _window_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            for(int i=0;i<_drawingList.Count;i++)
            {
                _drawingList[i].Draw();
            }
            
            _window.SwapBuffers();
        }
    }
}
