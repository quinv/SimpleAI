using NeuralNetworkLib.Network.ActivationFunction;
using NeuralNetworkLib.Network.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Core
{
    public class NetworkStructure
    {
        private static ActivationFunctionBase defaultActivationFunction = new SigmoidActivation();

        private INode[][] nodes; 

        public NetworkStructure(int[] nodesPerLayer)
        {
            PopulateStructure(nodesPerLayer, defaultActivationFunction);
        }

        public NetworkStructure(int[] nodesPerLayer, ActivationFunctionBase activationFunction)
        {
            PopulateStructure(nodesPerLayer, activationFunction);
        }

        public NetworkStructure(int[] nodesPerLayer, ActivationFunctionBase[] activationFunctionPerLayer)
        {
            nodes = new INode[nodesPerLayer.Length][];
            for (int i = 0; i < nodesPerLayer.Length; i++)
            {
                nodes[i] = new INode[nodesPerLayer[i]];
                for (int j = 0; j < nodesPerLayer[i]; j++)
                {
                    if (i == 0)
                    {
                        nodes[i][j] = new InputNode();
                    }
                    else
                    {
                        nodes[i][j] = new OutputNode(activationFunctionPerLayer[i]);
                    }
                }
            }
        }

        private void PopulateStructure(int[] nodesPerLayer, ActivationFunctionBase activationFunction)
        {
            nodes = new INode[nodesPerLayer.Length][];
            for (int i = 0; i < nodesPerLayer.Length; i++)
            {
                nodes[i] = new INode[nodesPerLayer[i]];
                for (int j = 0; j < nodesPerLayer[i]; j++)
                {
                    if (i == 0)
                    {
                        nodes[i][j] = new InputNode();
                    }
                    else
                    {
                        nodes[i][j] = new OutputNode(defaultActivationFunction);
                    }
                }
            }
        }

        public INode[][] GetNodes
        {
            get { return (INode[][])nodes.Clone(); }
        }

    }
}
