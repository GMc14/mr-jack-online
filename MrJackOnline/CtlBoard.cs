using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MrJack
{
    public partial class CtlBoard : UserControl
    {
        private bool showCoordinates;
        public bool ShowCoordinates {
            get { return this.showCoordinates; }
            set {
                this.showCoordinates = value;
                this.Invalidate();
            }
        }

        public CtlBoard() {
            InitializeComponent();
        }

        private void CtlBoard_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(Properties.Resources.CardHelp, new Rectangle(475, 460, 30, 35));
            if(this.showCoordinates) {
                e.Graphics.DrawImage(Properties.Resources.Coordinates, new Rectangle(0, 0, 622, 505));
            }
        }
    }
}
