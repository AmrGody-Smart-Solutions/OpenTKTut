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

            Scene s = new Scene();
            //enable only one
            //s.solar_moon_earth_sun(sceenEngine);
            //s.solar_system_3d(sceenEngine);
            //s.solar_system_top_view(sceenEngine);
            //s.big_sun(sceenEngine);
            //s.big_cube(sceenEngine);

            s.original_scene(sceenEngine);


            sceenEngine.Start();
        }
    }
}
