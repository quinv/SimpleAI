using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Node
{
    public interface INode
    {
        void SetInput(params float[] inputs);
        float getOutput();
        //TODO: add MemoryNode
    }
}
