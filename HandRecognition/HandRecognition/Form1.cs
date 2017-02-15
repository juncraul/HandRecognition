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
using System.Runtime.InteropServices;

namespace HandRecognition
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Network network;

        List<string> trainings;
        List<string> tests;
        int index = 0;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
            trainings = new List<string>();
            tests = new List<string>();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            AllocConsole();

            //MatrixTest();
            //MatrixTestAdd();

            network = new Network();
            network.InitializeNetwork(ApplicationSettings.InputNodes, ApplicationSettings.HiddenNodes, ApplicationSettings.OutputNodes, ApplicationSettings.LearningRate);
        }

        private void DrawArray(string line, bool excludFirstElement = false)
        {
            string[] values = (excludFirstElement ? line.Substring(2) : line).Split(',');

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

            for (int i = 0; i < 10; i++)
            {
                if (number == i)
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
                    temp.TheMatrix[28 * i + j, 0] = ScaleInput(int.Parse(values[28 * i + j]));

            return temp;
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            int count = 0;
            StreamReader stream = new StreamReader(textBoxPathTrain.Text);
            string line = "";
            while ((line = stream.ReadLine()) != null)
            {
                trainings.Add(line);
            }

            foreach (string t in trainings)
            {
                Matrix inputMatrix = GetMatrix(t, true);
                int target = int.Parse(t.Substring(0, 1));
                Matrix targetMatrix = CreateTargetResult(target);

                network.TrainNetwrok(inputMatrix, targetMatrix);
                count++;


                if (count % 200 == 0)
                    Console.WriteLine("Trains conducted so far: " + count);

                if (count > 10000)
                    break;
            }
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxPathTrain.Text = openFileDialog1.FileName;
        }

        private void MatrixTest()
        {
            Matrix a = new Matrix(2, 3);
            Matrix b = new Matrix(3, 2);

            a.TheMatrix[0, 0] = 1;
            a.TheMatrix[0, 1] = 2;
            a.TheMatrix[0, 2] = 3;
            a.TheMatrix[1, 0] = 4;
            a.TheMatrix[1, 1] = 5;
            a.TheMatrix[1, 2] = 6;

            b.TheMatrix[0, 0] = 7;
            b.TheMatrix[0, 1] = 8;
            b.TheMatrix[1, 0] = 9;
            b.TheMatrix[1, 1] = 10;
            b.TheMatrix[2, 0] = 11;
            b.TheMatrix[2, 1] = 12;

            MessageBox.Show((a * b).ToString());
        }

        private void MatrixTestAdd()
        {
            Matrix a = new Matrix(2, 2);
            Matrix b = new Matrix(2, 2);

            a.TheMatrix[0, 0] = 1;
            a.TheMatrix[0, 1] = 2;
            a.TheMatrix[1, 0] = 4;
            a.TheMatrix[1, 1] = 5;

            b.TheMatrix[0, 0] = 7;
            b.TheMatrix[0, 1] = 8;
            b.TheMatrix[1, 0] = 9;
            b.TheMatrix[1, 1] = 10;

            MessageBox.Show((a + b).ToString());
        }

        private void buttonBrowseTest_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxPathTest.Text = openFileDialog1.FileName;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            int total = 0;
            int correct = 0;
            StreamReader stream = new StreamReader(textBoxPathTest.Text);
            string line = "";
            while ((line = stream.ReadLine()) != null)
            {
                tests.Add(line);
            }

            foreach (string s in tests)
            {
                Matrix inputMatrix = GetMatrix(s, true);
                int target = int.Parse(s.Substring(0, 1));
                Matrix targetMatrix = CreateTargetResult(target);

                Matrix mat = network.QueryNetwrok(inputMatrix);
                int actualValue = mat.GetMaxValueIndex();
                total++;
                correct += target == actualValue ? 1 : 0;

                if(total % 200 == 0)
                Console.WriteLine("Tests conducted so far: " + total);
            }

            Console.WriteLine("Total Tests: " + total);
            Console.WriteLine("Total Correct Results: " + correct);
            Console.WriteLine( ((float)correct/total * 100) + "% match rate");

        }
    }
}