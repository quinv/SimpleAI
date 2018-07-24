using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public class LinearActivation : ActivationFunctionBase
    {
        public override float Activate(float input)
        {
            return input;
        }
    }
}
