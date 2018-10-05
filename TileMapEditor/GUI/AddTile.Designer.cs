namespace TileMapEditor.GUI
{
    partial class AddTile
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.topLeftCornerXBox = new System.Windows.Forms.NumericUpDown();
            this.topLeftCornerYBox = new System.Windows.Forms.NumericUpDown();
            this.bottomRightCornerXBox = new System.Windows.Forms.NumericUpDown();
            this.bottomRightCornerYBox = new System.Windows.Forms.NumericUpDown();
            this.isGroundCheckBox = new System.Windows.Forms.CheckBox();
            this.isSolidCheckBox = new System.Windows.Forms.CheckBox();
            this.isEmptyCheckBox = new System.Windows.Forms.CheckBox();
            this.isOneWayCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.topLeftCornerXBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topLeftCornerYBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRightCornerXBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRightCornerYBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(309, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(309, 138);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // topLeftCornerXBox
            // 
            this.topLeftCornerXBox.Location = new System.Drawing.Point(40, 67);
            this.topLeftCornerXBox.Name = "topLeftCornerXBox";
            this.topLeftCornerXBox.Size = new System.Drawing.Size(38, 20);
            this.topLeftCornerXBox.TabIndex = 2;
            // 
            // topLeftCornerYBox
            // 
            this.topLeftCornerYBox.Location = new System.Drawing.Point(84, 67);
            this.topLeftCornerYBox.Name = "topLeftCornerYBox";
            this.topLeftCornerYBox.Size = new System.Drawing.Size(38, 20);
            this.topLeftCornerYBox.TabIndex = 3;
            // 
            // bottomRightCornerXBox
            // 
            this.bottomRightCornerXBox.Location = new System.Drawing.Point(40, 141);
            this.bottomRightCornerXBox.Name = "bottomRightCornerXBox";
            this.bottomRightCornerXBox.Size = new System.Drawing.Size(38, 20);
            this.bottomRightCornerXBox.TabIndex = 2;
            // 
            // bottomRightCornerYBox
            // 
            this.bottomRightCornerYBox.Location = new System.Drawing.Point(84, 141);
            this.bottomRightCornerYBox.Name = "bottomRightCornerYBox";
            this.bottomRightCornerYBox.Size = new System.Drawing.Size(38, 20);
            this.bottomRightCornerYBox.TabIndex = 3;
            // 
            // isGroundCheckBox
            // 
            this.isGroundCheckBox.AutoSize = true;
            this.isGroundCheckBox.Location = new System.Drawing.Point(166, 67);
            this.isGroundCheckBox.Name = "isGroundCheckBox";
            this.isGroundCheckBox.Size = new System.Drawing.Size(69, 17);
            this.isGroundCheckBox.TabIndex = 4;
            this.isGroundCheckBox.Text = "IsGround";
            this.isGroundCheckBox.UseVisualStyleBackColor = true;
            this.isGroundCheckBox.CheckedChanged += new System.EventHandler(this.isGroundCheckBox_CheckedChanged);
            // 
            // isSolidCheckBox
            // 
            this.isSolidCheckBox.AutoSize = true;
            this.isSolidCheckBox.Location = new System.Drawing.Point(166, 90);
            this.isSolidCheckBox.Name = "isSolidCheckBox";
            this.isSolidCheckBox.Size = new System.Drawing.Size(57, 17);
            this.isSolidCheckBox.TabIndex = 4;
            this.isSolidCheckBox.Text = "IsSolid";
            this.isSolidCheckBox.UseVisualStyleBackColor = true;
            this.isSolidCheckBox.CheckedChanged += new System.EventHandler(this.isSolidCheckBox_CheckedChanged);
            // 
            // isEmptyCheckBox
            // 
            this.isEmptyCheckBox.AutoSize = true;
            this.isEmptyCheckBox.Location = new System.Drawing.Point(166, 113);
            this.isEmptyCheckBox.Name = "isEmptyCheckBox";
            this.isEmptyCheckBox.Size = new System.Drawing.Size(63, 17);
            this.isEmptyCheckBox.TabIndex = 4;
            this.isEmptyCheckBox.Text = "IsEmpty";
            this.isEmptyCheckBox.UseVisualStyleBackColor = true;
            this.isEmptyCheckBox.CheckedChanged += new System.EventHandler(this.isEmptyCheckBox_CheckedChanged);
            // 
            // isOneWayCheckBox
            // 
            this.isOneWayCheckBox.AutoSize = true;
            this.isOneWayCheckBox.Location = new System.Drawing.Point(166, 136);
            this.isOneWayCheckBox.Name = "isOneWayCheckBox";
            this.isOneWayCheckBox.Size = new System.Drawing.Size(76, 17);
            this.isOneWayCheckBox.TabIndex = 4;
            this.isOneWayCheckBox.Text = "IsOneWay";
            this.isOneWayCheckBox.UseVisualStyleBackColor = true;
            this.isOneWayCheckBox.CheckedChanged += new System.EventHandler(this.isOneWayCheckBox_CheckedChanged);
            // 
            // AddTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 232);
            this.Controls.Add(this.isOneWayCheckBox);
            this.Controls.Add(this.isEmptyCheckBox);
            this.Controls.Add(this.isSolidCheckBox);
            this.Controls.Add(this.isGroundCheckBox);
            this.Controls.Add(this.bottomRightCornerYBox);
            this.Controls.Add(this.topLeftCornerYBox);
            this.Controls.Add(this.bottomRightCornerXBox);
            this.Controls.Add(this.topLeftCornerXBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "AddTile";
            this.Text = "AddTile";
            ((System.ComponentModel.ISupportInitialize)(this.topLeftCornerXBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topLeftCornerYBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRightCornerXBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRightCornerYBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown topLeftCornerXBox;
        private System.Windows.Forms.NumericUpDown topLeftCornerYBox;
        private System.Windows.Forms.NumericUpDown bottomRightCornerXBox;
        private System.Windows.Forms.NumericUpDown bottomRightCornerYBox;
        private System.Windows.Forms.CheckBox isGroundCheckBox;
        private System.Windows.Forms.CheckBox isSolidCheckBox;
        private System.Windows.Forms.CheckBox isEmptyCheckBox;
        private System.Windows.Forms.CheckBox isOneWayCheckBox;
    }
}