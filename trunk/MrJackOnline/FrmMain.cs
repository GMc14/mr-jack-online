using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace MrJack
{
    public partial class FrmMain : Form
    {
        public FrmMain() {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            this.AddVersionToTitle();
        }

        private void AddVersionToTitle() {
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += " (Version " + ver.Major + "." + ver.Minor + " alpha)";
        }
    }
}
