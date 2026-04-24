using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace FirstFantasy
{
    public class BattleState : IStates
    {
        private GameState _game;
        private Enemy _enemy;

        public BattleState(GameState game, Enemy enemy)
        {
            _game = game;
            _enemy = enemy;
        }

        public void OnEnter()
        {
            Console.WriteLine($"Entered battle with: {_enemy.Name}");

        }

        public void OnExit()
        {
            Console.WriteLine("Battle ended");

        }

        public void HandleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))//placeholder
            {
                _enemy.TakeDamage(999);
                _game.ChangeState(new ExploringState(_game));


            }


        }

        public void Update()
        {
            //battle logic
        }

        public void Draw()
        {
            _game.GameWindow.Clear(Color.Black);
            SplashKit.DrawText(
                $"BATTLE WITH {_enemy.Name.ToUpper()}!",
                Color.White,
                300, 250);
            SplashKit.DrawText(
                "Press SPACE",
                Color.White,
                320, 300);
        }
    }
}