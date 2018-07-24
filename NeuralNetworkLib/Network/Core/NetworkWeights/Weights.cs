using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Core.NetworkWeights
{
    public struct Weights
    {
        private static Random random = new Random();

        private float[] weightValues;
        
        public float[] WeightValues
        {
            get { return weightValues; }
            set { weightValues = value; }
        }

        public Weights(int[] nodesPerLayer)
        {
            weightValues = null;//necessary because the weightvalues needs to be initialized before we can use call functions in this struct
            weightValues = new float[GetNumConnections(nodesPerLayer)];

            for (int i = 0; i < weightValues.Length; i++)
            {
                weightValues[i] = ((float)random.NextDouble()) * 2 - 1;//TODO: add multiplier
            }
        }

        private int GetNumConnections(int[] nodesPerLayer)
        {
            int numConnections = 0;
            for (int i = 1; i < nodesPerLayer.Length; i++)
            {
                numConnections += nodesPerLayer[i - 1] * nodesPerLayer[i];
            }
            return numConnections;
        }
    }
}
