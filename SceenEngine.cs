/*H**********************************************************************
* FILENAME :        SceenEngine.cs             DESIGN REF: OGLTUT05
*
* DESCRIPTION :
*       OPENTK sceen engine
*
* PUBLIC FUNCTIONS :
*       
*        public void Start()
*        public void AddShape(Shapes.OGLShape oGLShape)
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
namespace OpenTKTut
{
    partial class SceenEngine
    {
        GameWindow _window { get; set; }
        public MyView v;
        public SceenEngine()
        {
            _window = new GameWindow(800, 600);
           v = new MyView(Vector2.Zero);
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
