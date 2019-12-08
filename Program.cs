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
using OpenTKTut.Shapes;
using System.Drawing;
namespace OpenTKTut
{
    class Program
    {
        static void Main(string[] args)
        {
            SceenEngine sceenEngine = new SceenEngine();


            float sun_size = 4f;
            Sphere sun = new Sphere(new Vector3(0f, 0f, 80f), sun_size, color:Colors.yellow_light);
            sun.Rotate();  // rotating around itself
            sceenEngine.AddShape(sun);



            Sphere mercury = new Sphere(default(Vector3), .1 * sun_size, color: Colors.brown);
            mercury.Rotate(sun,
                        speed: 3f,
                        axis: new Vector3(0f, 0f, 1f),
                        distance: 1.3f * sun_size);
            sceenEngine.AddShape(mercury);

            Sphere venus = new Sphere(default(Vector3), .2f * sun_size, color: Colors.red_yellow);
            venus.Rotate(sun,
                        speed: 2f,
                        axis: new Vector3(1f, 1f, 0f),
                        distance: 1.8f * sun_size);
            sceenEngine.AddShape(venus);
    
            Sphere earth = new Sphere(default(Vector3), .3 * sun_size, color: Colors.blue);
            earth.Rotate(sun,
                        speed: 1.5f,
                        axis: new Vector3(0f, 0f, 1f),
                        distance: 2.5f * sun_size);
            sceenEngine.AddShape(earth);

            Sphere moon = new Sphere(default(Vector3),
                                    .2*.3*sun_size,
                                    color:Colors.white_off);
            moon.Rotate(earth, 
                        speed:6, 
                        axis:new Vector3(1f,1f,0f),
                        distance: .36f * sun_size);
            sceenEngine.AddShape(moon);


            
            Sphere mars = new Sphere(default(Vector3), .4 * sun_size, color: Colors.red);
            mars.Rotate(sun,
                        speed: 1.2f,
                        axis: new Vector3(0f, 0f, 1f),
                        distance: 3f * sun_size);
            sceenEngine.AddShape(mars);

            Sphere mars_moon = new Sphere(default(Vector3),
                                    .2*.4*sun_size,
                                    color:Colors.yellow);
            mars_moon.Rotate(mars, 
                        speed:4, 
                        axis:new Vector3(0f,0f,1f),
                        distance: .5f * sun_size);
            sceenEngine.AddShape(mars_moon);

            Sphere mars_moon2 = new Sphere(default(Vector3),
                                    .4f *.4f*sun_size,
                                    color:Colors.brown);
            mars_moon2.Rotate(mars, 
                        speed:6, 
                        axis:new Vector3(1f,1f,0f),
                        distance: .8f * sun_size);
            sceenEngine.AddShape(mars_moon2);


            Sphere jupitar = new Sphere(default(Vector3), .5 * sun_size, color: Colors.orange);
            jupitar.Rotate(sun,
                        speed: 1.4f,
                        axis: new Vector3(1f, 1f, 0f),
                        distance: 4.5f * sun_size);
            sceenEngine.AddShape(jupitar);
            
            Sphere saturm = new Sphere(default(Vector3), .4 * sun_size, color: Colors.yellow);
            saturm.Rotate(sun,
                        speed: 1.6f,
                        axis: new Vector3(0f, 0f, 1f),
                        distance: 5.5f * sun_size);
            sceenEngine.AddShape(saturm);
            
            Sphere uranus = new Sphere(default(Vector3), .32 * sun_size, color: Colors.blue_white);
            uranus.Rotate(sun,
                        speed: 1.3f,
                        axis: new Vector3(0f, 0f, 1f),
                        distance: 6.3f * sun_size);
            sceenEngine.AddShape(uranus);
            
            Sphere neptune = new Sphere(default(Vector3), .35 * sun_size, color: Colors.blue_dark);
            neptune.Rotate(sun,
                        speed: 2f,
                        axis: new Vector3(1f, 1f, 0f),
                        distance: 7 * sun_size);
            sceenEngine.AddShape(neptune);



            sceenEngine.Start();
        }
    }
}
