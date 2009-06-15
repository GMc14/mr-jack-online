using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MrJack
{
    public partial class CtlBoard : UserControl
    {
        private const int NullCoord = -22;

        private const int TopPos = -10;
        private const int LeftPos = -26;

        private const int HexTopPos = 353;
        private const int HexLeftPos = 19;

        private static readonly int NONE = GameTypes.HexNone;
        private static readonly int EXIT = GameTypes.HexExit;
        private static readonly int BUILDING = GameTypes.HexBuilding;
        private static readonly int GASSLIGHT = GameTypes.HexGasslight;
        private static readonly int MANHOLE = GameTypes.HexManhole;
        private static readonly int STREET = GameTypes.HexStreet;

        private readonly int[,] EmptyBoard = new int[,]{
            {EXIT,EXIT,EXIT,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,EXIT},
            {EXIT,EXIT,EXIT,EXIT,NONE,NONE,MANHOLE,MANHOLE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,EXIT,EXIT,EXIT,EXIT},
            {NONE,EXIT,EXIT,STREET,STREET,STREET,STREET,BUILDING,BUILDING,BUILDING,BUILDING,STREET,STREET,GASSLIGHT,GASSLIGHT,STREET,STREET,EXIT,EXIT,EXIT},
            {NONE,NONE,NONE,NONE,GASSLIGHT,GASSLIGHT,STREET,STREET,BUILDING,BUILDING,STREET,STREET,STREET,STREET,MANHOLE,MANHOLE,NONE,NONE,NONE,NONE},
            {NONE,NONE,NONE,BUILDING,BUILDING,STREET,STREET,BUILDING,BUILDING,STREET,STREET,BUILDING,BUILDING,STREET,STREET,NONE,NONE,NONE,NONE,NONE},
            {NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE,NONE,NONE},
            {NONE,MANHOLE,MANHOLE,GASSLIGHT,GASSLIGHT,BUILDING,BUILDING,MANHOLE,MANHOLE,BUILDING,BUILDING,GASSLIGHT,GASSLIGHT,BUILDING,BUILDING,STREET,STREET,NONE,NONE,NONE},
            {NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE},
            {NONE,NONE,NONE,STREET,STREET,BUILDING,BUILDING,GASSLIGHT,GASSLIGHT,BUILDING,BUILDING,MANHOLE,MANHOLE,BUILDING,BUILDING,GASSLIGHT,GASSLIGHT,MANHOLE,MANHOLE,NONE},
            {NONE,NONE,NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE},
            {NONE,NONE,NONE,NONE,NONE,STREET,STREET,BUILDING,BUILDING,STREET,STREET,BUILDING,BUILDING,STREET,STREET,BUILDING,BUILDING,NONE,NONE,NONE},
            {NONE,NONE,NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,BUILDING,BUILDING,STREET,STREET,GASSLIGHT,GASSLIGHT,NONE,NONE,NONE,NONE},
            {NONE,EXIT,EXIT,MANHOLE,MANHOLE,GASSLIGHT,GASSLIGHT,STREET,STREET,BUILDING,BUILDING,BUILDING,BUILDING,STREET,STREET,STREET,STREET,EXIT,EXIT,NONE},
            {EXIT,EXIT,EXIT,EXIT,STREET,STREET,STREET,STREET,STREET,STREET,MANHOLE,MANHOLE,STREET,STREET,NONE,NONE,EXIT,EXIT,EXIT,EXIT},
            {EXIT,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,EXIT,EXIT,EXIT}
        };

        private bool showCoordinates;
        public bool ShowCoordinates {
            get { return this.showCoordinates; }
            set {
                this.showCoordinates = value;
                this.Invalidate();
            }
        }

        private bool highlightMoves;
        public bool HighlightMoves {
            get { return this.highlightMoves; }
            set { 
                this.highlightMoves = value;
                this.Invalidate();
            }
        }

        public BoardStatus Game;
        public GameHex SelectedHex;

        public CtlBoard() {
            InitializeComponent();
            this.SelectedHex = new GameHex();
        }

        private void CtlBoard_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            string hexName = string.Empty;
            if(this.Game != null) {
                for(int i = 0; i < this.Game.Covers.Length; i++) {
                    hexName = this.Game.Covers[i];
                    this.DrawCover(g, this.GetCoordXByCoordName(hexName), this.GetCoordYByCoordName(hexName));
                }
                for(int i = 0; i < this.Game.Gasslights.Length; i++) {
                    hexName = this.Game.Gasslights[i];
                    if(hexName != string.Empty) {
                        this.DrawGasslight(g, this.GetCoordXByCoordName(hexName), this.GetCoordYByCoordName(hexName), i + 1);
                    }
                }
                for(int i = 0; i < this.Game.Cordons.Length; i++) {
                    hexName = this.Game.Cordons[i];
                    this.DrawCordon(g, this.GetExitCoordByCoordName(hexName));
                }
                for(int i = 0; i < this.Game.Characters.Length; i++) {
                    hexName = this.Game.Characters[i];
                    if(hexName != string.Empty) {
                        this.DrawCharacter(g, this.GetCoordXByCoordName(hexName), this.GetCoordYByCoordName(hexName), i);
                    }
                }
                if(this.Game.NeedSelectWatsonDir) {
                    this.DrawWatsonDir(g, this.Game.NeedSelectWatsonDirX, this.Game.NeedSelectWatsonDirY, false);
                }
                if(this.highlightMoves && this.Game.CurPath != "") {
                    string[] curPath = this.Game.CurPath.Split(',');
                    for(int i = 0; i < curPath.Length; i++) {
                        hexName = curPath[i];
                        if(i == 0) {
                            this.DrawPathFrom(g, this.GetCoordXByCoordName(hexName), this.GetCoordYByCoordName(hexName));
                        } else if(i == curPath.Length - 1) {
                            this.DrawPathTo(g, this.GetCoordXByCoordName(hexName), this.GetCoordYByCoordName(hexName));
                        } else {
                            this.DrawPathVia(g, this.GetCoordXByCoordName(hexName), this.GetCoordYByCoordName(hexName));
                        }
                    }
                }
            }
            g.DrawImage(
                Properties.Resources.CardHelp,
                new Rectangle(
                    GameUIConsts.CardHelpBoardLeft,
                    GameUIConsts.CardHelpBoardTop,
                    GameUIConsts.CardHelpWidth,
                    GameUIConsts.CardHelpHeight
                )
            );
            if(this.showCoordinates) {
                g.DrawImage(
                    Properties.Resources.Coordinates,
                    new Rectangle(0, 0, this.Width, this.Height)
                );
            }
        }

        public GameHex GetClickedHex(int mouseX, int mouseY) {
            this.HexClickHandler(mouseX, mouseY);
            if(this.SelectedHex != null) {
                return this.SelectedHex;
            } else {
                return null;
            }
        }

        private void DrawCharacter(Graphics g, int x, int y, int character) {
            if(x == NullCoord || y == NullCoord) return;
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 58, 52);
            Bitmap person = Properties.Resources.None;
            switch(character) {
                case GameTypes.CharacterBert: person = Properties.Resources.Bert; break;
                case GameTypes.CharacterBertInnocent: person = Properties.Resources.BertInnocent; break;
                case GameTypes.CharacterGoodley: person = Properties.Resources.Goodley; break;
                case GameTypes.CharacterGoodleyInnocent: person = Properties.Resources.GoodleyInnocent; break;
                case GameTypes.CharacterGull: person = Properties.Resources.Gull; break;
                case GameTypes.CharacterGullInnocent: person = Properties.Resources.GullInnocent; break;
                case GameTypes.CharacterHolmes: person = Properties.Resources.Holmes; break;
                case GameTypes.CharacterHolmesInnocent: person = Properties.Resources.HolmesInnocent; break;
                case GameTypes.CharacterLestrade: person = Properties.Resources.Lestrade; break;
                case GameTypes.CharacterLestradeInnocent: person = Properties.Resources.LestradeInnocent; break;
                case GameTypes.CharacterSmith: person = Properties.Resources.Smith; break;
                case GameTypes.CharacterSmithInnocent: person = Properties.Resources.SmithInnocent; break;
                case GameTypes.CharacterStealthy: person = Properties.Resources.Stealthy; break;
                case GameTypes.CharacterStealthyInnocent: person = Properties.Resources.StealthyInnocent; break;
                case GameTypes.CharacterWatson1: person = Properties.Resources.Watson1; break;
                case GameTypes.CharacterWatsonInnocent1: person = Properties.Resources.WatsonInnocent1; break;
                case GameTypes.CharacterWatson2: person = Properties.Resources.Watson2; break;
                case GameTypes.CharacterWatsonInnocent2: person = Properties.Resources.WatsonInnocent2; break;
                case GameTypes.CharacterWatson3: person = Properties.Resources.Watson3; break;
                case GameTypes.CharacterWatsonInnocent3: person = Properties.Resources.WatsonInnocent3; break;
                case GameTypes.CharacterWatson4: person = Properties.Resources.Watson4; break;
                case GameTypes.CharacterWatsonInnocent4: person = Properties.Resources.WatsonInnocent4; break;
                case GameTypes.CharacterWatson5: person = Properties.Resources.Watson5; break;
                case GameTypes.CharacterWatsonInnocent5: person = Properties.Resources.WatsonInnocent5; break;
                case GameTypes.CharacterWatson6: person = Properties.Resources.Watson6; break;
                case GameTypes.CharacterWatsonInnocent6: person = Properties.Resources.WatsonInnocent6; break;
                default: person = Properties.Resources.None; break;
            }
            g.DrawImage(person, rect);
        }

        private void DrawGasslight(Graphics g, int x, int y, int gasslight) {
            if(x == NullCoord || y == NullCoord) return;
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 58, 52);
            Bitmap light;
            switch(gasslight) {
                case GameTypes.Gasslight1: light = Properties.Resources.Light1; break;
                case GameTypes.Gasslight2: light = Properties.Resources.Light2; break;
                case GameTypes.Gasslight3: light = Properties.Resources.Light3; break;
                case GameTypes.Gasslight4: light = Properties.Resources.Light4; break;
                case GameTypes.Gasslight5:
                case GameTypes.Gasslight6: light = Properties.Resources.LightAlways; break;
                default: light = Properties.Resources.None; break;
            }
            g.DrawImage(light, rect);
        }

        private void DrawCordon(Graphics g, int direction) {
            if(direction == NullCoord) return;
            Rectangle rect = new Rectangle();
            switch(direction) {
                case GameTypes.ExitNW: rect = new Rectangle(27, 24, 52, 29); break;
                case GameTypes.ExitNE: rect = new Rectangle(536, 24, 52, 29); break;
                case GameTypes.ExitSW: rect = new Rectangle(52, 448, 52, 29); break;
                case GameTypes.ExitSE: rect = new Rectangle(546, 446, 52, 29); break;
            }
            g.DrawImage(Properties.Resources.Cordon, rect);
        }

        private void DrawCordonPath(Graphics g, int direction) {
            if(direction == NullCoord) return;
            Rectangle rect = new Rectangle();
            switch(direction) {
                case GameTypes.ExitNW: rect = new Rectangle(25, 22, 56, 33); break;
                case GameTypes.ExitNE: rect = new Rectangle(534, 22, 56, 33); break;
                case GameTypes.ExitSW: rect = new Rectangle(50, 446, 56, 33); break;
                case GameTypes.ExitSE: rect = new Rectangle(544, 444, 56, 33); break;
            }
            g.DrawImage(Properties.Resources.CordonPath, rect);
        }

        private void DrawCover(Graphics g, int x, int y) {
            if(x == NullCoord || y == NullCoord) return;
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 58, 52);
            g.DrawImage(Properties.Resources.Cover, rect);
        }

        private void DrawPathFrom(Graphics g, int x, int y) {
            if(x == NullCoord || y == NullCoord) return;
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 59, 53);
            g.DrawImage(Properties.Resources.HexFrom, rect);
        }

        private void DrawPathVia(Graphics g, int x, int y) {
            if(x == NullCoord || y == NullCoord) return;
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 59, 53);
            g.DrawImage(Properties.Resources.HexVia, rect);
        }

        private void DrawPathTo(Graphics g, int x, int y) {
            if(x == NullCoord || y == NullCoord) return;
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 59, 53);
            g.DrawImage(Properties.Resources.HexTo, rect);
        }

        private void DrawEscape(Graphics g, int charactor, int direction) {
            if(direction == NullCoord) return;
            Rectangle rect = new Rectangle();
            Rectangle rectShape = new Rectangle();
            switch(direction) {
                case GameTypes.ExitNW: rect = new Rectangle(23, 14, 58, 52); rectShape = new Rectangle(23, 11, 59, 59); break;
                case GameTypes.ExitNE: rect = new Rectangle(536, 12, 58, 52); rectShape = new Rectangle(536, 9, 59, 59); break;
                case GameTypes.ExitSW: rect = new Rectangle(49, 438, 58, 52); rectShape = new Rectangle(49, 435, 59, 59); break;
                case GameTypes.ExitSE: rect = new Rectangle(546, 436, 58, 52); rectShape = new Rectangle(546, 433, 59, 59); break;
            }
            Bitmap person = Properties.Resources.None;
            switch(charactor) {
                case GameTypes.CharacterBert: person = Properties.Resources.Bert; break;
                case GameTypes.CharacterGoodley: person = Properties.Resources.Goodley; break;
                case GameTypes.CharacterGull: person = Properties.Resources.Gull; break;
                case GameTypes.CharacterHolmes: person = Properties.Resources.Holmes; break;
                case GameTypes.CharacterLestrade: person = Properties.Resources.Lestrade; break;
                case GameTypes.CharacterSmith: person = Properties.Resources.Smith; break;
                case GameTypes.CharacterStealthy: person = Properties.Resources.Stealthy; break;
                case GameTypes.CharacterWatson1: person = Properties.Resources.Watson1; break;
                case GameTypes.CharacterWatson2: person = Properties.Resources.Watson2; break;
                case GameTypes.CharacterWatson3: person = Properties.Resources.Watson3; break;
                case GameTypes.CharacterWatson4: person = Properties.Resources.Watson4; break;
                case GameTypes.CharacterWatson5: person = Properties.Resources.Watson5; break;
                case GameTypes.CharacterWatson6: person = Properties.Resources.Watson6; break;
                default: person = Properties.Resources.None; break;
            }
            g.DrawImage(person, rect);
            g.DrawImage(Properties.Resources.Escape, rectShape);
        }

        private void DrawWatsonDir(Graphics g, int x, int y, bool isWatsonInnocent) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2 - 8, HexTopPos - y * 52 + x * 26 - 16, 75, 85);
            if(!isWatsonInnocent) {
                g.DrawImage(Properties.Resources.WatsonDir, rect);
            } else {
                g.DrawImage(Properties.Resources.WatsonInnocentDir, rect);
            }
        }

        private int GetCoordXByCoordName(string name) {
            if(name != string.Empty) {
                try {
                    int x = (int)(char.Parse(name.Substring(0, 1))) - 97;
                    return x;
                } catch(Exception) {
                    return NullCoord;
                }
            }
            return NullCoord;
        }

        private int GetCoordYByCoordName(string name) {
            if(name != string.Empty) {
                try {
                    int y = Int32.Parse(name.Substring(1)) - 1;
                    return y;
                } catch(Exception) {
                    return NullCoord;
                }
            }
            return NullCoord;
        }

        private int GetExitCoordByCoordName(string name) {
            switch(name) {
                case "NE": return GameTypes.ExitNE;
                case "NW": return GameTypes.ExitNW;
                case "SE": return GameTypes.ExitSE;
                case "SW": return GameTypes.ExitSW;
                default: return NullCoord;
            }
        }

        private Point GetClickedRectanglePos(int mouseX, int mouseY) {
            int dx = mouseX - LeftPos;
            int dy = mouseY - TopPos;
            int indexX = (int)Math.Floor((decimal)dx / 44);
            int indexY = (int)Math.Floor((decimal)dy / 26);

            GraphicsPath gp = new GraphicsPath();
            if((indexX % 2 == 1 && indexY % 2 == 1) || (indexX % 2 == 0 && indexY % 2 == 0)) {
                Point[] pts = { new Point(LeftPos + indexX * 44, TopPos + indexY * 26), new Point(LeftPos + indexX * 44, TopPos + indexY * 26 + 25), new Point(LeftPos + indexX * 44 + 13, TopPos + indexY * 26 + 25) };
                gp.AddPolygon(pts);
                if(gp.IsVisible(mouseX, mouseY)) {
                    indexX--;
                }
            } else {
                Point[] pts = { new Point(LeftPos + indexX * 44, TopPos + indexY * 26), new Point(LeftPos + indexX * 44 + 13, TopPos + indexY * 26), new Point(LeftPos + indexX * 44, TopPos + indexY * 26 + 25) };
                gp.AddPolygon(pts);
                if(gp.IsVisible(mouseX, mouseY)) {
                    indexX--;
                }
            }
            return new Point(indexX, indexY);
        }

        private Point ConvertRectanglePosToHexCoords(int x, int y) {
            int indexX = x - 1;
            int indexY = y;

            if(indexX % 2 == 0) {
                if(indexY % 2 == 1) {
                    indexY = (15 - indexY + indexX) / 2;
                } else {
                    indexY = (14 - indexY + indexX) / 2;
                }
            } else {
                if(indexY % 2 == 0) {
                    indexY = (15 - indexY + indexX) / 2;
                } else {
                    indexY = (14 - indexY + indexX) / 2;
                }
            }
            return new Point(indexX, indexY);
        }

        private void HexClickHandler(int mouseX, int mouseY) {
            Point pos = this.GetClickedRectanglePos(mouseX, mouseY);
            if(EmptyBoard[pos.X, pos.Y] != NONE) {
                if(this.SelectedHex == null) {
                    this.SelectedHex = new GameHex();
                }
                this.SelectedHex.HexType = EmptyBoard[pos.X, pos.Y];
                if(EmptyBoard[pos.X, pos.Y] == EXIT) {
                    this.SelectedHex.X = -1;
                    if(pos.X <= 2) {
                        if(pos.Y <= 3) {
                            this.SelectedHex.Y = GameTypes.ExitNW;
                        } else {
                            this.SelectedHex.Y = GameTypes.ExitSW;
                        }
                    } else {
                        if(pos.Y <= 3) {
                            this.SelectedHex.Y = GameTypes.ExitNE;
                        } else {
                            this.SelectedHex.Y = GameTypes.ExitSE;
                        }
                    }
                } else {
                    Point hex = this.ConvertRectanglePosToHexCoords(pos.X, pos.Y);
                    this.SelectedHex.X = hex.X;
                    this.SelectedHex.Y = hex.Y;
                }
            } else {
                this.SelectedHex = null;
            }
        }
    }
}
