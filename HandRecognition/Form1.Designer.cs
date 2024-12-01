namespace HandRecognition
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.textBoxPathTrain = new System.Windows.Forms.TextBox();
            this.ButtonBrowseTrain = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBrowseTest = new System.Windows.Forms.Button();
            this.textBoxPathTest = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 323);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(375, 255);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(75, 23);
            this.buttonTrain.TabIndex = 1;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // textBoxPathTrain
            // 
            this.textBoxPathTrain.Location = new System.Drawing.Point(375, 15);
            this.textBoxPathTrain.Name = "textBoxPathTrain";
            this.textBoxPathTrain.Size = new System.Drawing.Size(436, 20);
            this.textBoxPathTrain.TabIndex = 2;
            this.textBoxPathTrain.Text = "D:\\Programming\\Resources\\Neural Network training_tests\\mnist_train_100.csv";
            // 
            // ButtonBrowseTrain
            // 
            this.ButtonBrowseTrain.Location = new System.Drawing.Point(817, 15);
            this.ButtonBrowseTrain.Name = "ButtonBrowseTrain";
            this.ButtonBrowseTrain.Size = new System.Drawing.Size(119, 23);
            this.ButtonBrowseTrain.TabIndex = 3;
            this.ButtonBrowseTrain.Text = "Browse Train";
            this.ButtonBrowseTrain.UseVisualStyleBackColor = true;
            this.ButtonBrowseTrain.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(510, 255);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonBrowseTest
            // 
            this.buttonBrowseTest.Location = new System.Drawing.Point(817, 44);
            this.buttonBrowseTest.Name = "buttonBrowseTest";
            this.buttonBrowseTest.Size = new System.Drawing.Size(119, 23);
            this.buttonBrowseTest.TabIndex = 6;
            this.buttonBrowseTest.Text = "Browse Test";
            this.buttonBrowseTest.UseVisualStyleBackColor = true;
            this.buttonBrowseTest.Click += new System.EventHandler(this.buttonBrowseTest_Click);
            // 
            // textBoxPathTest
            // 
            this.textBoxPathTest.Location = new System.Drawing.Point(375, 46);
            this.textBoxPathTest.Name = "textBoxPathTest";
            this.textBoxPathTest.Size = new System.Drawing.Size(436, 20);
            this.textBoxPathTest.TabIndex = 5;
            this.textBoxPathTest.Text = "D:\\Programming\\Resources\\Neural Network training_tests\\mnist_test_10.csv";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(376, 285);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 7;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(817, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Test small network";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 522);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonBrowseTest);
            this.Controls.Add(this.textBoxPathTest);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.ButtonBrowseTrain);
            this.Controls.Add(this.textBoxPathTrain);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.TextBox textBoxPathTrain;
        private System.Windows.Forms.Button ButtonBrowseTrain;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonBrowseTest;
        private System.Windows.Forms.TextBox textBoxPathTest;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button button1;
    }
}

