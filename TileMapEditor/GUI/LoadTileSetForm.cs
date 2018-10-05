using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileMapEditor.GUI
{
    public partial class LoadTileSetForm : Form
    {
        OpenFileDialog openFile;
        public String fileName;

        public LoadTileSetForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\";
            openFile.Filter = "Image Files (*.png)| *.png";
            openFile.FilterIndex = 1;
            openFile.FileName = "";
            if (openFile.ShowDialog() != DialogResult.Cancel)
            {
                fileName = openFile.FileName;
            }
            else
            {
                fileName = "";
            }
            fileNameTextBox.Text = fileName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
