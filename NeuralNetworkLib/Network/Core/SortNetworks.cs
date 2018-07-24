using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Core
{
    public static class SortNetworks
    {

        public static void SortNetworksOnFitness(Network[] networks)
        {
            Array.Sort(networks, delegate (Network x, Network y) { return y.Fitness.CompareTo(x.Fitness); });
        }

        public static Network GetBestNetwork(Network[] networks)
        {
            SortNetworksOnFitness(networks);
            return networks[0];
        }

    }
}
