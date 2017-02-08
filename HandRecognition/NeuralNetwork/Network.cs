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

        public void TrainNetwrok()
        {
            
        }

        public Matrix QueryNetwrok(Matrix Inputs)
        {
            Hidden_Inputs = Winput_hidden * Inputs;

            for (int i = 0; i < HiddenNodes; i++)
            {
                Hidden_Outputs.TheMatrix[i, 0] = ActivationFunction(Hidden_Inputs.TheMatrix[i, 0]);
            }

            Final_Inputs = Whidden_output * Hidden_Outputs;

            for (int i = 0; i < HiddenNodes; i++)
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
