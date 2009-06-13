namespace MrJack
{
    partial class FrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LblAppInfo = new System.Windows.Forms.Label();
            this.PbxLogo = new System.Windows.Forms.PictureBox();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblMrJack = new System.Windows.Forms.Label();
            this.LblSub = new System.Windows.Forms.Label();
            this.BtnProjectSite = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblAppInfo
            // 
            this.LblAppInfo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LblAppInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.LblAppInfo.Location = new System.Drawing.Point(12, 192);
            this.LblAppInfo.Name = "LblAppInfo";
            this.LblAppInfo.Size = new System.Drawing.Size(396, 49);
            this.LblAppInfo.TabIndex = 2;
            this.LblAppInfo.Text = "Mr.Jack © Hurrican. Authors: Bruno Cathala && Ludovic Maublanc.\r\nDeveloper: Jeffr" +
                "ey Yang. This is a free and open source (MIT license) software.\r\nProject Home: ";
            this.LblAppInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseHandler_MouseDown);
            // 
            // PbxLogo
            // 
            this.PbxLogo.Image = global::MrJack.Properties.Resources.AboutLogo;
            this.PbxLogo.Location = new System.Drawing.Point(205, 12);
            this.PbxLogo.Name = "PbxLogo";
            this.PbxLogo.Size = new System.Drawing.Size(203, 80);
            this.PbxLogo.TabIndex = 0;
            this.PbxLogo.TabStop = false;
            this.PbxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseHandler_MouseDown);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LblVersion.Location = new System.Drawing.Point(12, 178);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(92, 13);
            this.LblVersion.TabIndex = 3;
            this.LblVersion.Text = "Version: 0.1.0.0";
            this.LblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseHandler_MouseDown);
            // 
            // LblMrJack
            // 
            this.LblMrJack.AutoSize = true;
            this.LblMrJack.Font = new System.Drawing.Font("Arial", 19F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
            this.LblMrJack.ForeColor = System.Drawing.Color.White;
            this.LblMrJack.Location = new System.Drawing.Point(12, 93);
            this.LblMrJack.Name = "LblMrJack";
            this.LblMrJack.Size = new System.Drawing.Size(157, 23);
            this.LblMrJack.TabIndex = 4;
            this.LblMrJack.Text = "Mr. Jack Online";
            this.LblMrJack.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblMrJack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseHandler_MouseDown);
            // 
            // LblSub
            // 
            this.LblSub.AutoSize = true;
            this.LblSub.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
            this.LblSub.ForeColor = System.Drawing.Color.White;
            this.LblSub.Location = new System.Drawing.Point(13, 116);
            this.LblSub.Name = "LblSub";
            this.LblSub.Size = new System.Drawing.Size(251, 15);
            this.LblSub.TabIndex = 5;
            this.LblSub.Text = "for Microsoft .NET Framework 2.0 Runtime";
            this.LblSub.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseHandler_MouseDown);
            // 
            // BtnProjectSite
            // 
            this.BtnProjectSite.ActiveLinkColor = System.Drawing.Color.White;
            this.BtnProjectSite.AutoSize = true;
            this.BtnProjectSite.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BtnProjectSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnProjectSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.BtnProjectSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnProjectSite.Location = new System.Drawing.Point(82, 220);
            this.BtnProjectSite.Name = "BtnProjectSite";
            this.BtnProjectSite.Size = new System.Drawing.Size(198, 14);
            this.BtnProjectSite.TabIndex = 6;
            this.BtnProjectSite.TabStop = true;
            this.BtnProjectSite.Text = "http://code.google.com/p/mr-jack-online/";
            this.BtnProjectSite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnProjectSite_MouseDown);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(39)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(420, 250);
            this.ControlBox = false;
            this.Controls.Add(this.BtnProjectSite);
            this.Controls.Add(this.LblSub);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblMrJack);
            this.Controls.Add(this.PbxLogo);
            this.Controls.Add(this.LblAppInfo);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAbout";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseHandler_MouseDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmAbout_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxLogo;
        private System.Windows.Forms.Label LblAppInfo;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label LblMrJack;
        private System.Windows.Forms.Label LblSub;
        private System.Windows.Forms.LinkLabel BtnProjectSite;
    }
}