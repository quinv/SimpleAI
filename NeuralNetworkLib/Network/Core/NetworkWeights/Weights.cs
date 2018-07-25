using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Saves the weights to a file (be carefull, overwrites previous file with the same name)
        /// </summary>
        /// <param name="fileName">name of the file (+ path)</param>
        public void SaveWeights(string fileName)
        {
            using(StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(weightValues.Length);
                for (int i = 0; i < weightValues.Length; i++)
                {
                    writer.WriteLine(weightValues[i]);
                }
            }
        }

        /// <summary>
        /// Loads the weights from a file and saves the in this instance
        /// </summary>
        /// <param name="fileName">name of the file (+path)</param>
        public void LoadWeights(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                weightValues = new float[int.Parse(reader.ReadLine())];
                for (int i = 0; i < weightValues.Length; i++)
                {
                    weightValues[i] = float.Parse(reader.ReadLine());
                }
            } 
        }
    }
}
