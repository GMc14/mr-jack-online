using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MrJack
{
    public partial class FrmWaiting : Form
    {
        private GameController gCtrl = null;

        public FrmWaiting(GameController gc) {
            this.gCtrl = gc;
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.gCtrl.GameStatus = GameTypes.GameStatusIdle;
            this.Close();
        }
    }
}
