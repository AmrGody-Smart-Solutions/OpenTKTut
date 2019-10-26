using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace OpenTKTut.Shapes
{
    partial class MeshElement
    {
        public MeshElement(int order, Vector3 normal, Vector3[] vertices)
        {
            Order = order;
            Normal = normal;
            Vertices = vertices;
        }

        public int Order { get; private set; }
        public Vector3 Normal { get; private set; }
        public Vector3[] Vertices { get; private set; }
    }
}
