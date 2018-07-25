using NeuralNetworkLib.Network.ActivationFunction;
using NeuralNetworkLib.Network.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMarioKartPositions
{
    class Program
    {
        private const string WEIGHTS_FILE = "MKPosition.weight";
        private const string TRAINIG_DATA_PATH = "D:\\neural networks\\NeuralNetworkLib\\TrainingData\\PositionData";

        static void Main(string[] args)
        {
            int[] nodesPerLayer = new int[] { 400, 200, 100, 50, 30, 13 };
            NetworkStructure networkStructure = new NetworkStructure(nodesPerLayer, new TanHActivation());

            Network[] networks = new Network[100];

            bool fromFile = false;

            fromFile = true;
            string fileName = WEIGHTS_FILE;

            //Console.Write("Load from file (empty if using no file): ");
            //string fileName = Console.ReadLine();
            //if(fileName != "")
            //{
            //    fromFile = true;
            //}
            //else
            //{
            //    fileName = WEIGHTS_FILE;
            //}

            for (int i = 0; i < networks.Length; i++)
            {
                if (fromFile)
                {
                    networks[i] = new Network(networkStructure, fileName);
                }
                else
                {
                    networks[i] = new Network(networkStructure, nodesPerLayer);
                }
            }
            MutateNetworks mutateNetworks = new MutateNetworks(0.05f, 10, 2, nodesPerLayer);

            int CurrentGeneration = 1;
            //infinite loop for training
            for(; ; )
            {
                Console.WriteLine("generation " + CurrentGeneration++ + ": ");
                //testing each networks
                for (int i = 0; i < networks.Length; i++)
                {
                    networks[i].ResetFitness();
                    Console.Write(".");
                    //testing 130 images
                    for (int j = 0; j < 130; j++)
                    {
                        PositionData evaluatedImage = ImageLoading.LoadImage(j / 10, TRAINIG_DATA_PATH);
                        float[] output = networks[i].EvaluateNetwork(evaluatedImage.imageInfo);
                        for (int k = 0; k < output.Length; k++)
                        {
                            if(evaluatedImage.expectedResult[k] == 1)
                            {
                                networks[i].AddFitness(output[k] * 10);
                            }
                            else
                            {
                                networks[i].AddFitness(-Math.Abs(output[k]));
                            }
                        }
                    }
                }

                Network bestNetwork = SortNetworks.GetBestNetwork(networks);

                Console.WriteLine();
                Console.WriteLine("Fitness: " + bestNetwork.Fitness);

                for (int j = 0; j < 13; j++)
                {
                    PositionData evaluatedImage = ImageLoading.LoadImage(j, TRAINIG_DATA_PATH);
                    float[] output = bestNetwork.EvaluateNetwork(evaluatedImage.imageInfo);
                    float maxValue = output.Max();
                    Console.WriteLine(output.ToList().IndexOf(maxValue));
                }

                bestNetwork.SaveNetwork(fileName);

                mutateNetworks.Mutate(networks);
            }
        }
    }
}
