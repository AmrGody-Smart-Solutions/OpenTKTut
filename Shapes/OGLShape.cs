using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTKTut.Shapes
{
    class OGLShape
    {
        public bool EnableAutoRotate { get; set; }

        protected float _rotateAngle; 
        public virtual void Draw()
        {
            
        }
        
        
    }
}
