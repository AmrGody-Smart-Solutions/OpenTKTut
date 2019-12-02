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
        static float[] CoreColor1 = { 0.6f, 0.0f, 0.8f };
        static float[] CoreColor2 = { 0.4f, 0.0f, 0.0f };
        static float[] ElectronsColor = { 0.0f, 0.0f, 0.8f };
        static void Main(string[] args)
        {
            SceenEngine sceenEngine = new SceenEngine();

            // core
            Sphere sp = new Sphere(new Vector3(0.0f, 0.0f, 50.0f), 2, true, CoreColor2)
            {
                IsAnchor = true
            };

            sceenEngine.AddShape(sp);

            Sphere sp2 = new Sphere(new Vector3(2.0f, 0.0f, 50.0f), 2, true, CoreColor2)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = Vector3.UnitY,
                speed = 1
            };
            sceenEngine.AddShape(sp2);

            sp2 = new Sphere(new Vector3(1.0f, 2.0f, 50.0f), 2, true, CoreColor1)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = Vector3.UnitY,
                speed = 1
            };
            sceenEngine.AddShape(sp2);



            //electrons
            sp2 = new Sphere(new Vector3(10.0f, 0.0f, 50.0f), 1, true, ElectronsColor)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = Vector3.UnitY,
                speed = 1
            };
            sceenEngine.AddShape(sp2);

            sp2 = new Sphere(new Vector3(14.0f, 0.0f, 50.0f), 1, true, ElectronsColor)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = new Vector3(0.0f, 1.0f, 1.0f),
                speed = 3
            };
            sceenEngine.AddShape(sp2);

            sp2 = new Sphere(new Vector3(0.0f, 15.0f, 50.0f), 1, true, ElectronsColor)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = new Vector3(1.0f, 0.0f, 0.0f),
                speed = 5
            };
            sceenEngine.AddShape(sp2);


            sp2 = new Sphere(new Vector3(-14.0f, 0.0f, 50.0f), 1, true, ElectronsColor)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = new Vector3(0.0f, -1.0f, 0.0f),
                speed = 2
            };
            sceenEngine.AddShape(sp2);

            sp2 = new Sphere(new Vector3(19.0f, 0.0f, 50.0f), 1, true, ElectronsColor)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = new Vector3(0.5f, 0.0f, -1.0f),
                speed = 6
            };
            sceenEngine.AddShape(sp2);

            sp2 = new Sphere(new Vector3(-16.0f, 0.0f, 50.0f), 1, true, ElectronsColor)
            {
                IsAnchor = false,
                RotateAround = sp.Center,
                RotationVector = new Vector3(0.5f, 0.0f, -1.0f),
                speed = 6
            };
            sceenEngine.AddShape(sp2);


            sceenEngine.Start();
            //sceenEngine.AddShape()
        }
    }
}
