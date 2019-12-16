using OpenTK;
using OpenTKTut;
using OpenTKTut.Shapes;
using System;

public class Scene
{
	public Scene()
	{
	}

    public void original_scene(SceenEngine sceenEngine)
    {

        Cube cube1 = new Cube(new Vector3(-10.0f, -7.0f, 35.0f), 5.0f, true);
        sceenEngine.AddShape(cube1);

        Cube cube2 = new Cube(new Vector3(10.0f, -10.0f, 60.0f), 3.0f, true);
        sceenEngine.AddShape(cube2);

        Cube cube3 = new Cube(new Vector3(10.0f, -10.0f, 40.0f), 3.0f, true);
        sceenEngine.AddShape(cube3);

        Sphere sp = new Sphere(new Vector3(-20.0f, 20.0f, 80.0f), 5, true);
        sp.Color = Colors.blue;
        sceenEngine.AddShape(sp);


        sp = new Sphere(new Vector3(0.0f, 0f, 30.0f), 3, false);
        sp.Color = Colors.blue;
        sceenEngine.AddShape(sp);
        cube3.Rotate(sp, 10);
    }
    public void big_sun(SceenEngine sceenEngine)
    {
        float sun_size = 20f;
        Sphere sun = new Sphere(new Vector3(0f, 0f, 80f), sun_size, color: Colors.yellow_light);
        sun.Rotate();  // rotating around itself
        sceenEngine.AddShape(sun);

        Cube cube = new Cube(new Vector3(0f, 0f, 10f), .25f* sun_size);
        cube.Rotate(sun, 1.5f * sun_size);
        sceenEngine.AddShape(cube);
    }
    public void solar_system_3d(SceenEngine sceenEngine)
    {
        float sun_size = 4f;
        Sphere sun = new Sphere(new Vector3(0f, 0f, 80f), sun_size, color: Colors.yellow_light);
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
                                .2 * .3 * sun_size,
                                color: Colors.white_off);
        moon.Rotate(earth,
                    speed: 6,
                    axis: new Vector3(1f, 1f, 0f),
                    distance: .36f * sun_size);
        sceenEngine.AddShape(moon);



        Sphere mars = new Sphere(default(Vector3), .4 * sun_size, color: Colors.red);
        mars.Rotate(sun,
                    speed: 1.2f,
                    axis: new Vector3(0f, 0f, 1f),
                    distance: 3f * sun_size);
        sceenEngine.AddShape(mars);

        Sphere mars_moon = new Sphere(default(Vector3),
                                .2 * .4 * sun_size,
                                color: Colors.yellow);
        mars_moon.Rotate(mars,
                    speed: 4,
                    axis: new Vector3(0f, 0f, 1f),
                    distance: .5f * sun_size);
        sceenEngine.AddShape(mars_moon);

        Sphere mars_moon2 = new Sphere(default(Vector3),
                                .4f * .4f * sun_size,
                                color: Colors.brown);
        mars_moon2.Rotate(mars,
                    speed: 6,
                    axis: new Vector3(1f, 1f, 0f),
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


    }
    public void solar_moon_earth_sun(SceenEngine sceenEngine)
    {
        float sun_size = 10f;
        Sphere sun = new Sphere(new Vector3(0f, 0f, 80f), sun_size, color: Colors.yellow_light);
        //sun.Rotate();  // rotating around itself
        sceenEngine.AddShape(sun);

        Sphere earth = new Sphere(default(Vector3), .3 * sun_size, color: Colors.blue);
        earth.Rotate(sun,
                    speed: 1.5f,
                    axis: new Vector3(0f, 0f, 1f),
                    distance: 2.5f * sun_size);
        sceenEngine.AddShape(earth);

        Sphere moon = new Sphere(default(Vector3),
                                .2 * .3 * sun_size,
                                color: Colors.white_off);
        moon.Rotate(earth,
                    speed: 6,
                    axis: new Vector3(1f, 1f, 0f),
                    distance: .36f * sun_size);
        sceenEngine.AddShape(moon);

    }
    public void solar_system_top_view(SceenEngine sceenEngine)
    {
        float sun_size = 4f;
        Sphere sun = new Sphere(new Vector3(0f, 0f, 80f), sun_size, color: Colors.yellow_light);
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
                    axis: new Vector3(0f, 0f, 1f),
                    distance: 1.8f * sun_size);
        sceenEngine.AddShape(venus);

        Sphere earth = new Sphere(default(Vector3), .3 * sun_size, color: Colors.blue);
        earth.Rotate(sun,
                    speed: 1.5f,
                    axis: new Vector3(0f, 0f, 1f),
                    distance: 2.5f * sun_size);
        sceenEngine.AddShape(earth);

        Sphere moon = new Sphere(default(Vector3),
                                .2 * .3 * sun_size,
                                color: Colors.white_off);
        moon.Rotate(earth,
                    speed: 6,
                    axis: new Vector3(1f, 1f, 0f),
                    distance: .36f * sun_size);
        sceenEngine.AddShape(moon);



        Sphere mars = new Sphere(default(Vector3), .4 * sun_size, color: Colors.red);
        mars.Rotate(sun,
                    speed: 1.2f,
                    axis: new Vector3(0f, 0f, 1f),
                    distance: 3f * sun_size);
        sceenEngine.AddShape(mars);

        Sphere mars_moon = new Sphere(default(Vector3),
                                .2 * .4 * sun_size,
                                color: Colors.yellow);
        mars_moon.Rotate(mars,
                    speed: 4,
                    axis: new Vector3(0f, 0f, 1f),
                    distance: .5f * sun_size);
        sceenEngine.AddShape(mars_moon);

        Sphere mars_moon2 = new Sphere(default(Vector3),
                                .4f * .4f * sun_size,
                                color: Colors.brown);
        mars_moon2.Rotate(mars,
                    speed: 6,
                    axis: new Vector3(1f, 1f, 0f),
                    distance: .8f * sun_size);
        sceenEngine.AddShape(mars_moon2);


        Sphere jupitar = new Sphere(default(Vector3), .5 * sun_size, color: Colors.orange);
        jupitar.Rotate(sun,
                    speed: 1.4f,
                    axis: new Vector3(0f, 0f, 1f),
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
                    axis: new Vector3(0f, 0f, 1f),
                    distance: 7 * sun_size);
        sceenEngine.AddShape(neptune);


    }
}
