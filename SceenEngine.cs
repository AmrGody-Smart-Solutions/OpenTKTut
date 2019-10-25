using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut
{
    partial class SceenEngine
    {
        GameWindow _window { get; set; }
        public SceenEngine()
        {
            _window = new GameWindow(800, 600);
            InitializeObjects();
            SetEvents();
            

        }
        public void Start()
        {
            _window.Run();
        }
        public void AddShape(Shapes.OGLShape oGLShape)
        {
            _drawingList.Add(oGLShape);
        }
    }
}
