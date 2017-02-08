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

        public void InitializeNetwork(int inputNodes, int hiddenNodes, int outputNodes, float learningRate)
        {
            InputNodes = inputNodes;
            HiddenNodes = hiddenNodes;
            OutputNodes = outputNodes;
            LearningRate = learningRate;

            Winput_hidden = new Matrix(HiddenNodes, InputNodes);
            Winput_hidden.GenerateRandomValuesBetween(-Math.Pow(HiddenNodes, -0.5), Math.Pow(HiddenNodes, -0.5));
            Whidden_output = new Matrix(OutputNodes, HiddenNodes);
            Whidden_output.GenerateRandomValuesBetween(-Math.Pow(OutputNodes, -0.5), Math.Pow(OutputNodes, -0.5));
        }

        public void TrainNetwrok()
        {
            
        }

        public void QueryNetwrok()
        {

        }
    }
}
