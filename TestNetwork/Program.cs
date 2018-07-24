using NeuralNetworkLib.Network.Core;
using NeuralNetworkLib.Network.Core.NetworkWeights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nodesPerLayer = new int[] { 2, 10, 10, 1 };

            NetworkStructure networkStructure = new NetworkStructure(nodesPerLayer);

            Random r = new Random();

            int numNetworks = 100;
            int generations = 100;
            Network[] networks = new Network[numNetworks];
            for (int i = 0; i < networks.Length; i++)
            {
                Weights weights = new Weights(nodesPerLayer);
                networks[i] = new Network(networkStructure, weights);
            }
            MutateNetworks mutateNetworks = new MutateNetworks(0.05f, 10, 2, nodesPerLayer);


            for (int i = 0; i < generations; i++)
            {
                for (int j = 0; j < networks.Length; j++)
                {
                    networks[j].ResetFitness();
                    float[] output = networks[j].EvaluateNetwork(new float[] { 1, 0 });

                    networks[j].AddFitness(1 - Math.Abs(output[0]));

                    Console.WriteLine(output[0]);
                }
                mutateNetworks.Mutate(networks);

            }

            for (int i = 0; i < networks.Length; i++)
            {
                Console.WriteLine("Fitness: " + networks[i].Fitness);
            }

            Console.WriteLine();

            Network bestNetwork = SortNetworks.GetBestNetwork(networks);
            Console.WriteLine(bestNetwork.EvaluateNetwork(new float[] { 1, 0 })[0]);

            Console.ReadKey();
        }
    }
}
