﻿namespace RaspberryPiClient
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.xBar = new System.Windows.Forms.TrackBar();
            this.yBar = new System.Windows.Forms.TrackBar();
            this.rollBar = new System.Windows.Forms.TrackBar();
            this.pitchBar = new System.Windows.Forms.TrackBar();
            this.headingBar = new System.Windows.Forms.TrackBar();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.altBar = new System.Windows.Forms.TrackBar();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.vsBar = new System.Windows.Forms.TrackBar();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.b737PFD1 = new RaspberryPiClient.MyPannel.B737PFD.B737PFD();
            ((System.ComponentModel.ISupportInitialize)(this.xBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.altBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.MainForm_Load);
            // 
            // xBar
            // 
            this.xBar.Location = new System.Drawing.Point(104, 636);
            this.xBar.Maximum = 1000;
            this.xBar.Minimum = -1000;
            this.xBar.Name = "xBar";
            this.xBar.Size = new System.Drawing.Size(495, 45);
            this.xBar.TabIndex = 1;
            this.xBar.Scroll += new System.EventHandler(this.xBar_Scroll);
            // 
            // yBar
            // 
            this.yBar.Location = new System.Drawing.Point(104, 698);
            this.yBar.Maximum = 1000;
            this.yBar.Minimum = -1000;
            this.yBar.Name = "yBar";
            this.yBar.Size = new System.Drawing.Size(495, 45);
            this.yBar.TabIndex = 2;
            this.yBar.Scroll += new System.EventHandler(this.yBar_Scroll);
            // 
            // rollBar
            // 
            this.rollBar.Location = new System.Drawing.Point(744, 72);
            this.rollBar.Maximum = 180;
            this.rollBar.Minimum = -180;
            this.rollBar.Name = "rollBar";
            this.rollBar.Size = new System.Drawing.Size(495, 45);
            this.rollBar.TabIndex = 3;
            this.rollBar.Scroll += new System.EventHandler(this.rollBar_Scroll);
            // 
            // pitchBar
            // 
            this.pitchBar.Location = new System.Drawing.Point(744, 155);
            this.pitchBar.Maximum = 180;
            this.pitchBar.Minimum = -180;
            this.pitchBar.Name = "pitchBar";
            this.pitchBar.Size = new System.Drawing.Size(495, 45);
            this.pitchBar.TabIndex = 4;
            this.pitchBar.Scroll += new System.EventHandler(this.pitchBar_Scroll);
            // 
            // headingBar
            // 
            this.headingBar.Location = new System.Drawing.Point(755, 269);
            this.headingBar.Maximum = 360;
            this.headingBar.Name = "headingBar";
            this.headingBar.Size = new System.Drawing.Size(495, 45);
            this.headingBar.TabIndex = 5;
            this.headingBar.Scroll += new System.EventHandler(this.headingBar_Scroll);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(755, 391);
            this.speedBar.Maximum = 400;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(495, 45);
            this.speedBar.TabIndex = 6;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(675, 648);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(665, 698);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1289, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1289, 155);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1289, 269);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 11;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1289, 391);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 12;
            // 
            // altBar
            // 
            this.altBar.Location = new System.Drawing.Point(755, 493);
            this.altBar.Maximum = 10000;
            this.altBar.Name = "altBar";
            this.altBar.Size = new System.Drawing.Size(495, 45);
            this.altBar.TabIndex = 13;
            this.altBar.Scroll += new System.EventHandler(this.altBar_Scroll);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(1299, 493);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 14;
            // 
            // vsBar
            // 
            this.vsBar.Location = new System.Drawing.Point(755, 557);
            this.vsBar.Maximum = 60;
            this.vsBar.Minimum = -60;
            this.vsBar.Name = "vsBar";
            this.vsBar.Size = new System.Drawing.Size(495, 45);
            this.vsBar.TabIndex = 15;
            this.vsBar.Scroll += new System.EventHandler(this.vsBar_Scroll);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1299, 557);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 21);
            this.textBox8.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "roll";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "pitch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(759, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "heading";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(776, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(782, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "alt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(776, 526);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "vs";
            // 
            // b737PFD1
            // 
            this.b737PFD1.Location = new System.Drawing.Point(104, 93);
            this.b737PFD1.Name = "b737PFD1";
            this.b737PFD1.Size = new System.Drawing.Size(442, 407);
            this.b737PFD1.TabIndex = 24;
            this.b737PFD1.Text = "b737PFD1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 833);
            this.Controls.Add(this.b737PFD1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.vsBar);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.altBar);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.headingBar);
            this.Controls.Add(this.pitchBar);
            this.Controls.Add(this.rollBar);
            this.Controls.Add(this.yBar);
            this.Controls.Add(this.xBar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rollBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.altBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar xBar;
        private System.Windows.Forms.TrackBar yBar;
        private System.Windows.Forms.TrackBar rollBar;
        private System.Windows.Forms.TrackBar pitchBar;
        private System.Windows.Forms.TrackBar headingBar;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TrackBar altBar;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TrackBar vsBar;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private MyPannel.B737PFD.B737PFD b737PFD1;
    }
}