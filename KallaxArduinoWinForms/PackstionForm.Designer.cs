namespace KallaxArduinoWinForms
{
    partial class PackstionForm
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
            packStationNamegroupBox = new GroupBox();
            doorStatusGroupBox = new GroupBox();
            statusLabel = new Label();
            collectYourPackagegroupBox = new GroupBox();
            packageNumberAndPassswordgroupBox = new GroupBox();
            packageNumbertextBox = new TextBox();
            collectButton = new Button();
            passwordtextBox = new TextBox();
            openContainerButton = new Button();
            packageListBox = new ListBox();
            userNumbergroupBox = new GroupBox();
            nextButton = new Button();
            userNumbertextBox = new TextBox();
            packStationNamegroupBox.SuspendLayout();
            doorStatusGroupBox.SuspendLayout();
            collectYourPackagegroupBox.SuspendLayout();
            packageNumberAndPassswordgroupBox.SuspendLayout();
            userNumbergroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // packStationNamegroupBox
            // 
            packStationNamegroupBox.Controls.Add(collectYourPackagegroupBox);
            packStationNamegroupBox.Controls.Add(doorStatusGroupBox);
            packStationNamegroupBox.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            packStationNamegroupBox.Location = new Point(12, 12);
            packStationNamegroupBox.Name = "packStationNamegroupBox";
            packStationNamegroupBox.Size = new Size(776, 426);
            packStationNamegroupBox.TabIndex = 1;
            packStationNamegroupBox.TabStop = false;
            packStationNamegroupBox.Text = "Packstation Name";
            // 
            // doorStatusGroupBox
            // 
            doorStatusGroupBox.Controls.Add(statusLabel);
            doorStatusGroupBox.Location = new Point(21, 28);
            doorStatusGroupBox.Name = "doorStatusGroupBox";
            doorStatusGroupBox.RightToLeft = RightToLeft.No;
            doorStatusGroupBox.Size = new Size(740, 375);
            doorStatusGroupBox.TabIndex = 4;
            doorStatusGroupBox.TabStop = false;
            doorStatusGroupBox.Text = "Door Status";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(353, 171);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 19);
            statusLabel.TabIndex = 2;
            // 
            // collectYourPackagegroupBox
            // 
            collectYourPackagegroupBox.Controls.Add(packageNumberAndPassswordgroupBox);
            collectYourPackagegroupBox.Controls.Add(openContainerButton);
            collectYourPackagegroupBox.Controls.Add(packageListBox);
            collectYourPackagegroupBox.Controls.Add(userNumbergroupBox);
            collectYourPackagegroupBox.Location = new Point(21, 28);
            collectYourPackagegroupBox.Name = "collectYourPackagegroupBox";
            collectYourPackagegroupBox.Size = new Size(740, 375);
            collectYourPackagegroupBox.TabIndex = 1;
            collectYourPackagegroupBox.TabStop = false;
            collectYourPackagegroupBox.Text = "Collect Your Package";
            // 
            // packageNumberAndPassswordgroupBox
            // 
            packageNumberAndPassswordgroupBox.Controls.Add(packageNumbertextBox);
            packageNumberAndPassswordgroupBox.Controls.Add(collectButton);
            packageNumberAndPassswordgroupBox.Controls.Add(passwordtextBox);
            packageNumberAndPassswordgroupBox.Location = new Point(28, 183);
            packageNumberAndPassswordgroupBox.Name = "packageNumberAndPassswordgroupBox";
            packageNumberAndPassswordgroupBox.Size = new Size(259, 143);
            packageNumberAndPassswordgroupBox.TabIndex = 3;
            packageNumberAndPassswordgroupBox.TabStop = false;
            packageNumberAndPassswordgroupBox.Text = "Package Number and Password";
            // 
            // packageNumbertextBox
            // 
            packageNumbertextBox.Location = new Point(28, 36);
            packageNumbertextBox.Name = "packageNumbertextBox";
            packageNumbertextBox.PlaceholderText = "Enter Your Package Number";
            packageNumbertextBox.Size = new Size(212, 27);
            packageNumbertextBox.TabIndex = 0;
            // 
            // collectButton
            // 
            collectButton.Location = new Point(84, 104);
            collectButton.Name = "collectButton";
            collectButton.Size = new Size(89, 32);
            collectButton.TabIndex = 2;
            collectButton.Text = "Collect";
            collectButton.UseVisualStyleBackColor = true;
            collectButton.Click += collectButton_Click;
            // 
            // passwordtextBox
            // 
            passwordtextBox.Location = new Point(28, 69);
            passwordtextBox.Name = "passwordtextBox";
            passwordtextBox.PlaceholderText = "Enter Your Password";
            passwordtextBox.Size = new Size(212, 27);
            passwordtextBox.TabIndex = 1;
            // 
            // openContainerButton
            // 
            openContainerButton.Location = new Point(539, 252);
            openContainerButton.Name = "openContainerButton";
            openContainerButton.Size = new Size(118, 61);
            openContainerButton.TabIndex = 2;
            openContainerButton.UseVisualStyleBackColor = true;
            openContainerButton.Click += openContainerButton_Click;
            // 
            // packageListBox
            // 
            packageListBox.FormattingEnabled = true;
            packageListBox.ItemHeight = 19;
            packageListBox.Location = new Point(457, 88);
            packageListBox.Name = "packageListBox";
            packageListBox.Size = new Size(259, 99);
            packageListBox.TabIndex = 3;
            packageListBox.SelectedIndexChanged += packageListBox_SelectedIndexChanged;
            // 
            // userNumbergroupBox
            // 
            userNumbergroupBox.Controls.Add(nextButton);
            userNumbergroupBox.Controls.Add(userNumbertextBox);
            userNumbergroupBox.Location = new Point(28, 26);
            userNumbergroupBox.Name = "userNumbergroupBox";
            userNumbergroupBox.Size = new Size(259, 100);
            userNumbergroupBox.TabIndex = 2;
            userNumbergroupBox.TabStop = false;
            userNumbergroupBox.Text = "User number";
            // 
            // nextButton
            // 
            nextButton.Location = new Point(84, 62);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(89, 32);
            nextButton.TabIndex = 1;
            nextButton.Text = "Check";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // userNumbertextBox
            // 
            userNumbertextBox.Location = new Point(28, 24);
            userNumbertextBox.Name = "userNumbertextBox";
            userNumbertextBox.PlaceholderText = "Enter Your User Number";
            userNumbertextBox.Size = new Size(212, 27);
            userNumbertextBox.TabIndex = 0;
            // 
            // PackstionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(packStationNamegroupBox);
            Name = "PackstionForm";
            packStationNamegroupBox.ResumeLayout(false);
            doorStatusGroupBox.ResumeLayout(false);
            doorStatusGroupBox.PerformLayout();
            collectYourPackagegroupBox.ResumeLayout(false);
            packageNumberAndPassswordgroupBox.ResumeLayout(false);
            packageNumberAndPassswordgroupBox.PerformLayout();
            userNumbergroupBox.ResumeLayout(false);
            userNumbergroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox packStationNamegroupBox;
        private GroupBox collectYourPackagegroupBox;
        private TextBox packageNumbertextBox;
        private TextBox passwordtextBox;
        private Button collectButton;
        private GroupBox packageNumberAndPassswordgroupBox;
        private GroupBox userNumbergroupBox;
        private TextBox userNumbertextBox;
        private Button nextButton;
        private Button openContainerButton;
        private ListBox packageListBox;
        private GroupBox doorStatusGroupBox;
        private Label statusLabel;
    }
}
