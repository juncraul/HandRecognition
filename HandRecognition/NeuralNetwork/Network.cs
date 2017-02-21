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
            HiddenLayer.Input = new Matrix(HiddenNodes, 1);
            HiddenLayer.Output = new Matrix(HiddenNodes, 1);

            InputLayer.Weights = new Matrix(HiddenNodes, InputNodes);
            InputLayer.Weights.GenerateRandomValuesBetween(-Math.Pow(HiddenNodes, -0.5), Math.Pow(HiddenNodes, -0.5));
            HiddenLayer.Weights = new Matrix(OutputNodes, HiddenNodes);
            HiddenLayer.Weights.GenerateRandomValuesBetween(-Math.Pow(OutputNodes, -0.5), Math.Pow(OutputNodes, -0.5));
        }

        public void TrainNetwrok(Matrix inputs, Matrix target)
        {
            Matrix final_outputs = QueryNetwrok(inputs);
            Matrix output_errors = target - final_outputs;
            Matrix hidden_errors = HiddenLayer.Weights.Transpose() * output_errors;
            Matrix HiddenLayer_Output_Transpose = HiddenLayer.Input.Transpose();
            Matrix inputs_Transpose = inputs.Transpose();

            for (int i = 0; i < output_errors.Lines; i ++)
            {
                double change = (output_errors.TheMatrix[i, 0] * final_outputs.TheMatrix[i, 0] * (1.0 - final_outputs.TheMatrix[i, 0]));
                HiddenLayer.Weights.AddToLine(LearningRate * (change * HiddenLayer_Output_Transpose), i);
            }

            for (int i = 0; i < hidden_errors.Lines; i++)
            {
                double change = (hidden_errors.TheMatrix[i, 0] * HiddenLayer.Input.TheMatrix[i, 0] * (1.0 - HiddenLayer.Input.TheMatrix[i, 0]));
                InputLayer.Weights.AddToLine(LearningRate * (change * inputs_Transpose), i);
            }
        }

        public Matrix QueryNetwrok(Matrix inputs)
        {
            InputLayer.Input = inputs;
            InputLayer.Output = InputLayer.Weights * InputLayer.Input;

            for (int i = 0; i < HiddenNodes; i++)
            {
                HiddenLayer.Input.TheMatrix[i, 0] = ActivationFunction(InputLayer.Output.TheMatrix[i, 0]);
            }

            HiddenLayer.Output = HiddenLayer.Weights * HiddenLayer.Input;
            OutputLayer.Output = new Matrix(OutputNodes, 1);

            for (int i = 0; i < OutputNodes; i++)
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
        public Matrix Input { get; set; }
        public Matrix Output { get; set; }
        public Matrix Weights { get; set; }
    }
}
