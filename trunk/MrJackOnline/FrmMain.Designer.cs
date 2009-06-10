namespace MrJack
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.PnlHelp = new System.Windows.Forms.Panel();
            this.PnlJack = new System.Windows.Forms.Panel();
            this.LblJackCaption = new System.Windows.Forms.Label();
            this.LblJackName = new System.Windows.Forms.Label();
            this.LblInfo = new System.Windows.Forms.Label();
            this.CbxHightlightMoves = new System.Windows.Forms.CheckBox();
            this.CbxShowCoordinates = new System.Windows.Forms.CheckBox();
            this.PbxJack = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard8 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard7 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard6 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard5 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard4 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard3 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard2 = new System.Windows.Forms.PictureBox();
            this.PbxHelpCard1 = new System.Windows.Forms.PictureBox();
            this.Board = new MrJack.CtlBoard();
            this.PnlHelp.SuspendLayout();
            this.PnlJack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxJack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlHelp
            // 
            this.PnlHelp.Controls.Add(this.PbxHelpCard8);
            this.PnlHelp.Controls.Add(this.PbxHelpCard7);
            this.PnlHelp.Controls.Add(this.PbxHelpCard6);
            this.PnlHelp.Controls.Add(this.PbxHelpCard5);
            this.PnlHelp.Controls.Add(this.PbxHelpCard4);
            this.PnlHelp.Controls.Add(this.PbxHelpCard3);
            this.PnlHelp.Controls.Add(this.PbxHelpCard2);
            this.PnlHelp.Controls.Add(this.PbxHelpCard1);
            this.PnlHelp.Location = new System.Drawing.Point(174, 254);
            this.PnlHelp.Name = "PnlHelp";
            this.PnlHelp.Size = new System.Drawing.Size(562, 244);
            this.PnlHelp.TabIndex = 40;
            this.PnlHelp.Visible = false;
            // 
            // PnlJack
            // 
            this.PnlJack.Controls.Add(this.LblJackCaption);
            this.PnlJack.Controls.Add(this.LblJackName);
            this.PnlJack.Controls.Add(this.PbxJack);
            this.PnlJack.Location = new System.Drawing.Point(502, 568);
            this.PnlJack.Name = "PnlJack";
            this.PnlJack.Size = new System.Drawing.Size(114, 65);
            this.PnlJack.TabIndex = 55;
            // 
            // LblJackCaption
            // 
            this.LblJackCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LblJackCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.LblJackCaption.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LblJackCaption.Location = new System.Drawing.Point(-1, 0);
            this.LblJackCaption.Name = "LblJackCaption";
            this.LblJackCaption.Size = new System.Drawing.Size(108, 14);
            this.LblJackCaption.TabIndex = 37;
            this.LblJackCaption.Text = "Jack\'s identity:";
            this.LblJackCaption.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblJackName
            // 
            this.LblJackName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LblJackName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.LblJackName.Location = new System.Drawing.Point(8, 17);
            this.LblJackName.Name = "LblJackName";
            this.LblJackName.Size = new System.Drawing.Size(58, 15);
            this.LblJackName.TabIndex = 38;
            this.LblJackName.Text = "Watson";
            this.LblJackName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LblInfo.ForeColor = System.Drawing.Color.White;
            this.LblInfo.Location = new System.Drawing.Point(148, 573);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(360, 45);
            this.LblInfo.TabIndex = 56;
            this.LblInfo.Text = "You can start moving now\r\nSelect a character card at left side then click on it.";
            // 
            // CbxHightlightMoves
            // 
            this.CbxHightlightMoves.AutoSize = true;
            this.CbxHightlightMoves.Checked = true;
            this.CbxHightlightMoves.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxHightlightMoves.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.CbxHightlightMoves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(196)))), ((int)(((byte)(90)))));
            this.CbxHightlightMoves.Location = new System.Drawing.Point(622, 587);
            this.CbxHightlightMoves.Name = "CbxHightlightMoves";
            this.CbxHightlightMoves.Size = new System.Drawing.Size(116, 19);
            this.CbxHightlightMoves.TabIndex = 58;
            this.CbxHightlightMoves.Text = "Highlight moves";
            this.CbxHightlightMoves.UseVisualStyleBackColor = true;
            // 
            // CbxShowCoordinates
            // 
            this.CbxShowCoordinates.AutoSize = true;
            this.CbxShowCoordinates.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.CbxShowCoordinates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(196)))), ((int)(((byte)(90)))));
            this.CbxShowCoordinates.Location = new System.Drawing.Point(622, 567);
            this.CbxShowCoordinates.Name = "CbxShowCoordinates";
            this.CbxShowCoordinates.Size = new System.Drawing.Size(129, 19);
            this.CbxShowCoordinates.TabIndex = 57;
            this.CbxShowCoordinates.Text = "Show coordinates";
            this.CbxShowCoordinates.UseVisualStyleBackColor = true;
            this.CbxShowCoordinates.CheckedChanged += new System.EventHandler(this.CbxShowCoordinates_CheckedChanged);
            // 
            // PbxJack
            // 
            this.PbxJack.Image = global::MrJack.Properties.Resources.JackWatson;
            this.PbxJack.Location = new System.Drawing.Point(58, 13);
            this.PbxJack.Name = "PbxJack";
            this.PbxJack.Size = new System.Drawing.Size(58, 52);
            this.PbxJack.TabIndex = 39;
            this.PbxJack.TabStop = false;
            // 
            // PbxHelpCard8
            // 
            this.PbxHelpCard8.BackgroundImage = global::MrJack.Properties.Resources.CardWatson;
            this.PbxHelpCard8.Location = new System.Drawing.Point(429, 134);
            this.PbxHelpCard8.Name = "PbxHelpCard8";
            this.PbxHelpCard8.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard8.TabIndex = 34;
            this.PbxHelpCard8.TabStop = false;
            // 
            // PbxHelpCard7
            // 
            this.PbxHelpCard7.BackgroundImage = global::MrJack.Properties.Resources.CardStealthy;
            this.PbxHelpCard7.Location = new System.Drawing.Point(296, 134);
            this.PbxHelpCard7.Name = "PbxHelpCard7";
            this.PbxHelpCard7.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard7.TabIndex = 33;
            this.PbxHelpCard7.TabStop = false;
            // 
            // PbxHelpCard6
            // 
            this.PbxHelpCard6.BackgroundImage = global::MrJack.Properties.Resources.CardGull;
            this.PbxHelpCard6.Location = new System.Drawing.Point(163, 134);
            this.PbxHelpCard6.Name = "PbxHelpCard6";
            this.PbxHelpCard6.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard6.TabIndex = 32;
            this.PbxHelpCard6.TabStop = false;
            // 
            // PbxHelpCard5
            // 
            this.PbxHelpCard5.BackgroundImage = global::MrJack.Properties.Resources.CardGoodley;
            this.PbxHelpCard5.Location = new System.Drawing.Point(20, 134);
            this.PbxHelpCard5.Name = "PbxHelpCard5";
            this.PbxHelpCard5.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard5.TabIndex = 31;
            this.PbxHelpCard5.TabStop = false;
            // 
            // PbxHelpCard4
            // 
            this.PbxHelpCard4.BackgroundImage = global::MrJack.Properties.Resources.CardSmith;
            this.PbxHelpCard4.Location = new System.Drawing.Point(429, 20);
            this.PbxHelpCard4.Name = "PbxHelpCard4";
            this.PbxHelpCard4.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard4.TabIndex = 30;
            this.PbxHelpCard4.TabStop = false;
            // 
            // PbxHelpCard3
            // 
            this.PbxHelpCard3.BackgroundImage = global::MrJack.Properties.Resources.CardLestrade;
            this.PbxHelpCard3.Location = new System.Drawing.Point(296, 20);
            this.PbxHelpCard3.Name = "PbxHelpCard3";
            this.PbxHelpCard3.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard3.TabIndex = 29;
            this.PbxHelpCard3.TabStop = false;
            // 
            // PbxHelpCard2
            // 
            this.PbxHelpCard2.BackgroundImage = global::MrJack.Properties.Resources.CardBert;
            this.PbxHelpCard2.Location = new System.Drawing.Point(163, 20);
            this.PbxHelpCard2.Name = "PbxHelpCard2";
            this.PbxHelpCard2.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard2.TabIndex = 28;
            this.PbxHelpCard2.TabStop = false;
            // 
            // PbxHelpCard1
            // 
            this.PbxHelpCard1.BackgroundImage = global::MrJack.Properties.Resources.CardHolmes;
            this.PbxHelpCard1.Location = new System.Drawing.Point(20, 20);
            this.PbxHelpCard1.Name = "PbxHelpCard1";
            this.PbxHelpCard1.Size = new System.Drawing.Size(119, 90);
            this.PbxHelpCard1.TabIndex = 27;
            this.PbxHelpCard1.TabStop = false;
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(61)))), ((int)(((byte)(70)))));
            this.Board.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Board.BackgroundImage")));
            this.Board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Board.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Board.Location = new System.Drawing.Point(143, 58);
            this.Board.Name = "Board";
            this.Board.ShowCoordinates = false;
            this.Board.Size = new System.Drawing.Size(622, 505);
            this.Board.TabIndex = 0;
            this.Board.MouseLeave += new System.EventHandler(this.Board_MouseLeave);
            this.Board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Board_MouseMove);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(61)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.CbxHightlightMoves);
            this.Controls.Add(this.CbxShowCoordinates);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.PnlJack);
            this.Controls.Add(this.PnlHelp);
            this.Controls.Add(this.Board);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mr. Jack Online | Bruno Cathala & Ludovic Maublanc";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMain_Paint);
            this.PnlHelp.ResumeLayout(false);
            this.PnlJack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxJack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHelpCard1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlBoard Board;
        private System.Windows.Forms.Panel PnlHelp;
        private System.Windows.Forms.PictureBox PbxHelpCard8;
        private System.Windows.Forms.PictureBox PbxHelpCard7;
        private System.Windows.Forms.PictureBox PbxHelpCard6;
        private System.Windows.Forms.PictureBox PbxHelpCard5;
        private System.Windows.Forms.PictureBox PbxHelpCard4;
        private System.Windows.Forms.PictureBox PbxHelpCard3;
        private System.Windows.Forms.PictureBox PbxHelpCard2;
        private System.Windows.Forms.PictureBox PbxHelpCard1;
        private System.Windows.Forms.Panel PnlJack;
        private System.Windows.Forms.Label LblJackCaption;
        private System.Windows.Forms.Label LblJackName;
        private System.Windows.Forms.PictureBox PbxJack;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.CheckBox CbxHightlightMoves;
        private System.Windows.Forms.CheckBox CbxShowCoordinates;



    }
}