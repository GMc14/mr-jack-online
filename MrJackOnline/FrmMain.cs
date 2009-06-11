using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MrJack
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class FrmMain : Form
    {
        private const string movesStyles = "body{background-color:#1E3D46;overflow-x:hidden;overflow-y:auto;margin:0;padding:0;}table{color:#EEC45A;background-color:#1E3D46;font-family:Arial, Helvetica;font-size:12px;margin:2px 0 4px 2px;padding:0;}.trnew{line-height:20px;color:#1E3D46;text-align:center;font-size:14px;font-weight:700;font-style:italic;background-color:#ccc;}.R{color:#FFF;}.tdr{vertical-align:top;}.W{padding-top:6px;color:#FFF;}.tw{vertical-align:top;padding-top:6px;padding-left:4px;}.p{padding-top:4px;}a:link,a:visited,a:hover,a:active,a:focus{background-color:#1E3D46;color:#FFF;font-family:Arial, Helvetica;font-size:12px;font-weight:400;text-decoration:none;margin:0;padding:0;}.I,a.I:link,a.I:visited,a.I:hover,a.I:active,a.I:focus{color:#EEC45A;}.J,a.J:link,a.J:visited,a.J:hover,a.J:active,a.J:focus{color:#CCC;}";
        private const string movesHeader = "<html><head><title>Moves</title><style>" + movesStyles + "</style></head><body><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"116\"><colgroup><col width=\"14px\" /><col width=\"102px\" /></colgroup>";
        private const string movesFooter = "<tr><td>&nbsp;</td></tr></table></body></html>";

        private const string commentsStyles = "body{background-color:#1E3D46;overflow-x:hidden;overflow-y:auto;font-family:Arial, Helvetica;font-size:12px;text-align:center;margin:0;padding:0 0 0 2px;}.cmt{text-align:center;width:110px;color:#F1AF3B;margin:0;padding:0;float:left;}.ctext{color:#fff;font-style:italic;}";
        private const string commentsHeader = "<html><head><title>Blank</title><style>" + commentsStyles + "</style></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"><div class=\"cmt\">catsil wrote:<br><span class=\"ctext\">";
        private const string commentsFooter = "</span></div></body></html>";

        public FrmMain() {
            InitializeComponent();

            this.AddVersionInfoToTitle();
            this.MovesList.ObjectForScripting = this;
            this.CommentList.ObjectForScripting = this;
            this.MovesList.DocumentText = "<html><head><title>Blank</title></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"><a href=\"#\" onclick=\"window.external.TestWoW();\" id=\"s1\"></a></body></html>";
            this.CommentList.DocumentText = "<html><head><title>Blank</title></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"></body></html>";
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

        private void CbxShowCoordinates_CheckedChanged(object sender, EventArgs e) {
            this.Board.ShowCoordinates = (sender as CheckBox).Checked;
        }

        private void BtnTabMoves_Click(object sender, EventArgs e) {
            this.SelectTabMoves();
        }

        private void BtnTabNotes_Click(object sender, EventArgs e) {
            this.SelectTabNotes();
        }

        public void SelectTabMoves() {
            this.PbxTab.Image = Properties.Resources.TabMoves;
            this.BtnTabNotes.BackColor = Color.FromArgb(20, 39, 48);
            this.BtnTabNotes.ForeColor = Color.FromArgb(132, 132, 132);
            this.BtnTabMoves.BackColor = Color.FromArgb(30, 61, 70);
            this.BtnTabMoves.ForeColor = Color.White;

            this.PnlMoves.Visible = true;
            this.PnlNotes.Visible = false;
        }

        public void SelectTabNotes() {
            this.PbxTab.Image = Properties.Resources.TabNotes;
            this.BtnTabMoves.BackColor = Color.FromArgb(20, 39, 48);
            this.BtnTabMoves.ForeColor = Color.FromArgb(132, 132, 132);
            this.BtnTabNotes.BackColor = Color.FromArgb(30, 61, 70);
            this.BtnTabNotes.ForeColor = Color.White;

            this.PnlNotes.Visible = true;
            this.PnlMoves.Visible = false;
        }
    }
}
