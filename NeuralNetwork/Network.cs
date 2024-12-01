using Mathematics;
using System;

namespace NeuralNetwork
{
    public class Network
    {
        public int InputNodes { get; set; }
        public int HiddenNodes { get; set; }
        public int OutputNodes { get; set; }
        public float LearningRate { get; set; }

        private Layer InputLayer { get; set; }
        private Layer HiddenLayer { get; set; }
        private Layer OutputLayer { get; set; }

        public void InitializeNetwork(int inputNodes, int hiddenNodes, int outputNodes, float learningRate)
        {
            InputNodes = inputNodes;
            HiddenNodes = hiddenNodes;
            OutputNodes = outputNodes;
            LearningRate = learningRate;
            InputLayer = new Layer();
            HiddenLayer = new Layer();
            OutputLayer = new Layer();

            InputLayer.Weights = new Matrix(HiddenNodes, InputNodes);
            InputLayer.Weights.GenerateRandomValuesBetween(-Math.Pow(HiddenNodes, -0.5), Math.Pow(HiddenNodes, -0.5));
            HiddenLayer.Weights = new Matrix(OutputNodes, HiddenNodes);
            HiddenLayer.Weights.GenerateRandomValuesBetween(-Math.Pow(OutputNodes, -0.5), Math.Pow(OutputNodes, -0.5));
        }

        public void TrainNetwork(Matrix inputs, Matrix target)
        {
            OutputLayer.Output = QueryNetwork(inputs);
            OutputLayer.Errors = target - OutputLayer.Output;
            HiddenLayer.Errors = HiddenLayer.Weights.Transpose() * OutputLayer.Errors;
            var hiddenLayerOutputTranspose = InputLayer.Output.Transpose();
            var inputsTranspose = inputs.Transpose();

            for (var i = 0; i < OutputLayer.Errors.Lines; i ++)
            {
                var change = (OutputLayer.Errors.TheMatrix[i, 0] * OutputLayer.Output.TheMatrix[i, 0] * (1.0 - OutputLayer.Output.TheMatrix[i, 0]));
                HiddenLayer.Weights.AddToLine(LearningRate * (change * hiddenLayerOutputTranspose), i);
            }

            for (var i = 0; i < HiddenLayer.Errors.Lines; i++)
            {
                var change = (HiddenLayer.Errors.TheMatrix[i, 0] * InputLayer.Output.TheMatrix[i, 0] * (1.0 - InputLayer.Output.TheMatrix[i, 0]));
                InputLayer.Weights.AddToLine(LearningRate * (change * inputsTranspose), i);
            }
        }

        public Matrix QueryNetwork(Matrix inputs)
        {
            InputLayer.Output = InputLayer.Weights * inputs;

            for (var i = 0; i < HiddenNodes; i++)
            {
                InputLayer.Output.TheMatrix[i, 0] = ActivationFunction(InputLayer.Output.TheMatrix[i, 0]);
            }

            HiddenLayer.Output = HiddenLayer.Weights * InputLayer.Output;
            OutputLayer.Output = new Matrix(OutputNodes, 1);

            for (var i = 0; i < OutputNodes; i++)
            {
                OutputLayer.Output.TheMatrix[i, 0] = ActivationFunction(HiddenLayer.Output.TheMatrix[i, 0]);
            }

            return OutputLayer.Output;
        }

        public double ActivationFunction(double x)
        {
            return Functions.Sigmoid(x);
        }
    }

    public class Layer
    {
        public Matrix Output { get; set; }
        public Matrix Weights { get; set; }
        public Matrix Errors { get; set; }
    }
}
