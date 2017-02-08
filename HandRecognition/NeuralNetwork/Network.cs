using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;

namespace NeuralNetwork
{
    public class Network
    {
        public int InputNodes { get; set; }
        public int HiddenNodes { get; set; }
        public int OutputNodes { get; set; }
        public float LearningRate { get; set; }
        public Matrix Winput_hidden { get; set; }
        public Matrix Whidden_output { get; set; }
        public Matrix Hidden_Inputs { get; set; }
        public Matrix Hidden_Outputs { get; set; }
        public Matrix Final_Inputs { get; set; }
        public Matrix Final_Outputs { get; set; }

        public void InitializeNetwork(int inputNodes, int hiddenNodes, int outputNodes, float learningRate)
        {
            InputNodes = inputNodes;
            HiddenNodes = hiddenNodes;
            OutputNodes = outputNodes;
            LearningRate = learningRate;
            Hidden_Inputs = new Matrix(HiddenNodes, 1);
            Hidden_Outputs = new Matrix(HiddenNodes, 1);
            Final_Inputs = new Matrix(OutputNodes, 1);
            Final_Outputs = new Matrix(OutputNodes, 1);

            Winput_hidden = new Matrix(HiddenNodes, InputNodes);
            Winput_hidden.GenerateRandomValuesBetween(-Math.Pow(HiddenNodes, -0.5), Math.Pow(HiddenNodes, -0.5));
            Whidden_output = new Matrix(OutputNodes, HiddenNodes);
            Whidden_output.GenerateRandomValuesBetween(-Math.Pow(OutputNodes, -0.5), Math.Pow(OutputNodes, -0.5));
        }

        public void TrainNetwrok(Matrix inputs, Matrix target)
        {
            Matrix final_outputs = QueryNetwrok(inputs);

            Matrix output_errors = target - final_outputs;

            Matrix hidden_errors = Whidden_output.Transpose() * output_errors;

            Whidden_output += LearningRate * ((output_errors * final_outputs * (1.0 - final_outputs)) * Hidden_Outputs.Transpose());

            Winput_hidden += LearningRate * ((hidden_errors * Hidden_Outputs * (1.0 - Hidden_Outputs)) * inputs.Transpose());
        }

        public Matrix QueryNetwrok(Matrix inputs)
        {
            Hidden_Inputs = Winput_hidden * inputs;

            for (int i = 0; i < HiddenNodes; i++)
            {
                Hidden_Outputs.TheMatrix[i, 0] = ActivationFunction(Hidden_Inputs.TheMatrix[i, 0]);
            }

            Final_Inputs = Whidden_output * Hidden_Outputs;

            for (int i = 0; i < OutputNodes; i++)
            {
                Final_Outputs.TheMatrix[i, 0] = ActivationFunction(Final_Inputs.TheMatrix[i, 0]);
            }

            return Final_Outputs;
        }

        public double ActivationFunction(double x)
        {
            return Functions.Sigmoid(x);
        }
    }
}
