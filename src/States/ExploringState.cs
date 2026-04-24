using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace FirstFantasy
{
    public class ExploringState : IStates
    {
        private GameState _game;

        public ExploringState(GameState game)
        {
            _game = game;

        }

        public void OnEnter() { }
        public void OnExit() { }
        public void HandleInput() { }
        public void Update()
        {
            foreach (Entity e in _game.Entities)
            {
                e.Update();
            }

            //collision detection
            foreach (Entity e in _game.Entities)
            {
                if (e is Enemy enemy && enemy.IsActive)
                {
                    if (_game.Player.CollidesWith(enemy))
                    {
                        _game.ChangeState(new BattleState(_game, enemy));
                        return;
                    }
                }
            }
        }

        public void Draw()
        {
            _game.GameWindow.Clear(Color.White);

            foreach (Entity e in _game.Entities)
            {
                e.Draw();
            }
        }
    }
}