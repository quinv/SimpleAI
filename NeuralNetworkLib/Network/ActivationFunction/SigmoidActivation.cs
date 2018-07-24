using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public class SigmoidActivation : ActivationFunctionBase
    {
        public override float Activate(float input)
        {
            float k = (float)Math.Exp(input);
            return k / (1 + k);
        }
    }
}
