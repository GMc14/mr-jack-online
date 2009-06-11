using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace MrJack
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class FrmMain : Form
    {
        private const string movesHeader = "<html><head><title>Moves</title><style>body{background-color:#1E3D46;overflow-x:hidden;overflow-y:auto;margin:0;padding:0;}table{color:#EEC45A;background-color:#1E3D46;font-family:Arial, Helvetica;font-size:12px;margin:2px 0 4px 2px;padding:0;}.trnew{line-height:20px;color:#1E3D46;text-align:center;font-size:14px;font-weight:700;font-style:italic;background-color:#ccc;}.R{color:#FFF;}.tdr{vertical-align:top;}.W{padding-top:6px;color:#FFF;}.tw{vertical-align:top;padding-top:6px;padding-left:4px;}.p{padding-top:4px;}a:link,a:visited,a:hover,a:active,a:focus{background-color:#1E3D46;color:#FFF;font-family:Arial, Helvetica;font-size:12px;font-weight:400;text-decoration:none;margin:0;padding:0;}.I,a.I:link,a.I:visited,a.I:hover,a.I:active,a.I:focus{color:#EEC45A;}.J,a.J:link,a.J:visited,a.J:hover,a.J:active,a.J:focus{color:#CCC;}</style></head><body><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"116\"><colgroup><col width=\"14px\" /><col width=\"102px\" /></colgroup>";
        private const string movesFooter = "<tr><td>&nbsp;</td></tr></table></body></html>";

        private const string commentsHeader = "<html><head><title>Blank</title><style>body{background-color:#1E3D46;overflow-x:hidden;overflow-y:auto;font-family:Arial, Helvetica;font-size:12px;text-align:center;margin:0;padding:0 0 0 2px;}.cmt{text-align:center;width:110px;color:#F1AF3B;margin:0;padding:0;float:left;}.ctext{color:#fff;font-style:italic;}</style></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"><div class=\"cmt\">catsil wrote:<br><span class=\"ctext\">";
        private const string commentsFooter = "</span></div></body></html>";

        public FrmMain() {
            InitializeComponent();

            this.FixLinkLableTabStop();

            this.WbrMovesList.ObjectForScripting = this;
            this.WbrCommentList.ObjectForScripting = this;
            this.WbrMovesList.DocumentText = "<html><head><title>Blank</title></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"><a href=\"#\" onclick=\"window.external.TestWoW();\" id=\"s1\"></a></body></html>";
            this.WbrCommentList.DocumentText = "<html><head><title>Blank</title></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"></body></html>";
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e) {

        }

        private void Board_MouseLeave(object sender, EventArgs e) {
            this.PnlHelp.Visible = false;
        }

        private void Board_MouseMove(object sender, MouseEventArgs e) {
            this.PnlHelp.Visible = 
                e.X > GameUIConsts.CardHelpBoardLeft && 
                e.Y > GameUIConsts.CardHelpBoardTop && 
                e.X < GameUIConsts.CardHelpBoardLeft+GameUIConsts.CardHelpWidth && 
                e.Y < GameUIConsts.CardHelpBoardTop+GameUIConsts.CardHelpHeight;
        }

        private void BtnTabMoves_Click(object sender, EventArgs e) {
            this.SelectTabMoves();
        }

        private void BtnTabNotes_Click(object sender, EventArgs e) {
            this.SelectTabNotes();
        }

        private void FixLinkLableTabStop() {
            this.BtnHostGame.TabStop = false;
            this.BtnJoinGame.TabStop = false;
            this.BtnObserveGame.TabStop = false;
            this.BtnLoadReplay.TabStop = false;
            this.BtnHelp.TabStop = false;
            this.BtnAbout.TabStop = false;
        }

        public void SelectTabMoves() {
            this.PbxTab.Image = Properties.Resources.TabMoves;
            this.BtnTabNotes.BackColor = Color.FromArgb(20, 39, 48);
            this.BtnTabNotes.ForeColor = Color.FromArgb(132, 132, 132);
            this.BtnTabMoves.BackColor = Color.FromArgb(30, 61, 70);
            this.BtnTabMoves.ForeColor = Color.White;

            this.PnlMoves.Visible = true;
            this.PnlNotes.Visible = false;
            this.WbrMovesList.Document.Focus();
        }

        public void SelectTabNotes() {
            this.PbxTab.Image = Properties.Resources.TabNotes;
            this.BtnTabMoves.BackColor = Color.FromArgb(20, 39, 48);
            this.BtnTabMoves.ForeColor = Color.FromArgb(132, 132, 132);
            this.BtnTabNotes.BackColor = Color.FromArgb(30, 61, 70);
            this.BtnTabNotes.ForeColor = Color.White;

            this.PnlNotes.Visible = true;
            this.PnlMoves.Visible = false;
            this.TbxNotes.Focus();
        }

        private void CbxShowCoordinates_MouseDown(object sender, MouseEventArgs e) {
            this.Board.Focus();
            bool value = !(sender as CheckBox).Checked;
            (sender as CheckBox).Checked = value;
            this.Board.ShowCoordinates = value;
        }

        private void BtnAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }

        private void BtnHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://www.hurricangames.com/data/pdf/Mr_Jack_GB.pdf");
        }

        private void CbxPrivateComment_MouseDown(object sender, MouseEventArgs e) {
            this.TbxComment.Focus();
            (sender as CheckBox).Checked = !(sender as CheckBox).Checked;
        }

        private void BtnLoadReplay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult result = OfgReplay.ShowDialog();
            if(result == DialogResult.OK) {
                //XmlSerializer xSerial = new XmlSerializer(typeof(GameReplay));
                //FileStream fs = new FileStream(OfgReplay.FileName, FileMode.Open);
                //try {
                //    this.replay = (GameReplay)xSerial.Deserialize(fs);
                //} catch(Exception) {
                //    MessageBox.Show("Error loading \"" + OfgReplay.SafeFileName + "\",\nThis file is not a vaild Mr. Jack replay file.", "Mr. Jack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //} finally {
                //    fs.Close();
                //}
            }
        }
    }
}
