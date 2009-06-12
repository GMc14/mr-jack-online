using System;
using System.Windows.Forms;
using System.Reflection;

namespace MrJack
{
    public partial class FrmAbout: Form
    {
        public FrmAbout() {
            InitializeComponent();

            this.BtnProjectSite.TabStop = false;
            this.LblVersion.Text = string.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void FrmAbout_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)27) {this.Close();}
        }

        private void CloseHandler_MouseDown(object sender, MouseEventArgs e) {
            this.Close();
        }

        private void BtnProjectSite_MouseDown(object sender, MouseEventArgs e) {
            this.Close();
            System.Diagnostics.Process.Start((sender as LinkLabel).Text);
        }
    }
}
