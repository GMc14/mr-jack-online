using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MrJack
{
    public partial class CtlBoard : UserControl
    {
        // divide the board into rectanges, define the top-left rectange's position.
        private const int TopPos = -10;
        private const int LeftPos = -26;

        // divide the board into coordinates, define the hex[0,0]'s position.
        private const int HexTopPos = 353;
        private const int HexLeftPos = 19;

        // define the element of the game board.
        private const int NullIndex = -22;
        private const int NONE = -1;
        private const int EXIT = 0;
        private const int BUILDING = 1;
        private const int GASSLIGHT = 2;
        private const int MANHOLE = 3;
        private const int STREET = 4;

        // define the empty board.
        private readonly int[,] EmptyBoard = new int[,]{
            {EXIT,EXIT,EXIT,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,NONE,EXIT},
            {EXIT,EXIT,EXIT,EXIT,NONE,NONE,MANHOLE,MANHOLE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,EXIT,EXIT,EXIT,EXIT},
            {NONE,EXIT,EXIT,STREET,STREET,STREET,STREET,NONE,NONE,NONE,NONE,STREET,STREET,GASSLIGHT,GASSLIGHT,STREET,STREET,EXIT,EXIT,EXIT},
            {NONE,NONE,NONE,NONE,GASSLIGHT,GASSLIGHT,STREET,STREET,NONE,NONE,STREET,STREET,STREET,STREET,MANHOLE,MANHOLE,NONE,NONE,NONE,NONE},
            {NONE,NONE,NONE,NONE,NONE,STREET,STREET,NONE,NONE,STREET,STREET,NONE,NONE,STREET,STREET,NONE,NONE,NONE,NONE,NONE},
            {NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE,NONE,NONE},
            {NONE,MANHOLE,MANHOLE,GASSLIGHT,GASSLIGHT,NONE,NONE,MANHOLE,MANHOLE,NONE,NONE,GASSLIGHT,GASSLIGHT,NONE,NONE,STREET,STREET,NONE,NONE,NONE},
            {NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE},
            {NONE,NONE,NONE,STREET,STREET,NONE,NONE,GASSLIGHT,GASSLIGHT,NONE,NONE,MANHOLE,MANHOLE,NONE,NONE,GASSLIGHT,GASSLIGHT,MANHOLE,MANHOLE,NONE},
            {NONE,NONE,NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE},
            {NONE,NONE,NONE,NONE,NONE,STREET,STREET,NONE,NONE,STREET,STREET,NONE,NONE,STREET,STREET,NONE,NONE,NONE,NONE,NONE},
            {NONE,NONE,NONE,NONE,STREET,STREET,STREET,STREET,STREET,STREET,NONE,NONE,STREET,STREET,GASSLIGHT,GASSLIGHT,NONE,NONE,NONE,NONE},
            {NONE,EXIT,EXIT,MANHOLE,MANHOLE,GASSLIGHT,GASSLIGHT,STREET,STREET,NONE,NONE,NONE,NONE,STREET,STREET,STREET,STREET,EXIT,EXIT,NONE},
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
            set { this.highlightMoves = value; }
        }

        public CtlBoard() {
            InitializeComponent();
        }

        private void CtlBoard_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
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

        // divide the board into rectangles, this function check the current mouse position is in which rectange,
        // return the rectange's coordniate.
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

        // convert the rectangle coordinate to hex coordinate.
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

        public  Point GetClickedHexCoordsPos(int mouseX, int mouseY) {
            Point pos = this.GetClickedRectanglePos(mouseX, mouseY);
            //if(EmptyBoard[pos.X, pos.Y] != NONE) {
            //    this.selectedHex.HexType = EmptyBoard[pos.X, pos.Y];
            //    if(EmptyBoard[pos.X, pos.Y] == EXIT) {
            //        this.selectedHex.X = -1;
            //        if(pos.X <= 2) {
            //            if(pos.Y <= 3) {
            //                this.selectedHex.Y = GameTypes.ExitDirectionType.NW;
            //                return new Point(-1, GameTypes.ExitDirectionType.NW);
            //            } else {
            //                this.selectedHex.Y = GameTypes.ExitDirectionType.SW;
            //                return new Point(-1, GameTypes.ExitDirectionType.SW);
            //            }
            //        } else {
            //            if(pos.Y <= 3) {
            //                this.selectedHex.Y = GameTypes.ExitDirectionType.NE;
            //                return new Point(-1, GameTypes.ExitDirectionType.NE);
            //            } else {
            //                this.selectedHex.Y = GameTypes.ExitDirectionType.SE;
            //                return new Point(-1, GameTypes.ExitDirectionType.SE);
            //            }
            //        }
            //    } else {
            //        Point hex = this.ConvertRectanglePosToHexCoords(pos.X, pos.Y);
            //        this.selectedHex.X = hex.X;
            //        this.selectedHex.Y = hex.Y;
            //        return hex;
            //    }
            //} else {
                return new Point(NullIndex, NullIndex);
            //}
        }

        private void DrawCharacter(Graphics g, int x, int y, GameTypes.CharacterType character) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 58, 52);
            Bitmap person = Properties.Resources.None;
            switch(character) {
                case GameTypes.CharacterType.Bert: person = Properties.Resources.Bert; break;
                case GameTypes.CharacterType.BertInnocent: person = Properties.Resources.BertInnocent; break;
                case GameTypes.CharacterType.Goodley: person = Properties.Resources.Goodley; break;
                case GameTypes.CharacterType.GoodleyInnocent: person = Properties.Resources.GoodleyInnocent; break;
                case GameTypes.CharacterType.Gull: person = Properties.Resources.Gull; break;
                case GameTypes.CharacterType.GullInnocent: person = Properties.Resources.GullInnocent; break;
                case GameTypes.CharacterType.Holmes: person = Properties.Resources.Holmes; break;
                case GameTypes.CharacterType.HolmesInnocent: person = Properties.Resources.HolmesInnocent; break;
                case GameTypes.CharacterType.Lestrade: person = Properties.Resources.Lestrade; break;
                case GameTypes.CharacterType.LestradeInnocent: person = Properties.Resources.LestradeInnocent; break;
                case GameTypes.CharacterType.Smith: person = Properties.Resources.Smith; break;
                case GameTypes.CharacterType.SmithInnocent: person = Properties.Resources.SmithInnocent; break;
                case GameTypes.CharacterType.Stealthy: person = Properties.Resources.Stealthy; break;
                case GameTypes.CharacterType.StealthyInnocent: person = Properties.Resources.StealthyInnocent; break;
                case GameTypes.CharacterType.Watson1: person = Properties.Resources.Watson1; break;
                case GameTypes.CharacterType.WatsonInnocent1: person = Properties.Resources.WatsonInnocent1; break;
                case GameTypes.CharacterType.Watson2: person = Properties.Resources.Watson2; break;
                case GameTypes.CharacterType.WatsonInnocent2: person = Properties.Resources.WatsonInnocent2; break;
                case GameTypes.CharacterType.Watson3: person = Properties.Resources.Watson3; break;
                case GameTypes.CharacterType.WatsonInnocent3: person = Properties.Resources.WatsonInnocent3; break;
                case GameTypes.CharacterType.Watson4: person = Properties.Resources.Watson4; break;
                case GameTypes.CharacterType.WatsonInnocent4: person = Properties.Resources.WatsonInnocent4; break;
                case GameTypes.CharacterType.Watson5: person = Properties.Resources.Watson5; break;
                case GameTypes.CharacterType.WatsonInnocent5: person = Properties.Resources.WatsonInnocent5; break;
                case GameTypes.CharacterType.Watson6: person = Properties.Resources.Watson6; break;
                case GameTypes.CharacterType.WatsonInnocent6: person = Properties.Resources.WatsonInnocent6; break;
                default: person = Properties.Resources.None; break;
            }
            g.DrawImage(person, rect);
        }
        private void DrawGasslight(Graphics g, int x, int y, GameTypes.GasslightType gasslight) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 58, 52);
            Bitmap light;
            switch(gasslight) {
                case GameTypes.GasslightType.Light1: light = Properties.Resources.Light1; break;
                case GameTypes.GasslightType.Light2: light = Properties.Resources.Light2; break;
                case GameTypes.GasslightType.Light3: light = Properties.Resources.Light3; break;
                case GameTypes.GasslightType.Light4: light = Properties.Resources.Light4; break;
                case GameTypes.GasslightType.Light5:
                case GameTypes.GasslightType.Light6: light = Properties.Resources.LightAlways; break;
                default: light = Properties.Resources.None; break;
            }
            g.DrawImage(light, rect);
        }
        private void DrawCordon(Graphics g, GameTypes.ExitDirectionType direction) {
            Rectangle rect = new Rectangle();
            switch(direction) {
                case GameTypes.ExitDirectionType.NW: rect = new Rectangle(27, 24, 52, 29); break;
                case GameTypes.ExitDirectionType.NE: rect = new Rectangle(536, 24, 52, 29); break;
                case GameTypes.ExitDirectionType.SW: rect = new Rectangle(52, 448, 52, 29); break;
                case GameTypes.ExitDirectionType.SE: rect = new Rectangle(546, 446, 52, 29); break;
            }
            g.DrawImage(Properties.Resources.Cordon, rect);
        }
        private void DrawCordonPath(Graphics g, GameTypes.ExitDirectionType direction) {
            Rectangle rect = new Rectangle();
            switch(direction) {
                case GameTypes.ExitDirectionType.NW: rect = new Rectangle(25, 22, 56, 33); break;
                case GameTypes.ExitDirectionType.NE: rect = new Rectangle(534, 22, 56, 33); break;
                case GameTypes.ExitDirectionType.SW: rect = new Rectangle(50, 446, 56, 33); break;
                case GameTypes.ExitDirectionType.SE: rect = new Rectangle(544, 444, 56, 33); break;
            }
            g.DrawImage(Properties.Resources.CordonPath, rect);
        }
        private void DrawCover(Graphics g, int x, int y) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 58, 52);
            g.DrawImage(Properties.Resources.Cover, rect);
        }
        private void DrawPathFrom(Graphics g, int x, int y) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 59, 53);
            g.DrawImage(Properties.Resources.HexFrom, rect);
        }
        private void DrawPathVia(Graphics g, int x, int y) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 59, 53);
            g.DrawImage(Properties.Resources.HexVia, rect);
        }
        private void DrawPathTo(Graphics g, int x, int y) {
            Rectangle rect = new Rectangle(HexLeftPos + x * 44 - 2, HexTopPos - y * 52 + x * 26, 59, 53);
            g.DrawImage(Properties.Resources.HexTo, rect);
        }
        private void DrawEscape(Graphics g, GameTypes.CharacterType charactor, GameTypes.ExitDirectionType direction) {
            Rectangle rect = new Rectangle();
            Rectangle rectShape = new Rectangle();
            switch(direction) {
                case GameTypes.ExitDirectionType.NW: rect = new Rectangle(23, 14, 58, 52); rectShape = new Rectangle(23, 11, 59, 59); break;
                case GameTypes.ExitDirectionType.NE: rect = new Rectangle(536, 12, 58, 52); rectShape = new Rectangle(536, 9, 59, 59); break;
                case GameTypes.ExitDirectionType.SW: rect = new Rectangle(49, 438, 58, 52); rectShape = new Rectangle(49, 435, 59, 59); break;
                case GameTypes.ExitDirectionType.SE: rect = new Rectangle(546, 436, 58, 52); rectShape = new Rectangle(546, 433, 59, 59); break;
            }
            Bitmap person = Properties.Resources.None;
            switch(charactor) {
                case GameTypes.CharacterType.Bert: person = Properties.Resources.Bert; break;
                default: person = Properties.Resources.None; break;
            }
            g.DrawImage(person, rect);
            g.DrawImage(Properties.Resources.Escape, rectShape);
        }
    }
}
