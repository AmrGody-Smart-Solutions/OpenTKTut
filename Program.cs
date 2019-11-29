﻿/*H**********************************************************************
* FILENAME :        Program.cs             DESIGN REF: OGLTUT05
*
* DESCRIPTION :
*       starting code.
*
* PUBLIC FUNCTIONS :
*       
*       void Main(string[] args)
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
namespace OpenTKTut
{
    class Program
    {
        static void Main(string[] args)
        {
            SceenEngine sceenEngine = new SceenEngine();




            Shapes.Cube cube = new Shapes.Cube(new Vector3(0.0f, 20.0f, 80.0f), 5, true);
            sceenEngine.AddShape(cube);

            cube = new Shapes.Cube(new Vector3(-10.0f, -7.0f, 35.0f), 5.0f, true);
            sceenEngine.AddShape(cube);

            cube = new Shapes.Cube(new Vector3(10.0f, -10.0f, 60.0f), 3.0f, true);
            sceenEngine.AddShape(cube);

            cube = new Shapes.Cube(new Vector3(10.0f, -10.0f, 40.0f), 3.0f, true);
            sceenEngine.AddShape(cube);

            Shapes.Sphere sp = new Shapes.Sphere(new Vector3( 0.0f,0.0f,50.0f), 5, true);
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(-20.0f, 20.0f, 80.0f), 5, true);
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(5.0f, -5.0f, 30.0f), 1, false);
            sceenEngine.AddShape(sp);
            sp = new Shapes.Sphere(new Vector3(00.0f, 20.0f, 90.0f), 1, new Vector3(0.0f, 20.0f, 80.0f), true, true);
            sceenEngine.AddShape(sp);
            sp = new Shapes.Sphere(new Vector3(00.0f, 20.0f, 90.0f), 1, new Vector3(0.0f, 20.0f, 80.0f),new Vector3(-45,45,0), true, true);
            sp.Color[0] = 0;
            sp.Color[1] = 1.0f;
            sp.Color[0] = 0;

            sceenEngine.AddShape(sp);

            sceenEngine.Start();
            
            //sceenEngine.AddShape()
        }
    }
}
