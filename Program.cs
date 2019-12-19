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

using OpenTK;
using OpenTKTut.Shapes;
namespace OpenTKTut
{
    class Program
    {
        static float[] sunColor = { 0.25f, 0.15f, 0.0f };
        static float[] planetColor = { 0.4f, 0.0f, 0.0f };
        static float[] planetColor2 = { 0.04f, 0.02f, 0.3f };

        static float[] moonColor = { 0.8f, 0.8f, 0.8f };
        static void Main(string[] args)
        {
            SceenEngine sceenEngine = new SceenEngine();

            Sphere sun = new Sphere(new Vector3(0.0f, 0.0f, 50.0f), 4.5, true, sunColor) { };
            sceenEngine.AddShape(sun);

            Sphere planet1 = new Sphere(new Vector3(10.0f, 0.0f, 50.0f), 1.5, true, planetColor) { 
                RotateAround = sun.Center,
                speed = 2
            };
            sceenEngine.AddShape(planet1);

            Sphere moon1_1 = new Sphere(new Vector3(15.0f, 0.0f, 50.0f), 0.5, true, moonColor) { 
                RotateAround = sun.Center,
                RotateAroundPlanet = true,
                planet = planet1.Center,
                speed = 1f
            };
            sceenEngine.AddShape(moon1_1);
            Sphere moon1_2 = new Sphere(new Vector3(5.0f, 0.0f, 50.0f), 0.7, true, moonColor)
            {
                RotateAround = sun.Center,
                RotateAroundPlanet = true,
                planet = planet1.Center,
                speed = 1f,
            };
            sceenEngine.AddShape(moon1_2);

            Sphere planet2 = new Sphere(new Vector3(20.0f, 0.0f, 50.0f), 2.5, true, planetColor2)
            {
                RotateAround = sun.Center,
                RotationVector = Vector3.UnitY,
                speed = 0.5f

            };
            sceenEngine.AddShape(planet2); 
            sceenEngine.Start();
            //sceenEngine.AddShape()
        }
    }
}
