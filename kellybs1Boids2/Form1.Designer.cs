namespace kellybs1Boids2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelDraw = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNeighbours = new System.Windows.Forms.Label();
            this.trackBarNeighbours = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSeparation = new System.Windows.Forms.Label();
            this.trackBarSeparation = new System.Windows.Forms.TrackBar();
            this.labelAlignmentVal = new System.Windows.Forms.Label();
            this.labelAlignment = new System.Windows.Forms.Label();
            this.trackBarAlignment = new System.Windows.Forms.TrackBar();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNeighbours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlignment)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDraw
            // 
            this.panelDraw.Controls.Add(this.label2);
            this.panelDraw.Controls.Add(this.labelNeighbours);
            this.panelDraw.Controls.Add(this.trackBarNeighbours);
            this.panelDraw.Controls.Add(this.label1);
            this.panelDraw.Controls.Add(this.labelSeparation);
            this.panelDraw.Controls.Add(this.trackBarSeparation);
            this.panelDraw.Controls.Add(this.labelAlignmentVal);
            this.panelDraw.Controls.Add(this.labelAlignment);
            this.panelDraw.Controls.Add(this.trackBarAlignment);
            this.panelDraw.Controls.Add(this.buttonMin);
            this.panelDraw.Controls.Add(this.buttonClose);
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(770, 473);
            this.panelDraw.TabIndex = 0;
            this.panelDraw.Click += new System.EventHandler(this.panelDraw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(655, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 10;
            // 
            // labelNeighbours
            // 
            this.labelNeighbours.AutoSize = true;
            this.labelNeighbours.BackColor = System.Drawing.Color.Black;
            this.labelNeighbours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNeighbours.ForeColor = System.Drawing.Color.White;
            this.labelNeighbours.Location = new System.Drawing.Point(554, 147);
            this.labelNeighbours.Name = "labelNeighbours";
            this.labelNeighbours.Size = new System.Drawing.Size(113, 20);
            this.labelNeighbours.TabIndex = 9;
            this.labelNeighbours.Text = "Range of sight";
            // 
            // trackBarNeighbours
            // 
            this.trackBarNeighbours.BackColor = System.Drawing.Color.White;
            this.trackBarNeighbours.LargeChange = 20;
            this.trackBarNeighbours.Location = new System.Drawing.Point(318, 170);
            this.trackBarNeighbours.Maximum = 500;
            this.trackBarNeighbours.Minimum = 10;
            this.trackBarNeighbours.Name = "trackBarNeighbours";
            this.trackBarNeighbours.Size = new System.Drawing.Size(420, 45);
            this.trackBarNeighbours.TabIndex = 8;
            this.trackBarNeighbours.Value = 34;
            this.trackBarNeighbours.Scroll += new System.EventHandler(this.trackBarNeighbours_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(655, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 7;
            // 
            // labelSeparation
            // 
            this.labelSeparation.AutoSize = true;
            this.labelSeparation.BackColor = System.Drawing.Color.Black;
            this.labelSeparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeparation.ForeColor = System.Drawing.Color.White;
            this.labelSeparation.Location = new System.Drawing.Point(554, 250);
            this.labelSeparation.Name = "labelSeparation";
            this.labelSeparation.Size = new System.Drawing.Size(87, 20);
            this.labelSeparation.TabIndex = 6;
            this.labelSeparation.Text = "Separation";
            // 
            // trackBarSeparation
            // 
            this.trackBarSeparation.BackColor = System.Drawing.Color.White;
            this.trackBarSeparation.LargeChange = 20;
            this.trackBarSeparation.Location = new System.Drawing.Point(318, 273);
            this.trackBarSeparation.Maximum = 200;
            this.trackBarSeparation.Minimum = 1;
            this.trackBarSeparation.Name = "trackBarSeparation";
            this.trackBarSeparation.Size = new System.Drawing.Size(420, 45);
            this.trackBarSeparation.SmallChange = 5;
            this.trackBarSeparation.TabIndex = 5;
            this.trackBarSeparation.Value = 25;
            this.trackBarSeparation.Scroll += new System.EventHandler(this.trackBarSeparation_Scroll);
            // 
            // labelAlignmentVal
            // 
            this.labelAlignmentVal.AutoSize = true;
            this.labelAlignmentVal.BackColor = System.Drawing.Color.Black;
            this.labelAlignmentVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlignmentVal.ForeColor = System.Drawing.Color.White;
            this.labelAlignmentVal.Location = new System.Drawing.Point(655, 352);
            this.labelAlignmentVal.Name = "labelAlignmentVal";
            this.labelAlignmentVal.Size = new System.Drawing.Size(0, 20);
            this.labelAlignmentVal.TabIndex = 4;
            // 
            // labelAlignment
            // 
            this.labelAlignment.AutoSize = true;
            this.labelAlignment.BackColor = System.Drawing.Color.Black;
            this.labelAlignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlignment.ForeColor = System.Drawing.Color.White;
            this.labelAlignment.Location = new System.Drawing.Point(554, 352);
            this.labelAlignment.Name = "labelAlignment";
            this.labelAlignment.Size = new System.Drawing.Size(80, 20);
            this.labelAlignment.TabIndex = 3;
            this.labelAlignment.Text = "Alignment";
            // 
            // trackBarAlignment
            // 
            this.trackBarAlignment.BackColor = System.Drawing.Color.White;
            this.trackBarAlignment.LargeChange = 500;
            this.trackBarAlignment.Location = new System.Drawing.Point(318, 375);
            this.trackBarAlignment.Maximum = 50000;
            this.trackBarAlignment.Minimum = 500;
            this.trackBarAlignment.Name = "trackBarAlignment";
            this.trackBarAlignment.Size = new System.Drawing.Size(420, 45);
            this.trackBarAlignment.SmallChange = 100;
            this.trackBarAlignment.TabIndex = 2;
            this.trackBarAlignment.Value = 6700;
            this.trackBarAlignment.Scroll += new System.EventHandler(this.trackBarAlignment_Scroll);
            // 
            // buttonMin
            // 
            this.buttonMin.BackColor = System.Drawing.Color.DarkRed;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMin.ForeColor = System.Drawing.Color.White;
            this.buttonMin.Location = new System.Drawing.Point(714, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(24, 24);
            this.buttonMin.TabIndex = 1;
            this.buttonMin.Text = "_";
            this.buttonMin.UseVisualStyleBackColor = false;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.DarkRed;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(744, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(24, 24);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 473);
            this.Controls.Add(this.panelDraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fush";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.panelDraw.ResumeLayout(false);
            this.panelDraw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNeighbours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlignment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.TrackBar trackBarAlignment;
        private System.Windows.Forms.Label labelAlignment;
        private System.Windows.Forms.Label labelAlignmentVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSeparation;
        private System.Windows.Forms.TrackBar trackBarSeparation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNeighbours;
        private System.Windows.Forms.TrackBar trackBarNeighbours;
    }
}

