using NeuralNetworkLib.Network.Core.NetworkWeights;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Core
{
    public class Network
    {
        private NetworkEvaluator networkEvaluator;

        private NetworkStructure networkStructure;
        private Weights weights;

        public float Fitness
        {
            get;
            private set;
        }

        public Network(NetworkStructure networkStructure, int[] nodesPerLayer)
        {
            this.networkStructure = networkStructure;
            weights = new Weights(nodesPerLayer);
            networkEvaluator = new NetworkEvaluator(this.networkStructure, weights);
        }

        public Network(NetworkStructure networkStructure, Weights weights)
        {
            this.networkStructure = networkStructure;
            this.weights = weights;
            networkEvaluator = new NetworkEvaluator(this.networkStructure, this.weights);
        }

        public void ResetFitness()
        {
            Fitness = 0;
        }

        public Weights GetWeights()
        {
            return weights;
        }

        public void ReplaceWeights(Weights weights)
        {
            this.weights = weights;
            networkEvaluator.ReplaceWeights(weights);
        }

        public float[] EvaluateNetwork(float[] input)
        {
            return networkEvaluator.Evaluate(input);
        }

        public void AddFitness(float addedFitness)
        {
            Fitness += addedFitness;
        }
    }
}
