using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileMapEditor.MapThings;

namespace TileMapEditor.GUI
{
    public partial class NewMapForm : Form
    {
        public int width, height, mapTileWidth, mapTileHeight;

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            width = Convert.ToInt32(mapWidth.Value);
            height = Convert.ToInt32(mapHeight.Value);
            mapTileWidth = Convert.ToInt32(tileWidth.Value);
            mapTileHeight = Convert.ToInt32(tileHeight.Value);
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
