﻿using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MrJack
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class FrmMain : Form
    {
        private const string initInfoText = "Mr. Jack is a boardgame devised by Bruno Cathala and Ludovic Maublanc, illustrated by Pierô, published by Hurrican.\nMr. Jack © Hurrican.";
        private const string sndNewName = "new.mid";
        private const string sndTurnName = "turn.mid";

        public string SndNewPath = string.Empty;
        public string SndTurnPath = string.Empty;

        private const string movesHeader = "<html><head><title>Moves</title><style>body{background-color:#1E3D46;overflow-x:hidden;overflow-y:auto;margin:0;padding:0;}table{color:#EEC45A;background-color:#1E3D46;font-family:Arial, Helvetica;font-size:12px;margin:2px 0 4px 2px;padding:0;}.trnew{line-height:20px;color:#1E3D46;text-align:center;font-size:14px;font-weight:700;font-style:italic;background-color:#ccc;}.R{color:#FFF;}.tdr{vertical-align:top;}.W{padding-top:6px;color:#FFF;}.tw{vertical-align:top;padding-top:6px;padding-left:4px;}.p{padding-top:4px;}a:link,a:visited,a:hover,a:active,a:focus{background-color:#1E3D46;color:#FFF;font-family:Arial, Helvetica;font-size:12px;font-weight:400;text-decoration:none;margin:0;padding:0;}.I,a.I:link,a.I:visited,a.I:hover,a.I:active,a.I:focus{color:#EEC45A;}.J,a.J:link,a.J:visited,a.J:hover,a.J:active,a.J:focus{color:#CCC;}</style></head><body><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"116\"><colgroup><col width=\"14px\" /><col width=\"102px\" /></colgroup>";
        private const string movesFooter = "<tr><td>&nbsp;</td></tr></table></body></html>";

        private const string commentsHeader = "<html><head><title>Blank</title><style>body{background-color:#1E3D46;overflow-x:hidden;overflow-y:auto;font-family:Arial, Helvetica;font-size:12px;text-align:center;margin:0;padding:0 0 0 2px;}.cmt{text-align:center;width:110px;color:#F1AF3B;margin:0;padding:0;float:left;}.ctext{color:#fff;font-style:italic;}</style></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"><div class=\"cmt\">catsil wrote:<br><span class=\"ctext\">";
        private const string commentsFooter = "</span></div></body></html>";

        private Audio gameSound = null;
        private BoardStatus gameBoard = null;
        private BoardStatus replayBoard = null;
        private GameController gCtrl = null;
        private MoveController mCtrl = null;
        private GameNetwork network = null;

        private bool enableSound;
        public bool EnableSound {
            get { return this.enableSound; }
            set { this.enableSound = value; }
        }

        public FrmMain() {
            this.enableSound = true;
            this.gameBoard = new BoardStatus();
            this.replayBoard = new BoardStatus();
            this.gCtrl = new GameController(this, this.gameBoard, this.replayBoard);
            this.mCtrl = new MoveController(this.gCtrl);
            this.network = new GameNetwork(this.gCtrl);

            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            this.Board.Game = this.gameBoard;
            this.SetInfoText(initInfoText);
            this.FixLinkLableTabStop();

            this.WbrMovesList.ObjectForScripting = this;
            this.WbrCommentList.ObjectForScripting = this;
            this.WbrMovesList.DocumentText = "<html><head><title>Blank</title></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"><a href=\"#\" onclick=\"window.external.TestWoW();\" id=\"s1\"></a></body></html>";
            this.WbrCommentList.DocumentText = "<html><head><title>Blank</title></head><body style=\"background-color:#1E3D46;overflow-y:auto;overflow-x:hidden;margin:0;padding:0;\"></body></html>";
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            this.LoadSounds();
            this.gCtrl.UpdateCards();
            this.gCtrl.UpdateHelpCards();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            this.DeleteSounds();
            this.network.StopHost();
        }

        #region Game's FixUI Methods
        private void FixLinkLableTabStop() {
            this.BtnHostGame.TabStop = false;
            this.BtnJoinGame.TabStop = false;
            this.BtnObserveGame.TabStop = false;
            this.BtnLoadReplay.TabStop = false;
            this.BtnHelp.TabStop = false;
            this.BtnAbout.TabStop = false;
        }
        #endregion

        public void SetInfoText(string text) {
            this.LblInfo.Text = text;
        }

        #region Game's [Sound] Operations
        private void LoadSounds() {
            string path = Path.GetTempPath();
            FileStream fs = null;
            try {
                path += "new.mid";
                fs = new FileStream(path, FileMode.Create);
                fs.Write(Properties.Resources.SndNewGame, 0, Properties.Resources.SndNewGame.Length);
                this.SndNewPath = path;
                fs.Close();
                fs.Dispose();

                path += "turn.mid";
                fs = new FileStream(path, FileMode.Create);
                fs.Write(Properties.Resources.SndTurn, 0, Properties.Resources.SndTurn.Length);
                this.SndTurnPath = path;
            } catch(Exception) {
            } finally {
                if(fs != null) {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        private void PlaySound(string path) {
            if(path != string.Empty && this.enableSound) {
                if(this.gameSound == null) {
                    if(File.Exists(path)) {
                        this.gameSound = new Audio(path, true);
                    }
                } else {
                    this.gameSound.Open(path, true);
                }
            }
        }

        private void StopSound() {
            if(this.gameSound != null && this.gameSound.Playing) {
                this.gameSound.Stop();
            }
        }

        private void DeleteSounds() {
            try {
                if(File.Exists(this.SndNewPath)) {
                    File.Delete(this.SndNewPath);
                }
                if(File.Exists(this.SndTurnPath)) {
                    File.Delete(this.SndTurnPath);
                }
            } catch(Exception) { }
        }
        #endregion

        public void PlaySoundNew() {
            this.PlaySound(SndNewPath);
        }

        public void PlaySoundTurn() {
            this.PlaySound(SndNewPath);
        }

        #region Game's [Option Panel] Event Handlers
        private void CbxShowCoordinates_MouseDown(object sender, MouseEventArgs e) {
            this.Board.Focus();
            bool value = !(sender as CheckBox).Checked;
            (sender as CheckBox).Checked = value;
            this.Board.ShowCoordinates = value;
        }

        private void CbxHightlightMoves_MouseDown(object sender, MouseEventArgs e) {
            this.Board.Focus();
            bool value = !(sender as CheckBox).Checked;
            (sender as CheckBox).Checked = value;
            this.Board.HighlightMoves = value;
        }

        private void CbxEnableSound_MouseDown(object sender, MouseEventArgs e) {
            this.Board.Focus();
            bool value = (sender as CheckBox).Checked;
            if(value) {
                this.StopSound();
            }
            this.enableSound = !value;
            (sender as CheckBox).Checked = !value;
        }
        #endregion

        #region Game's [Menu] Event Handlers
        private void BtnHostGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Board.Focus();
            this.network.StartHost();
        }

        private void BtnJoinGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.network.HostIP = "127.0.0.1";
            this.network.SendMessageToHost(new GameMessage());
        }

        private void BtnObserveGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.network.StopHost();
        }

        private void BtnLoadReplay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Board.Focus();
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

        private void BtnHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }

        private void BtnAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Board.Focus();
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog(this);
        }
        #endregion

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

        private void Board_MouseDown(object sender, MouseEventArgs e) {
            GameHex hex = this.Board.GetClickedHex(e.X, e.Y);
            if(hex != null) {
                MessageBox.Show(hex.Name);
            }
        }

        #region Game's [Record Panel] Event Handlers
        private void SelectTabMoves() {
            this.PbxTab.Image = Properties.Resources.TabMoves;
            this.BtnTabNotes.BackColor = Color.FromArgb(20, 39, 48);
            this.BtnTabNotes.ForeColor = Color.FromArgb(132, 132, 132);
            this.BtnTabMoves.BackColor = Color.FromArgb(30, 61, 70);
            this.BtnTabMoves.ForeColor = Color.White;

            this.PnlMoves.Visible = true;
            this.PnlNotes.Visible = false;
            this.WbrMovesList.Document.Focus();
        }

        private void SelectTabNotes() {
            this.PbxTab.Image = Properties.Resources.TabNotes;
            this.BtnTabMoves.BackColor = Color.FromArgb(20, 39, 48);
            this.BtnTabMoves.ForeColor = Color.FromArgb(132, 132, 132);
            this.BtnTabNotes.BackColor = Color.FromArgb(30, 61, 70);
            this.BtnTabNotes.ForeColor = Color.White;

            this.PnlNotes.Visible = true;
            this.PnlMoves.Visible = false;
            this.TbxNotes.Focus();
        }

        private void BtnTabMoves_MouseDown(object sender, MouseEventArgs e) {
            this.SelectTabMoves();
        }

        private void BtnTabNotes_MouseDown(object sender, MouseEventArgs e) {
            this.SelectTabNotes();
        }
        #endregion

        #region Game's [Input Panel] Event Handlers
        private void CbxPrivateComment_MouseDown(object sender, MouseEventArgs e) {
            this.TbxComment.Focus();
            (sender as CheckBox).Checked = !(sender as CheckBox).Checked;
        }
        #endregion

        #region Game's [Round Panel] Event Handlers
        private void PbxRound_Paint(object sender, PaintEventArgs e) {
            if(this.gameBoard != null) {
                Graphics g = e.Graphics;
                Bitmap round;
                switch(this.gameBoard.CurMainRound) {
                    case 1: round = Properties.Resources.Round1; break;
                    case 2: round = Properties.Resources.Round2; break;
                    case 3: round = Properties.Resources.Round3; break;
                    case 4: round = Properties.Resources.Round4; break;
                    case 5: round = Properties.Resources.Round5; break;
                    case 6: round = Properties.Resources.Round6; break;
                    case 7: round = Properties.Resources.Round7; break;
                    case 8: round = Properties.Resources.Round8; break;
                    default: round = Properties.Resources.Round1; break;
                }
                g.DrawImage(round,
                    new Rectangle(
                        GameUIConsts.RoundNumLeft,
                        GameUIConsts.RoundNumTop,
                        GameUIConsts.RoundNumWidth,
                        GameUIConsts.RoundNumHeight
                    )
                );
            }
        }
        #endregion

        private Bitmap GetCardImageByCharacter(int character) {
            Bitmap img = null;
            switch(character) {
                case GameTypes.CharacterNone: img = Properties.Resources.CardBack; break;
                case GameTypes.CharacterBert: img = Properties.Resources.CardBert; break;
                case GameTypes.CharacterGoodley: img = Properties.Resources.CardGoodley; break;
                case GameTypes.CharacterGull: img = Properties.Resources.CardGull; break;
                case GameTypes.CharacterHolmes: img = Properties.Resources.CardHolmes; break;
                case GameTypes.CharacterLestrade: img = Properties.Resources.CardLestrade; break;
                case GameTypes.CharacterSmith: img = Properties.Resources.CardSmith; break;
                case GameTypes.CharacterStealthy: img = Properties.Resources.CardStealthy; break;
                case GameTypes.CharacterWatson1: img = Properties.Resources.CardWatson; break;
                default: img = Properties.Resources.None; break;
            }
            return img;
        }

        public void SetGameCardCharacter(int index, int character) {
            PictureBox pbx = null;
            switch(index) {
                case 1: pbx = PbxCard1; break;
                case 2: pbx = PbxCard2; break;
                case 3: pbx = PbxCard3; break;
                case 4: pbx = PbxCard4; break;
            }
            if(pbx != null) {
                Bitmap img = this.GetCardImageByCharacter(character);
                pbx.Image = img;
            }
        }

        public void SetHelpCardsCharacter(int[] cards) {
            if(cards.Length < 8) return;
            this.PbxHelpCard1.Image = this.GetCardImageByCharacter(cards[0]);
            this.PbxHelpCard2.Image = this.GetCardImageByCharacter(cards[1]);
            this.PbxHelpCard3.Image = this.GetCardImageByCharacter(cards[2]);
            this.PbxHelpCard4.Image = this.GetCardImageByCharacter(cards[3]);
            this.PbxHelpCard5.Image = this.GetCardImageByCharacter(cards[4]);
            this.PbxHelpCard6.Image = this.GetCardImageByCharacter(cards[5]);
            this.PbxHelpCard7.Image = this.GetCardImageByCharacter(cards[6]);
            this.PbxHelpCard8.Image = this.GetCardImageByCharacter(cards[7]);
        }

        private void SelectAGameCardSelectByIndex(int index, int side) {
            PictureBox pbx = null;
            switch(index) {
                case 1: pbx = PbxCardSelect1; break;
                case 2: pbx = PbxCardSelect2; break;
                case 3: pbx = PbxCardSelect3; break;
                case 4: pbx = PbxCardSelect4; break;
            }
            if(pbx != null) {
                if(side == GameTypes.SideInspector) {
                    pbx.Image = Properties.Resources.CardSelectInspector;
                } else {
                    pbx.Image = Properties.Resources.CardSelectJack;
                }
            }
        }

        public void SelectAGameCardByCharacter(int character, int side) {
            for(int i = 0; i < 4; i++) {
                if(this.gameBoard.CurCards[i] == character) {
                    this.SelectAGameCardSelectByIndex(i + 1, side);
                    break;
                }
            }
        }

        public void UnselectAllCards() {
            PbxCardSelect1.Image = null;
            PbxCardSelect2.Image = null;
            PbxCardSelect3.Image = null;
            PbxCardSelect4.Image = null;
        }

        public void SelectWitnessCard() {
            this.PbxWintessSelect.Image = Properties.Resources.CardSelectWintess;
        }

        public void UnselectWitnessCard() {
            this.PbxWintessSelect.Image = null;
        }

        public void SetWitnessCard(int type) {
            if(type == GameTypes.JackWitness) {
                this.PbxWitness.Image = Properties.Resources.CardWitness;
            } else {
                this.PbxWitness.Image = Properties.Resources.CardNoWitness;
            }
        }
    }
}
