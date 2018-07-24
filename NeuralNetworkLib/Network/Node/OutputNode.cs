using NeuralNetworkLib.Network.ActivationFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkLib.Network.Node
{
    internal class OutputNode : INode
    {
        float output = 0;
        ActivationFunctionBase activationFunction;

        public OutputNode(ActivationFunctionBase activationFunction)
        {
            this.activationFunction = activationFunction;
        }

        public float getOutput()
        {
            return output;
        }

        public void SetInput(params float[] inputs)
        {
            float bias = 1;//TODO: add biasMultiplier
            float outputSum = bias;
            for (int i = 0; i < inputs.Length; i++)
            {
                outputSum += inputs[i];
            }

            output = CalculateActivateFunction(outputSum);
        }

        public void SetInput(params INode[] inputs) //TODO: add in INode
        {
            float bias = 1;
            float outputSum = bias;
            for (int i = 0; i < inputs.Length; i++)
            {
                outputSum += inputs[i].getOutput();
            }

            output = CalculateActivateFunction(outputSum);
        }

        protected float CalculateActivateFunction(float outputSum)
        {
            return activationFunction.Activate(outputSum);
        }
    }
}
