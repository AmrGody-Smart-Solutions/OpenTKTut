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
            
            
            
            
            Shapes.Cube cube = new Shapes.Cube(new Vector3(0.0f, 0.0f, 45.0f),10.0f,true);
            sceenEngine.AddShape(cube);
            
            cube = new Shapes.Cube(new Vector3(-10.0f, 10.0f, 30.0f), 5.0f,true);
            sceenEngine.AddShape(cube);
            
            cube = new Shapes.Cube(new Vector3(10.0f, -10.0f, 60.0f), 3.0f, true);
            sceenEngine.AddShape(cube);
            
            cube = new Shapes.Cube(new Vector3(10.0f, 10.0f, 40.0f), 3.0f, true);
            sceenEngine.AddShape(cube);

            Shapes.Sphere sp = new Shapes.Sphere(new Vector3( 10.0f,15.0f,50.0f), 5, true);
            sceenEngine.AddShape(sp);
            sceenEngine.Start();
           //sceenEngine.AddShape()
        }
    }
}
