using System;

namespace MrJack
{
    public class GameController
    {
        private FrmMain game;
        private BoardStatus gameBoard;
        private BoardStatus replayBoard;

        public GameController(FrmMain game, BoardStatus gameBoard, BoardStatus replayBoard) {
            this.game = game;
            this.gameBoard = gameBoard;
            this.replayBoard = replayBoard;
        }

        public void CheckMessage(string msg) {
            this.game.PlaySoundNew();
        }

        public void UpdateCards() {
            for(int i = 0; i < 4; i++) {
                this.game.SetGameCardCharacter(i + 1, this.gameBoard.CurCards[i]);
            }
        }
        public void UpdateHelpCards() {
            this.game.SetHelpCardsCharacter(this.gameBoard.Cards);
        }
    }
}
