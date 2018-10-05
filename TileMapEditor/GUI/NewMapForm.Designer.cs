namespace TileMapEditor.GUI
{
    partial class NewMapForm
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
            this.tileWidth = new System.Windows.Forms.NumericUpDown();
            this.tileHeight = new System.Windows.Forms.NumericUpDown();
            this.mapHeight = new System.Windows.Forms.NumericUpDown();
            this.mapWidth = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tileWidth
            // 
            this.tileWidth.Location = new System.Drawing.Point(238, 81);
            this.tileWidth.Name = "tileWidth";
            this.tileWidth.Size = new System.Drawing.Size(35, 20);
            this.tileWidth.TabIndex = 1;
            this.tileWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // tileHeight
            // 
            this.tileHeight.Location = new System.Drawing.Point(238, 156);
            this.tileHeight.Name = "tileHeight";
            this.tileHeight.Size = new System.Drawing.Size(35, 20);
            this.tileHeight.TabIndex = 1;
            this.tileHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // mapHeight
            // 
            this.mapHeight.Location = new System.Drawing.Point(94, 156);
            this.mapHeight.Name = "mapHeight";
            this.mapHeight.Size = new System.Drawing.Size(38, 20);
            this.mapHeight.TabIndex = 1;
            this.mapHeight.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // mapWidth
            // 
            this.mapWidth.Location = new System.Drawing.Point(94, 81);
            this.mapWidth.Name = "mapWidth";
            this.mapWidth.Size = new System.Drawing.Size(38, 20);
            this.mapWidth.TabIndex = 1;
            this.mapWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(94, 206);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(238, 206);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MapWidth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MapHeight";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(180, 158);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(55, 13);
            this.label.TabIndex = 3;
            this.label.Text = "TileHeight";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "TileWidth";
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 256);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.mapWidth);
            this.Controls.Add(this.mapHeight);
            this.Controls.Add(this.tileHeight);
            this.Controls.Add(this.tileWidth);
            this.Name = "NewMapForm";
            this.Text = "NewMapForm";
            ((System.ComponentModel.ISupportInitialize)(this.tileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown tileWidth;
        private System.Windows.Forms.NumericUpDown tileHeight;
        private System.Windows.Forms.NumericUpDown mapHeight;
        private System.Windows.Forms.NumericUpDown mapWidth;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label4;
    }
}