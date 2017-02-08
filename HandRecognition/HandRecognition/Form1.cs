using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork;

namespace HandRecognition
{
    public partial class Form1 : Form
    {
        Network network;

        public Form1()
        {
            InitializeComponent();

            network = new Network();
            network.InitializeNetwork(ApplicationSettings.InputNodes, ApplicationSettings.HiddenNodes, ApplicationSettings.OutputNodes, ApplicationSettings.LearningRate);
        }
    }
}
