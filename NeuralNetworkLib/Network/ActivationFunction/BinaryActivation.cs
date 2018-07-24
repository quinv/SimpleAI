using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public class BinaryActivation : ActivationFunctionBase
    {
        public override float Activate(float input)
        {
            return input > 0 ? 1 : 0;
        }
    }
}
