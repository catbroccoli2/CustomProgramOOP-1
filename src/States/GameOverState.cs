using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public class GameOverState : IStates
    {
        private GameState _game;
        public GameOverState(GameState game)
        {
            _game = game;
        }
        
        public void OnEnter(){}
        public void OnExit(){}
        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                _game.Player.Reset();
                _game.Player.MoveTo(500, 100);
                _game.ChangeState(new ExploringState(_game));
            }
        }
        public void Update(){}
        public void Draw()
        {
            SplashKit.ClearScreen(Color.Black);
            SplashKit.DrawText("GAME OVER!", Color.White, 350, 300);
            SplashKit.DrawText("Press Space to return", Color.White, 320, 320);
        }
    }
}