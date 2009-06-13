using System;

namespace MrJack
{
    public class GameController
    {
        private FrmMain game;
        private FrmWaiting frmWait;

        private int gameStatus;
        public int GameStatus {
            get { return this.gameStatus; }
            set {
                this.gameStatus = value;
                this.Update();   
            }
        }

        public GameController(FrmMain game) {
            this.game = game;
            this.GameStatus = GameTypes.GameStatusIdle;
        }

        public void Update() {
            switch(this.gameStatus) {
                case GameTypes.GameStatusWaitingPlayer:
                    frmWait = new FrmWaiting(this);
                    frmWait.ShowDialog(game);
                    break;
                case GameTypes.GameStatusPlayerJoined:
                    frmWait.Close();
                    break;
            }
        }

        public void CheckMessage(string msg) {
            this.GameStatus = GameTypes.GameStatusPlayerJoined;
        }
    }
}
