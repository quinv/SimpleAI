using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public abstract class ActivationFunctionBase
    {
        public abstract float Activate(float input);
    }
}
