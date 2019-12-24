﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTut.Shapes
{
    class Orbit : OGLShape
    {
        float[] color;
        public Orbit(
                      Vector3 center,
                      double radius,
                      bool autoRotate,
                      float[] color) : base(center)
        {
            Center = center;
            this.color = color;
            Radius = radius;
            EnableAutoRotate = autoRotate;
        }

        public double Radius { get; set; }
        protected override void ShapeDrawing()
        {
            base.ShapeDrawing();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(BeginMode.Points);
            GL.Color3(color);
            float x, z, i;


            for ( i = 0; i < 2*Math.PI; i=i + 0.0001f)
            {
                // GL.Normal3(MeshPolygons[i].Normal);
                x = (float) (Radius * Math.Cos(i));
                z = (float)(Radius * Math.Sin(i));

                GL.Vertex3((double)x, -1.0,z);

                /*for (int j = 0; j < MeshPolygons[i].Vertices.Length; j++)
                {
                    GL.Normal3(MeshPolygons[i].Vertices[j]);
                    GL.Vertex3(MeshPolygons[i].Vertices[j]);
                }*/

            }
            GL.End();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);


        }
    }
}
