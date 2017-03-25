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

            MessageBox.Show("If output window doesn't show anything, then one problem could be that you use VS2017");

            textBoxPathTrain.Text = @"..\..\Resources\mnist_train_6000.csv";
            textBoxPathTest.Text = @"..\..\Resources\mnist_test_1000.csv";

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
            }
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxPathTrain.Text = openFileDialog1.FileName;
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

                if (total % 200 == 0)
                    Console.WriteLine("Tests conducted so far: " + total);
            }

            Console.WriteLine("Total Tests: " + total);
            Console.WriteLine("Total Correct Results: " + correct);
            Console.WriteLine(((float)correct / total * 100) + "% match rate");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Network n = new Network();
            n.InitializeNetwork(3, 4, 1, 0.3f);

            for (int i = 0; i < 60000; i++)
            {
                Matrix inputMatrix1 = new Matrix(3, 1);
                inputMatrix1.TheMatrix[0, 0] = 0.01f;
                inputMatrix1.TheMatrix[1, 0] = 0.01f;
                inputMatrix1.TheMatrix[2, 0] = 1;
                Matrix targetMatrix1 = new Matrix(1, 1);
                targetMatrix1.TheMatrix[0, 0] = 0;
                n.TrainNetwrok(inputMatrix1, targetMatrix1);

                Matrix inputMatrix2 = new Matrix(3, 1);
                inputMatrix2.TheMatrix[0, 0] = 0.01f;
                inputMatrix2.TheMatrix[1, 0] = 1;
                inputMatrix2.TheMatrix[2, 0] = 1;
                Matrix targetMatrix2 = new Matrix(1, 1);
                targetMatrix2.TheMatrix[0, 0] = 1;
                n.TrainNetwrok(inputMatrix2, targetMatrix2);

                Matrix inputMatrix3 = new Matrix(3, 1);
                inputMatrix3.TheMatrix[0, 0] = 1;
                inputMatrix3.TheMatrix[1, 0] = 0.01f;
                inputMatrix3.TheMatrix[2, 0] = 1;
                Matrix targetMatrix3 = new Matrix(1, 1);
                targetMatrix3.TheMatrix[0, 0] = 1;
                n.TrainNetwrok(inputMatrix3, targetMatrix3);

                Matrix inputMatrix4 = new Matrix(3, 1);
                inputMatrix4.TheMatrix[0, 0] = 1;
                inputMatrix4.TheMatrix[1, 0] = 1;
                inputMatrix4.TheMatrix[2, 0] = 1;
                Matrix targetMatrix4 = new Matrix(1, 1);
                targetMatrix4.TheMatrix[0, 0] = 0;
                n.TrainNetwrok(inputMatrix4, targetMatrix4);

                if (i % 100 == 0)
                {
                    double error = 0;
                    double output;
                    output = n.QueryNetwrok(inputMatrix1).TheMatrix[0, 0];
                    error += Math.Abs(output - targetMatrix1.TheMatrix[0, 0]);

                    output = n.QueryNetwrok(inputMatrix2).TheMatrix[0, 0];
                    error += Math.Abs(output - targetMatrix2.TheMatrix[0, 0]);

                    output = n.QueryNetwrok(inputMatrix3).TheMatrix[0, 0];
                    error += Math.Abs(output - targetMatrix3.TheMatrix[0, 0]);

                    output = n.QueryNetwrok(inputMatrix4).TheMatrix[0, 0];
                    error += Math.Abs(output - targetMatrix4.TheMatrix[0, 0]);

                    Console.WriteLine(error);
                }
            }
        }

        bool drawOnCanvas = false;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawOnCanvas) return;
            SolidBrush brush = new SolidBrush(Color.Black);
            graphics.FillRectangle(brush, e.X, e.Y, 10, 10);

            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            brush.Color = Color.Blue;
            graphics.FillRectangle(brush, 0, 0, 1000, 1000);
            drawOnCanvas = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawOnCanvas = false;

            if (pictureBox1.Image == null) return;
            string text = ReadCanvas();

            Matrix mat = network.QueryNetwrok(GetMatrix(text));
            DrawArray(text);

            mat.Max(out int maxi, out int maxj);
            MessageBox.Show(mat.ToString() + Environment.NewLine + "Your number is: " + maxi);
        }

        private string ReadCanvas()
        {
            string temp = "";
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    Color color = bitmap.GetPixel(j * 10, i * 10);
                    temp += color.B < 50 ? "255" : "0";
                    if (i != 27 || j != 27)
                    {
                        temp += ",";
                    }
                }
            }
            return temp;
        }
    }
}