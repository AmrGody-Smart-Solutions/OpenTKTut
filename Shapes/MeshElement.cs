using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
        public enum MatrixFormat
        {
            RowBased,
            ColumnBased
        }
        public static bool LoadTexture(MeshElement[] meshPolygons, BitmapData textureBitmapData,int rows,int columns,MatrixFormat format = MatrixFormat.RowBased)
        {
            bool res = true;
            res = meshPolygons.Length == rows * columns;
            int element = 0;
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j< columns;j++)
                {
                    element = i + j * columns;
                    
                }
            }
            return res;
        }
    }
}
