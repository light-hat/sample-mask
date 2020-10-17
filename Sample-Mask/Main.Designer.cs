namespace Sample_Mask
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openPathTextBox = new System.Windows.Forms.TextBox();
            this.opentbLabel = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.savetbLabel = new System.Windows.Forms.Label();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.fileInfoGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentFileName = new System.Windows.Forms.Label();
            this.currentFileFormat = new System.Windows.Forms.Label();
            this.currentSamRate = new System.Windows.Forms.Label();
            this.currentPCM = new System.Windows.Forms.Label();
            this.currentNumOfCh = new System.Windows.Forms.Label();
            this.currentDuration = new System.Windows.Forms.Label();
            this.fileInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // openPathTextBox
            // 
            resources.ApplyResources(this.openPathTextBox, "openPathTextBox");
            this.openPathTextBox.Name = "openPathTextBox";
            this.openPathTextBox.ReadOnly = true;
            // 
            // opentbLabel
            // 
            resources.ApplyResources(this.opentbLabel, "opentbLabel");
            this.opentbLabel.Name = "opentbLabel";
            // 
            // openButton
            // 
            resources.ApplyResources(this.openButton, "openButton");
            this.openButton.Name = "openButton";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // savetbLabel
            // 
            resources.ApplyResources(this.savetbLabel, "savetbLabel");
            this.savetbLabel.Name = "savetbLabel";
            // 
            // savePathTextBox
            // 
            resources.ApplyResources(this.savePathTextBox, "savePathTextBox");
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.ReadOnly = true;
            // 
            // fileInfoGroup
            // 
            resources.ApplyResources(this.fileInfoGroup, "fileInfoGroup");
            this.fileInfoGroup.Controls.Add(this.currentDuration);
            this.fileInfoGroup.Controls.Add(this.currentNumOfCh);
            this.fileInfoGroup.Controls.Add(this.currentPCM);
            this.fileInfoGroup.Controls.Add(this.currentSamRate);
            this.fileInfoGroup.Controls.Add(this.currentFileFormat);
            this.fileInfoGroup.Controls.Add(this.currentFileName);
            this.fileInfoGroup.Controls.Add(this.label6);
            this.fileInfoGroup.Controls.Add(this.label5);
            this.fileInfoGroup.Controls.Add(this.label4);
            this.fileInfoGroup.Controls.Add(this.label3);
            this.fileInfoGroup.Controls.Add(this.label2);
            this.fileInfoGroup.Controls.Add(this.label1);
            this.fileInfoGroup.Name = "fileInfoGroup";
            this.fileInfoGroup.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // currentFileName
            // 
            resources.ApplyResources(this.currentFileName, "currentFileName");
            this.currentFileName.Name = "currentFileName";
            // 
            // currentFileFormat
            // 
            resources.ApplyResources(this.currentFileFormat, "currentFileFormat");
            this.currentFileFormat.Name = "currentFileFormat";
            // 
            // currentSamRate
            // 
            resources.ApplyResources(this.currentSamRate, "currentSamRate");
            this.currentSamRate.Name = "currentSamRate";
            // 
            // currentPCM
            // 
            resources.ApplyResources(this.currentPCM, "currentPCM");
            this.currentPCM.Name = "currentPCM";
            // 
            // currentNumOfCh
            // 
            resources.ApplyResources(this.currentNumOfCh, "currentNumOfCh");
            this.currentNumOfCh.Name = "currentNumOfCh";
            // 
            // currentDuration
            // 
            resources.ApplyResources(this.currentDuration, "currentDuration");
            this.currentDuration.Name = "currentDuration";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileInfoGroup);
            this.Controls.Add(this.savePathTextBox);
            this.Controls.Add(this.savetbLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.opentbLabel);
            this.Controls.Add(this.openPathTextBox);
            this.Name = "Main";
            this.fileInfoGroup.ResumeLayout(false);
            this.fileInfoGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox openPathTextBox;
        private System.Windows.Forms.Label opentbLabel;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label savetbLabel;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.GroupBox fileInfoGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentDuration;
        private System.Windows.Forms.Label currentNumOfCh;
        private System.Windows.Forms.Label currentPCM;
        private System.Windows.Forms.Label currentSamRate;
        private System.Windows.Forms.Label currentFileFormat;
        private System.Windows.Forms.Label currentFileName;
        private System.Windows.Forms.Label label6;
    }
}

