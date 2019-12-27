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
    partial class MeshElement
    {
        public MeshElement(Vector3[] vertices, Vector2[] texcoord)
        {
            Vertices = vertices;
            Texcoord = texcoord;
        }

        public Vector3[] Vertices { get; private set; }
        public Vector2[] Texcoord { get; private set; }
    }
}
