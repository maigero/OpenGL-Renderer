﻿using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung.engine.Interfaces
{
    public interface IRenderAble
    {
        public Matrix4 doRender(Matrix4 parentTransformation);
    }
}
