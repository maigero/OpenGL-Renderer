using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung.engine.Interfaces
{
    internal interface IHasTransformationInfo
    {
        public Matrix4 transformationData { get; }
    }
}
