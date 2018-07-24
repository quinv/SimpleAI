using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.ActivationFunction
{
    public class TanHActivation : ActivationFunctionBase
    {
        public override float Activate(float input)
        {
            return (float)Math.Tanh(input);
        }
    }
}
