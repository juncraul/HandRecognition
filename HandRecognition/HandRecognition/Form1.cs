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
using Mathematics;
using System.IO;

namespace HandRecognition
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Network network;

        List<string> trainings;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
            trainings = new List<string>();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);


            network = new Network();
            network.InitializeNetwork(ApplicationSettings.InputNodes, ApplicationSettings.HiddenNodes, ApplicationSettings.OutputNodes, ApplicationSettings.LearningRate);
            
            

            //Matrix test = network.QueryNetwrok(new Matrix(3, 1) { TheMatrix = new double[3, 1] { { 3 }, { 2 }, { 1 } } });
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            StreamReader stream = new StreamReader(textBoxPath.Text);
            string line = "";
            while((line = stream.ReadLine()) != null)
            {
                trainings.Add(line);
            }

            foreach (string t in trainings)
            {
                Matrix inputMatrix = GetMatrix(t, true);
                int target = int.Parse(t.Substring(0, 1));
                Matrix targetMatrix = CreateTargetResult(target);

                network.TrainNetwrok(inputMatrix, targetMatrix);
            }
        }

        private void ButtonBrowse_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            textBoxPath.Text = openFileDialog1.FileName;
        }

        private void DrawArray(string line, bool excludFirstElement = false)
        {
            string[] values = (excludFirstElement ? line.Substring(2) : line ).Split(',');

            DrawArray(values);
        }
        
        private void DrawArray(string[] arr)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            brush.Color = Color.Red;
            graphics.FillRectangle(brush, 0, 0, 1000, 1000);

            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 28; j++)
                {
                    int value = 255 - int.Parse(arr[i * 28 + j]);
                    brush.Color = Color.FromArgb(value, value, value);
                    graphics.FillRectangle(brush, j * 10, i * 10, 10, 10);
                }
            pictureBox1.Image = bitmap;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Matrix mat = network.QueryNetwrok(GetMatrix(trainings[index], true));
            DrawArray(trainings[index++], true);

            MessageBox.Show(mat.ToString());
        }

        private double ScaleInput(int value)
        {
            return value / 255.0 * 0.99 + 0.01;
        }

        private Matrix CreateTargetResult(int number)
        {
            Matrix temp = new Matrix(10, 1);

            for(int i = 0; i < 10; i ++)
            {
                if(number == i)
                {
                    temp.TheMatrix[i, 0] = 0.99;
                }
                else
                {
                    temp.TheMatrix[i, 0] = 0.01;
                }
            }

            return temp;
        }

        private Matrix GetMatrix(string line, bool excludFirstElement = false)
        {
            Matrix temp = new Matrix(28 * 28, 1);
            string[] values = (excludFirstElement ? line.Substring(2) : line).Split(',');

            for (int i = 0; i < 28; i++)
                for (int j = 0; j < 28; j++)
                    temp.TheMatrix[28 * i + j, 0] = ScaleInput(255 - int.Parse(values[28 * i + j]));

            return temp;
        }
    }
}
