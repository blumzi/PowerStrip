namespace ASCOM.IPPower9258
{
    partial class SetupDialogForm
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.textIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.labelSwitch1 = new System.Windows.Forms.Label();
            this.switchName0 = new System.Windows.Forms.TextBox();
            this.switchDesc0 = new System.Windows.Forms.TextBox();
            this.switchDesc1 = new System.Windows.Forms.TextBox();
            this.switchName1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.switchDesc2 = new System.Windows.Forms.TextBox();
            this.switchName2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.switchDesc3 = new System.Windows.Forms.TextBox();
            this.switchName3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(494, 203);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(494, 234);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 25);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "IPPower9258 Setup";
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.IPPower9258.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(507, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // textIPAddress
            // 
            this.textIPAddress.Location = new System.Drawing.Point(96, 66);
            this.textIPAddress.Name = "textIPAddress";
            this.textIPAddress.Size = new System.Drawing.Size(158, 20);
            this.textIPAddress.TabIndex = 1;
            this.textIPAddress.Leave += new System.EventHandler(this.textIPAddress_TextChanged);
            this.textIPAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textIPAddress_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP Address";
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(308, 65);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(69, 17);
            this.chkTrace.TabIndex = 12;
            this.chkTrace.Text = "Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // labelSwitch1
            // 
            this.labelSwitch1.AutoSize = true;
            this.labelSwitch1.Location = new System.Drawing.Point(5, 7);
            this.labelSwitch1.Name = "labelSwitch1";
            this.labelSwitch1.Size = new System.Drawing.Size(30, 13);
            this.labelSwitch1.TabIndex = 7;
            this.labelSwitch1.Text = "Out1";
            // 
            // switchName0
            // 
            this.switchName0.Location = new System.Drawing.Point(41, 3);
            this.switchName0.Name = "switchName0";
            this.switchName0.Size = new System.Drawing.Size(81, 20);
            this.switchName0.TabIndex = 2;
            this.switchName0.TextChanged += new System.EventHandler(this.switchName_TextChanged);
            // 
            // switchDesc0
            // 
            this.switchDesc0.Location = new System.Drawing.Point(128, 3);
            this.switchDesc0.Name = "switchDesc0";
            this.switchDesc0.Size = new System.Drawing.Size(304, 20);
            this.switchDesc0.TabIndex = 3;
            this.switchDesc0.TextChanged += new System.EventHandler(this.switchDescription_TextChanged);
            // 
            // switchDesc1
            // 
            this.switchDesc1.Location = new System.Drawing.Point(128, 5);
            this.switchDesc1.Name = "switchDesc1";
            this.switchDesc1.Size = new System.Drawing.Size(304, 20);
            this.switchDesc1.TabIndex = 5;
            this.switchDesc1.TextChanged += new System.EventHandler(this.switchDescription_TextChanged);
            // 
            // switchName1
            // 
            this.switchName1.Location = new System.Drawing.Point(41, 5);
            this.switchName1.Name = "switchName1";
            this.switchName1.Size = new System.Drawing.Size(81, 20);
            this.switchName1.TabIndex = 4;
            this.switchName1.TextChanged += new System.EventHandler(this.switchName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Out2";
            // 
            // switchDesc2
            // 
            this.switchDesc2.Location = new System.Drawing.Point(128, 3);
            this.switchDesc2.Name = "switchDesc2";
            this.switchDesc2.Size = new System.Drawing.Size(304, 20);
            this.switchDesc2.TabIndex = 7;
            this.switchDesc2.TextChanged += new System.EventHandler(this.switchDescription_TextChanged);
            // 
            // switchName2
            // 
            this.switchName2.Location = new System.Drawing.Point(41, 3);
            this.switchName2.Name = "switchName2";
            this.switchName2.Size = new System.Drawing.Size(81, 20);
            this.switchName2.TabIndex = 6;
            this.switchName2.TextChanged += new System.EventHandler(this.switchName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Out3";
            // 
            // switchDesc3
            // 
            this.switchDesc3.Location = new System.Drawing.Point(128, 3);
            this.switchDesc3.Name = "switchDesc3";
            this.switchDesc3.Size = new System.Drawing.Size(304, 20);
            this.switchDesc3.TabIndex = 9;
            this.switchDesc3.TextChanged += new System.EventHandler(this.switchDescription_TextChanged);
            // 
            // switchName3
            // 
            this.switchName3.Location = new System.Drawing.Point(41, 3);
            this.switchName3.Name = "switchName3";
            this.switchName3.Size = new System.Drawing.Size(81, 20);
            this.switchName3.TabIndex = 8;
            this.switchName3.TextChanged += new System.EventHandler(this.switchName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Out4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(137, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Label";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.switchName3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.switchDesc3);
            this.panel1.Location = new System.Drawing.Point(12, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 27);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.switchDesc2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.switchName2);
            this.panel2.Location = new System.Drawing.Point(12, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 27);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.switchDesc1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.switchName1);
            this.panel3.Location = new System.Drawing.Point(12, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 29);
            this.panel3.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.switchDesc0);
            this.panel4.Controls.Add(this.labelSwitch1);
            this.panel4.Controls.Add(this.switchName0);
            this.panel4.Location = new System.Drawing.Point(12, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(441, 26);
            this.panel4.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(15, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 174);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Switches ";
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textIPAddress);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPPower9258 Setup";
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.TextBox textIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.Label labelSwitch1;
        private System.Windows.Forms.TextBox switchName0;
        private System.Windows.Forms.TextBox switchDesc0;
        private System.Windows.Forms.TextBox switchDesc1;
        private System.Windows.Forms.TextBox switchName1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox switchDesc2;
        private System.Windows.Forms.TextBox switchName2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox switchDesc3;
        private System.Windows.Forms.TextBox switchName3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}