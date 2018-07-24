using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public class SinusActivation : ActivationFunctionBase
    {
        public override float Activate(float input)
        {
            return (float)Math.Sin(input);
        }
    }
}
