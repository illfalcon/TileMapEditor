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
    public partial class AddTile : Form
    {
        public int topLeftCornerX, topLeftCornerY, bottomRightCornerX, bottomRightCornerY;
        public bool isGround, isSolid, isOneWay, isEmpty;

        private void isOneWayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isOneWayCheckBox.Checked)
                isOneWay = true;
            else
                isOneWay = false;
        }

        private void isEmptyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isEmptyCheckBox.Checked)
                isEmpty = true;
            else
                isEmpty = false;
        }

        private void isSolidCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isSolidCheckBox.Checked)
                isSolid = true;
            else
                isSolid = false;
        }

        private void isGroundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isGroundCheckBox.Checked)
                isGround = true;
            else
                isGround = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public AddTile()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            topLeftCornerX = Convert.ToInt32(topLeftCornerXBox.Value);
            topLeftCornerY = Convert.ToInt32(topLeftCornerYBox.Value);
            bottomRightCornerX = Convert.ToInt32(bottomRightCornerXBox.Value);
            bottomRightCornerY = Convert.ToInt32(bottomRightCornerYBox.Value);

            DialogResult = DialogResult.OK;
        }
    }
}
