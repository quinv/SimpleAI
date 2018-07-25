using NeuralNetworkLib.Network.Core.NetworkWeights;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeuralNetworkLib.Network.Core
{
    public class MutateNetworks
    {
        //the percentage of change the weight can have
        private static float MUTATION_SIZE = 0.05f;

        private Random r = new Random();

        private float mutationChance;
        private int numKeptNetworks;
        private int numRandomNetworks;
        private int[] nodesPerLayer;

        /// <summary>
        /// Creates a new mutate networks class
        /// </summary>
        /// <param name="mutationChance">the chance to mutate between 0 and 1</param>
        /// <param name="numKeptNetworks">the number of networks that stay unchanged</param>
        public MutateNetworks(float mutationChance, int numKeptNetworks, int numRandomNetworks, int[] nodesPerLayer)
        {
            this.mutationChance = mutationChance;
            this.numKeptNetworks = numKeptNetworks;
            this.numRandomNetworks = numRandomNetworks;
            this.nodesPerLayer = nodesPerLayer;
        }


        public void Mutate(Network[] networks)
        {
            SortNetworks.SortNetworksOnFitness(networks);
            Network[] parentNetworks = networks.Take(numKeptNetworks).ToArray();

            for (int i = numKeptNetworks; i < numKeptNetworks + numRandomNetworks; i++)
            {
                networks[i].ReplaceWeights(new Weights(nodesPerLayer));
            }

            for (int i = numKeptNetworks + numRandomNetworks; i < networks.Length; i++)
            {
                Weights weights = new Weights();
                weights.WeightValues = CrossoverWeights(parentNetworks);
                weights.WeightValues = MutateWeights(weights.WeightValues);
                networks[i].ReplaceWeights(weights);
            }
        }

        private float[] CrossoverWeights(Network[] parentNetworks)
        {
            Network parent1 = parentNetworks[r.Next(parentNetworks.Length)];
            Network parent2 = parentNetworks[r.Next(parentNetworks.Length)];
            float[] weights1 = parent1.GetWeights().WeightValues;
            float[] weights2 = parent2.GetWeights().WeightValues;

            float[] newWeights = new float[weights1.Length];
            for (int i = 0; i < newWeights.Length; i++)
            {
                newWeights[i] = r.Next(2) == 0 ? weights1[i] : weights2[i];
            }
            return newWeights;
        }

        private float[] MutateWeights(float[] weightValues)
        {
            for (int i = 0; i < weightValues.Length; i++)
            {
                if(r.NextDouble() < mutationChance)
                {
                    weightValues[i] = weightValues[i] * (1 + (float)r.NextDouble() * MUTATION_SIZE * 2 - MUTATION_SIZE);// makes a value between 0.95 and 1.05 if mutation size == 0.05
                    if(r.NextDouble() < 0.1f)
                    {
                        weightValues[i] *= -1;
                    }
                    if(r.NextDouble() < 0.01f)
                    {
                        weightValues[i] += r.Next(2) == 0 ? 1 : -1;
                    }
                }
            }
            return weightValues;
        }
    }
}
