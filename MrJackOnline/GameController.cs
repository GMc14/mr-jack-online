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
    }
}
