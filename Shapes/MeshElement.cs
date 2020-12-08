/*H**********************************************************************
* FILENAME :        MeshElement.cs             DESIGN REF: OGLTUT01
*
* DESCRIPTION :
*       Mesh object base functions of all shapes.
*
* PUBLIC FUNCTIONS :
*       void     ShapeDrawing( FileHandle )
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

namespace OpenTKTut.Shapes
{
    public partial class MeshElement
    {
        public MeshElement(int order, Vector3 normal, Vector3[] vertices)
        {
            Order = order;
            Normal = normal;
            Vertices = vertices;
        }
           public MeshElement(int order, Vector3[] normals, Vector3[] vertices)
        {
            Order = order;
            Normals = normals;
            Vertices = vertices;
        }


        public int Order { get; private set; }
        public Vector3 Normal { get; private set; }
        public Vector3[] Normals { get; private set; }

        public Vector3[] Vertices { get; private set; }
    }
}
