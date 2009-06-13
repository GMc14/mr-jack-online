using System;

namespace MrJack
{
    public class BoardStatus
    {
        public int CurMainRound;
        public int CurSubRound;
        public string[] Characters;
        public string[] Covers;
        public string[] Gasslights;
        public string[] Cordons;
        public int[] Cards;
        public int[] CurCards;
        public int[] CurInspectorAlibiCards;
        public int[] CurJackAlibiCards;
        public string CurPath;
        public int GameResult;
        public int GameMode;
        public int CurSide;
        public string SelectedHex;

        public BoardStatus() {
            this.InitBoard();
        }

        private void InitBoard() {
            this.CurMainRound = 1;
            this.CurSubRound = 0;

            this.Characters = new string[28] { "", "", "i8", "", "m10", "", "e9", "", "g5", "", "e5", "", "g8", "", "i4", "", "", "", "", "", "", "", "", "", "a3", "", "", "" };
            this.Covers = new string[2] { "c2", "l12" };
            this.Gasslights = new string[6] { "b2", "l11", "c7", "k6", "f5", "h8" };
            this.Cordons = new string[2] { "SW", "NE" };
            this.Cards = new int[8] { 2, 4, 6, 8, 10, 12, 14, 16 };
        }
    }
}
