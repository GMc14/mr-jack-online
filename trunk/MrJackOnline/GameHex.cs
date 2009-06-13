using System;
using System.Collections.Generic;
using System.Text;

namespace MrJack
{
    public class GameHex
    {
        private int hexType;
        public int HexType {
            get { return this.hexType; }
            set { this.hexType = value; }
        }

        private int x;
        public int X {
            get { return this.x; }
            set {
                this.x = value;
                this.UpdateName();
            }
        }

        private int y;
        public int Y {
            get { return this.y; }
            set {
                this.y = value;
                this.UpdateName();
            }
        }

        public string Name { get; set; }

        public GameHex() {
            this.HexType = GameTypes.HexNone;
            this.x = 0;
            this.y = 0;
            this.Name = string.Empty;
        }

        public GameHex(int type, int x, int y) {
            this.hexType = type;
            this.X = x;
            this.Y = y;
            this.UpdateName();
        }

        private void UpdateName() {
            if(this.hexType == GameTypes.HexExit) {
                switch(this.y) {
                    case GameTypes.ExitNE: this.Name = "NE"; break;
                    case GameTypes.ExitNW: this.Name = "NW"; break;
                    case GameTypes.ExitSE: this.Name = "SE"; break;
                    case GameTypes.ExitSW: this.Name = "SW"; break;
                }
            } else {
                this.Name = (char)(97 + X) + (Y + 1).ToString();
            }
        }
    }
}
