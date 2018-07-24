using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public class GaussianActivation : ActivationFunctionBase
    {
        public override float Activate(float input)
        {
            return (float)Math.Exp(-(input * input));
        }
    }
}
