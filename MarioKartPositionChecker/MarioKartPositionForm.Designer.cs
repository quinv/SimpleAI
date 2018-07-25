namespace MarioKartPositionChecker
{
    partial class MarioKartPositionForm
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
            this.PositionTexbox = new System.Windows.Forms.TextBox();
            this.Position = new System.Windows.Forms.GroupBox();
            this.ImageDisplayContainer = new System.Windows.Forms.GroupBox();
            this.PositionImagePanel = new System.Windows.Forms.Panel();
            this.CheckBoxSaveImage = new System.Windows.Forms.CheckBox();
            this.TextBoxTime = new System.Windows.Forms.TextBox();
            this.Position.SuspendLayout();
            this.ImageDisplayContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionTexbox
            // 
            this.PositionTexbox.Location = new System.Drawing.Point(6, 19);
            this.PositionTexbox.Name = "PositionTexbox";
            this.PositionTexbox.Size = new System.Drawing.Size(128, 20);
            this.PositionTexbox.TabIndex = 0;
            this.PositionTexbox.Text = "1600; 840; 200; 200";
            // 
            // Position
            // 
            this.Position.Controls.Add(this.TextBoxTime);
            this.Position.Controls.Add(this.CheckBoxSaveImage);
            this.Position.Controls.Add(this.PositionTexbox);
            this.Position.Location = new System.Drawing.Point(12, 12);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(260, 90);
            this.Position.TabIndex = 1;
            this.Position.TabStop = false;
            this.Position.Text = "Position";
            this.Position.Enter += new System.EventHandler(this.PositionText_Enter);
            // 
            // ImageDisplayContainer
            // 
            this.ImageDisplayContainer.Controls.Add(this.PositionImagePanel);
            this.ImageDisplayContainer.Location = new System.Drawing.Point(12, 108);
            this.ImageDisplayContainer.Name = "ImageDisplayContainer";
            this.ImageDisplayContainer.Size = new System.Drawing.Size(260, 183);
            this.ImageDisplayContainer.TabIndex = 2;
            this.ImageDisplayContainer.TabStop = false;
            this.ImageDisplayContainer.Text = "Image";
            // 
            // PositionImagePanel
            // 
            this.PositionImagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PositionImagePanel.Location = new System.Drawing.Point(58, 19);
            this.PositionImagePanel.Name = "PositionImagePanel";
            this.PositionImagePanel.Size = new System.Drawing.Size(150, 150);
            this.PositionImagePanel.TabIndex = 0;
            // 
            // CheckBoxSaveImage
            // 
            this.CheckBoxSaveImage.AutoSize = true;
            this.CheckBoxSaveImage.Location = new System.Drawing.Point(166, 19);
            this.CheckBoxSaveImage.Name = "CheckBoxSaveImage";
            this.CheckBoxSaveImage.Size = new System.Drawing.Size(88, 17);
            this.CheckBoxSaveImage.TabIndex = 1;
            this.CheckBoxSaveImage.Text = "Save Images";
            this.CheckBoxSaveImage.UseVisualStyleBackColor = true;
            // 
            // TextBoxTime
            // 
            this.TextBoxTime.Location = new System.Drawing.Point(6, 54);
            this.TextBoxTime.Name = "TextBoxTime";
            this.TextBoxTime.Size = new System.Drawing.Size(128, 20);
            this.TextBoxTime.TabIndex = 2;
            this.TextBoxTime.Text = "10";
            // 
            // MarioKartPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 303);
            this.Controls.Add(this.ImageDisplayContainer);
            this.Controls.Add(this.Position);
            this.Name = "MarioKartPositionForm";
            this.Text = "Form1";
            this.Position.ResumeLayout(false);
            this.Position.PerformLayout();
            this.ImageDisplayContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PositionTexbox;
        private System.Windows.Forms.GroupBox Position;
        private System.Windows.Forms.GroupBox ImageDisplayContainer;
        private System.Windows.Forms.Panel PositionImagePanel;
        private System.Windows.Forms.CheckBox CheckBoxSaveImage;
        private System.Windows.Forms.TextBox TextBoxTime;
    }
}

