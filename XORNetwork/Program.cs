using NeuralNetworkLib.Network.ActivationFunction;
using NeuralNetworkLib.Network.Core;
using NeuralNetworkLib.Network.Core.NetworkWeights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nodesPerLayer = new int[] { 2, 3, 1 };

            float[][] inputs = new float[][] { new float[] { 0, 0},
            new float[] { 1, 0},
            new float[] { 0, 1},
            new float[] { 1, 1}};

            float[] outputs = new float[] { 0, 1, 1, 0 };

            NetworkStructure networkStructure = new NetworkStructure(nodesPerLayer, new SigmoidActivation());

            Random r = new Random();

            int numNetworks = 100;
            int generations = 100000;
            Network[] networks = new Network[numNetworks];
            for (int i = 0; i < networks.Length; i++)
            {
                networks[i] = new Network(networkStructure, nodesPerLayer);
            }
            MutateNetworks mutateNetworks = new MutateNetworks(0.05f, 10, 2, nodesPerLayer);

            for (int i = 0; ; i++)
            {
                Console.WriteLine("Generation " + i + ": ");
                for (int j = 0; j < networks.Length; j++)
                {
                    networks[j].ResetFitness();
                    for (int k = 0; k < inputs.Length; k++)
                    {
                        float[] output = networks[j].EvaluateNetwork(inputs[k]);
                        networks[j].AddFitness(1 - Math.Abs(output[0] - outputs[k]));
                    }
                }



                Network bestNetwork = SortNetworks.GetBestNetwork(networks);
                Console.WriteLine("Fitness: " + bestNetwork.Fitness);
                for (int a = 0; a < inputs.Length; a++)
                {
                    Console.WriteLine(bestNetwork.EvaluateNetwork(inputs[a])[0]);
                    if(bestNetwork.Fitness > 3.8f)
                    {
                        goto generationLoop;
                    }
                }

                mutateNetworks.Mutate(networks);

            }

            generationLoop:

            for (int i = 0; i < networks.Length; i++)
            {
                Console.WriteLine("Fitness: " + networks[i].Fitness);
            }

            Console.WriteLine();

            //Network bestNetwork = SortNetworks.GetBestNetwork(networks);
            //Console.WriteLine(bestNetwork.EvaluateNetwork(new float[] { 1, 0 })[0]);

            Console.ReadKey();
        }
    }
}
