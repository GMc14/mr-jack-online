﻿using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MrJack
{
    public partial class FrmMain : Form
    {
        public FrmMain() {
            InitializeComponent();
            this.AddVersionInfoToTitle();
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            
        }

        private void AddVersionInfoToTitle() {
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            StringBuilder sb = new StringBuilder(this.Text);
            sb.AppendFormat(" (Version {0}.{1})", ver.Major, ver.Minor);
            this.Text = sb.ToString();
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e) {

        }
    }
}
