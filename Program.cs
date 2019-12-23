/*H**********************************************************************
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




            //Shapes.Cube cube = new Shapes.Cube(new Vector3(0.0f, 20.0f, 80.0f), 5, true);
            //sceenEngine.AddShape(cube);

            //cube = new Shapes.Cube(new Vector3(-10.0f, -7.0f, 35.0f), 5.0f, true);
            //sceenEngine.AddShape(cube);

            //cube = new Shapes.Cube(new Vector3(10.0f, -10.0f, 60.0f), 3.0f, true);
            //sceenEngine.AddShape(cube);

            //cube = new Shapes.Cube(new Vector3(10.0f, -10.0f, 40.0f), 3.0f, true);
            //sceenEngine.AddShape(cube);

            Shapes.Sphere sp = new Shapes.Sphere(new Vector3( 0.0f,0.0f,50.0f), 5, true);
            //sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(-10.0f, 20.0f, 80.0f), 5, true);
            // sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(5.0f, -5.0f, 30.0f), 1, false);
            // sceenEngine.AddShape(sp);
            sp = new Shapes.Sphere(new Vector3(00.0f, 20.0f, 90.0f), 1, new Vector3(0.0f, 20.0f, 80.0f), true, true);
            // sceenEngine.AddShape(sp);
            sp = new Shapes.Sphere(new Vector3(020.0f, 10.0f, 80.0f), 2, new Vector3(0.0f, 0.0f, 80.0f),new Vector3(0,0,0), true,true);
        
            sp.speed_sun = 1;
            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(22.0f, 13.0f, 80.0f), 1, new Vector3(0.0f, 0.0f, 80.0f), new Vector3(0, 0, 0), true, true);

            sp.speed_sun = 1;
            sp.speed_plant = 5;
            sp.Center_rotate_plant=(new Vector3(20.0f, 10.0f, 80.0f));
            sp.angle_rotate_far_center_plant=(new Vector3(30, 45, 70));
            sp.EnableAutoRotate_at_other_place_plant = true;
            sp.Color = new float[3];
            sp.Color[0] = 1.00f;
            sp.Color[1] = 0.00f;
            sp.Color[2] = 0.00f;
            sceenEngine.AddShape(sp);




            sp = new Shapes.Sphere(new Vector3(020.0f, -10.0f, 80.0f), 2, new Vector3(0.0f, 0.0f, 80.0f), new Vector3(-45, 0, 0), true, true);

            sp.speed_sun = 1;

            sceenEngine.AddShape(sp);
            sp.Color = new float[3];
            sp.Color[0] = 0.50f;
            sp.Color[1] = 0.50f;
            sp.Color[2] = 1.00f;

            sp = new Shapes.Sphere(new Vector3(015.0f, -10.0f, 80.0f), 1, new Vector3(0.0f, 0.0f, 80.0f), new Vector3(-45, 0, 0), true, true);

            sp.speed_sun = 1;
            sp.speed_plant = 2;
            sp.Center_rotate_plant = (new Vector3(20.0f, -10.0f, 80.0f));
            sp.EnableAutoRotate_at_other_place_plant = true;
            sp.Color = new float[3];
            sp.Color[0] = 1.00f;
            sp.Color[1] = 0.50f;
            sp.Color[2] = 1.00f;
            sceenEngine.AddShape(sp);


            sp = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 80.0f), 4, new Vector3(0.0f, 0.0f, 0), new Vector3(0, 0, 0), true, true);


            sp.Color = new float[3];
            sp.Color[0] = 0.90f;
            sp.Color[1] = 0.7f;
            sp.Color[2] = 0.00f;


            sceenEngine.AddShape(sp);

            sp = new Shapes.Sphere(new Vector3(020.0f, 20.0f, 80.0f), 2, new Vector3(0.0f, 0.0f, 80.0f), new Vector3(0, 0, 0), true, true);

            sp.speed_sun = 1;

            sceenEngine.AddShape(sp);
            sp.Color = new float[3];
            sp.Color[0] = 1.00f;
            sp.Color[1] = 0.250f;
            sp.Color[2] = 1.00f;

            sp = new Shapes.Sphere(new Vector3(015.0f, 20.0f, 80.0f), 1, new Vector3(0.0f, 0.0f, 80.0f), new Vector3(0, 0, 0), true, true);

            sp.speed_sun = 1;
            sp.speed_plant = 2;
            sp.Center_rotate_plant = (new Vector3(20.0f, 20.0f, 80.0f));
            sp.angle_rotate_far_center_plant = new Vector3(90, 0, 0);
            sp.EnableAutoRotate_at_other_place_plant = true;
            sp.Color = new float[3];
            sp.Color[0] = 0.00f;
            sp.Color[1] = 0.50f;
            sp.Color[2] = 0.00f;
            sceenEngine.AddShape(sp);

            sceenEngine.Start();
            
            //sceenEngine.AddShape()
        }
    }
}
