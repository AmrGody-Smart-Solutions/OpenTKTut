using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTKTut
{
    class MyView
    {
        private float zoom, rotation;
    private Vector2 position;
    public MyView(Vector2 position, float zoom = 1.0f, float rotation = 0.0f)
    {
        this.position = position;
        this.zoom = zoom;
        this.rotation = rotation;
    }

    public void Update(Vector2 posDelta , float zoomDelta = 1.0f, float rotationDelta = 0.0f)
    {
        this.position = this.position + posDelta;
        this.zoom = this.zoom + zoomDelta;
        this.rotation = this.rotation + rotationDelta;
    }

    public void ApplyTransform()
    {
        Matrix4 transfrom = Matrix4.Identity;
        transfrom = Matrix4.Mult(transfrom, Matrix4.CreateTranslation(-position.X,-position.Y,0)); // change the x and y bcuz 2 dimentions camera position
        transfrom = Matrix4.Mult(transfrom, Matrix4.CreateRotationY(rotation)); //rotate around the z axis
        transfrom = Matrix4.Mult(transfrom, Matrix4.CreateScale(zoom,zoom,1.0f)); //zoom in the x and y but not z

        GL.MultMatrix(ref transfrom);
    }
    }
}
