using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Node
{
    internal class InputNode : INode
    {
        private float output = 0;

        public float getOutput()
        {
            return output;
        }

        public void SetInput(params float[] inputs)
        {
            output = inputs[0];
        }
    }
}
