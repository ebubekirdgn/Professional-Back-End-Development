﻿using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        public TransactionScopeAspect()
        {

        }

    }
}
