using NeuralNetworkLib.Network.Core.NetworkWeights;
using NeuralNetworkLib.Network.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Core
{
    public class NetworkEvaluator
    {

        private INode[][] networkStructure;
        private Weights networkWeights;

        public NetworkEvaluator(NetworkStructure networkStructure, Weights networkWeights)
        {
            this.networkStructure = networkStructure.GetNodes;
            this.networkWeights = networkWeights;
        }

        public float[] Evaluate(float[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                networkStructure[0][i].SetInput(input[i]);
            }

            int weightCounter = 0;
            for (int i = 1; i < networkStructure.Length; i++)
            {
                for (int j = 0; j < networkStructure[i].Length; j++)
                {
                    float inputSum = 0;
                    for (int k = 0; k < networkStructure[i-1].Length; k++)
                    {
                        inputSum += networkStructure[i - 1][k].getOutput() * networkWeights.WeightValues[weightCounter];
                        weightCounter++;
                    }
                    networkStructure[i][j].SetInput(inputSum);
                }
            }

            float[] output = new float[networkStructure[networkStructure.Length - 1].Length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = networkStructure[networkStructure.Length - 1][i].getOutput();
            }

            return output;
        }

        internal void ReplaceWeights(Weights weights)
        {
            networkWeights = weights;
        }
    }
}
