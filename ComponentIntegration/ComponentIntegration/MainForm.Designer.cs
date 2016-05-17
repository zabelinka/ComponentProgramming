namespace ComponentIntegration
{
    partial class MainForm
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
            this.integralLBL = new System.Windows.Forms.Label();
            this.dxLBL = new System.Windows.Forms.Label();
            this.functionTB = new System.Windows.Forms.TextBox();
            this.epsTB = new System.Windows.Forms.TextBox();
            this.upperLimitTB = new System.Windows.Forms.TextBox();
            this.lowerLimitTB = new System.Windows.Forms.TextBox();
            this.epsLBL = new System.Windows.Forms.Label();
            this.radioButtonsGroup = new System.Windows.Forms.GroupBox();
            this.allVariantsRB = new System.Windows.Forms.RadioButton();
            this.simpsonRB = new System.Windows.Forms.RadioButton();
            this.trapezeRB = new System.Windows.Forms.RadioButton();
            this.rectangleRB = new System.Windows.Forms.RadioButton();
            this.answerTB = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.titleLBL = new System.Windows.Forms.Label();
            this.radioButtonsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // integralLBL
            // 
            this.integralLBL.AutoSize = true;
            this.integralLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.integralLBL.Location = new System.Drawing.Point(37, 81);
            this.integralLBL.Name = "integralLBL";
            this.integralLBL.Size = new System.Drawing.Size(26, 39);
            this.integralLBL.TabIndex = 0;
            this.integralLBL.Text = "∫";
            // 
            // dxLBL
            // 
            this.dxLBL.AutoSize = true;
            this.dxLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dxLBL.Location = new System.Drawing.Point(340, 89);
            this.dxLBL.Name = "dxLBL";
            this.dxLBL.Size = new System.Drawing.Size(42, 31);
            this.dxLBL.TabIndex = 0;
            this.dxLBL.Text = "dx";
            // 
            // functionTB
            // 
            this.functionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionTB.Location = new System.Drawing.Point(72, 88);
            this.functionTB.Name = "functionTB";
            this.functionTB.Size = new System.Drawing.Size(271, 30);
            this.functionTB.TabIndex = 1;
            this.functionTB.TextChanged += new System.EventHandler(this.functionTB_TextChanged);
            // 
            // epsTB
            // 
            this.epsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epsTB.Location = new System.Drawing.Point(108, 149);
            this.epsTB.Name = "epsTB";
            this.epsTB.Size = new System.Drawing.Size(95, 30);
            this.epsTB.TabIndex = 3;
            // 
            // upperLimitTB
            // 
            this.upperLimitTB.Location = new System.Drawing.Point(30, 67);
            this.upperLimitTB.Name = "upperLimitTB";
            this.upperLimitTB.Size = new System.Drawing.Size(39, 20);
            this.upperLimitTB.TabIndex = 3;
            // 
            // lowerLimitTB
            // 
            this.lowerLimitTB.Location = new System.Drawing.Point(30, 123);
            this.lowerLimitTB.Name = "lowerLimitTB";
            this.lowerLimitTB.Size = new System.Drawing.Size(39, 20);
            this.lowerLimitTB.TabIndex = 3;
            // 
            // epsLBL
            // 
            this.epsLBL.AutoSize = true;
            this.epsLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epsLBL.Location = new System.Drawing.Point(24, 146);
            this.epsLBL.Name = "epsLBL";
            this.epsLBL.Size = new System.Drawing.Size(84, 31);
            this.epsLBL.TabIndex = 0;
            this.epsLBL.Text = "Eps =";
            // 
            // radioButtonsGroup
            // 
            this.radioButtonsGroup.Controls.Add(this.allVariantsRB);
            this.radioButtonsGroup.Controls.Add(this.simpsonRB);
            this.radioButtonsGroup.Controls.Add(this.trapezeRB);
            this.radioButtonsGroup.Controls.Add(this.rectangleRB);
            this.radioButtonsGroup.Location = new System.Drawing.Point(30, 180);
            this.radioButtonsGroup.Name = "radioButtonsGroup";
            this.radioButtonsGroup.Size = new System.Drawing.Size(173, 115);
            this.radioButtonsGroup.TabIndex = 4;
            this.radioButtonsGroup.TabStop = false;
            // 
            // allVariantsRB
            // 
            this.allVariantsRB.AutoSize = true;
            this.allVariantsRB.Location = new System.Drawing.Point(11, 88);
            this.allVariantsRB.Name = "allVariantsRB";
            this.allVariantsRB.Size = new System.Drawing.Size(86, 17);
            this.allVariantsRB.TabIndex = 0;
            this.allVariantsRB.TabStop = true;
            this.allVariantsRB.Text = "Все методы";
            this.allVariantsRB.UseVisualStyleBackColor = true;
            this.allVariantsRB.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // simpsonRB
            // 
            this.simpsonRB.AutoSize = true;
            this.simpsonRB.Location = new System.Drawing.Point(11, 65);
            this.simpsonRB.Name = "simpsonRB";
            this.simpsonRB.Size = new System.Drawing.Size(111, 17);
            this.simpsonRB.TabIndex = 0;
            this.simpsonRB.TabStop = true;
            this.simpsonRB.Text = "Метод Симпсона";
            this.simpsonRB.UseVisualStyleBackColor = true;
            this.simpsonRB.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // trapezeRB
            // 
            this.trapezeRB.AutoSize = true;
            this.trapezeRB.Location = new System.Drawing.Point(11, 42);
            this.trapezeRB.Name = "trapezeRB";
            this.trapezeRB.Size = new System.Drawing.Size(107, 17);
            this.trapezeRB.TabIndex = 0;
            this.trapezeRB.TabStop = true;
            this.trapezeRB.Text = "Метод трапеций";
            this.trapezeRB.UseVisualStyleBackColor = true;
            this.trapezeRB.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rectangleRB
            // 
            this.rectangleRB.AutoSize = true;
            this.rectangleRB.Location = new System.Drawing.Point(11, 18);
            this.rectangleRB.Name = "rectangleRB";
            this.rectangleRB.Size = new System.Drawing.Size(150, 17);
            this.rectangleRB.TabIndex = 0;
            this.rectangleRB.TabStop = true;
            this.rectangleRB.Text = "Метод прямоугольников";
            this.rectangleRB.UseVisualStyleBackColor = true;
            this.rectangleRB.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // answerTB
            // 
            this.answerTB.Location = new System.Drawing.Point(209, 189);
            this.answerTB.Multiline = true;
            this.answerTB.Name = "answerTB";
            this.answerTB.ReadOnly = true;
            this.answerTB.Size = new System.Drawing.Size(173, 106);
            this.answerTB.TabIndex = 3;
            // 
            // goButton
            // 
            this.goButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goButton.Location = new System.Drawing.Point(141, 302);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(134, 35);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Посчитать!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // titleLBL
            // 
            this.titleLBL.AutoSize = true;
            this.titleLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLBL.Location = new System.Drawing.Point(30, 25);
            this.titleLBL.Name = "titleLBL";
            this.titleLBL.Size = new System.Drawing.Size(337, 25);
            this.titleLBL.TabIndex = 6;
            this.titleLBL.Text = "Введите функцию вида ax*ln(bx+c)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 349);
            this.Controls.Add(this.titleLBL);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.radioButtonsGroup);
            this.Controls.Add(this.lowerLimitTB);
            this.Controls.Add(this.upperLimitTB);
            this.Controls.Add(this.answerTB);
            this.Controls.Add(this.epsTB);
            this.Controls.Add(this.functionTB);
            this.Controls.Add(this.epsLBL);
            this.Controls.Add(this.dxLBL);
            this.Controls.Add(this.integralLBL);
            this.Name = "MainForm";
            this.Text = "Численное интегрирование";
            this.radioButtonsGroup.ResumeLayout(false);
            this.radioButtonsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label integralLBL;
        private System.Windows.Forms.Label dxLBL;
        private System.Windows.Forms.TextBox functionTB;
        private System.Windows.Forms.TextBox epsTB;
        private System.Windows.Forms.TextBox upperLimitTB;
        private System.Windows.Forms.TextBox lowerLimitTB;
        private System.Windows.Forms.Label epsLBL;
        private System.Windows.Forms.GroupBox radioButtonsGroup;
        private System.Windows.Forms.RadioButton allVariantsRB;
        private System.Windows.Forms.RadioButton simpsonRB;
        private System.Windows.Forms.RadioButton trapezeRB;
        private System.Windows.Forms.RadioButton rectangleRB;
        private System.Windows.Forms.TextBox answerTB;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label titleLBL;
    }
}

