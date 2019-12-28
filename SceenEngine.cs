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
using OpenTK.Input;
using System.Drawing.Imaging;

namespace OpenTKTut
{
    partial class SceenEngine
    {
        GameWindow _window { get; set; }
        public SceenEngine(BitmapData TexData1, BitmapData TexData2, BitmapData TexData3, BitmapData TexData4, BitmapData TexData5)
        {
            _window = new GameWindow(800, 600);
            InitializeObjects();
            SetEvents();
            texData1 = TexData1;
            texData2 = TexData2;
            texData3 = TexData3;
            texData4 = TexData4;
            texData5 = TexData5;

            //calculate star positions
            for (int i = 0; i < 800; i++)
            {

                starposition[i].X = R1.Next(-60,60);
                starposition[i].Y = R2.Next(-80,80); ;
                starposition[i].Z = -60;
            }
        }

        public BitmapData texData1;
        public BitmapData texData2;
        public BitmapData texData3;
        public BitmapData texData4;
        public BitmapData texData5;

        

        Random R1 = new Random(4);
        Random R2 = new Random(19);

        public Vector3[] starposition = new Vector3[800];

        public void Start()
        {
            _window.Run(30.0);
        }
        public void AddShape(Shapes.OGLShape oGLShape)
        {
            _drawingList.Add(oGLShape);
        }

        
    }
}
