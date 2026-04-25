using System;
using System.Collections.Generic;
using System.Data;
using SplashKitSDK;

namespace FirstFantasy
{
    public class BattleState : IStates
    {
        private GameState _game;
        private Enemy _enemy;
        private Queue<ICommand> _commandQueue;
        private List<string> _combatLog;
        private bool _playerTurn;

        public BattleState(GameState game, Enemy enemy)
        {
            _game = game;
            _enemy = enemy;
            _commandQueue = new Queue<ICommand>();
            _combatLog = new List<string>();
            _playerTurn = true;
        }

        public void OnEnter()
        {
            Console.WriteLine($"Entered battle with: {_enemy.Name}");

        }

        public void OnExit()
        {
            Console.WriteLine("Battle ended");
            _combatLog.Clear();

        }

        public void HandleInput()
        {
            if (!_playerTurn) return;
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))//placeholder
            {
                _commandQueue.Enqueue(new AttackCommand(_game.Player, _enemy));
                _playerTurn = false;
            }


        }

        public void Update()
        {
            if (_commandQueue.Count > 0)
            {
                //processed commands in queue
                ICommand cmd = _commandQueue.Dequeue();
                if (cmd.CanExecute())
                {
                    cmd.Execute();
                    _combatLog.Add(cmd.Describe()); // add to combat log thingy
                }

                //victory check
                if (!_enemy.IsAlive)
                {
                    _combatLog.Add($"{_enemy.Name} has been defeated!");
                    _game.ChangeState(new ExploringState(_game));
                    return;
                }

                //defeat 
                if (!_game.Player.IsAlive)
                {
                    _combatLog.Add($"The player has been defeated!");
                    _game.ChangeState(new ExploringState(_game));
                    return;

                }

                if (!_playerTurn)
                {
                    EnemyTurn();
                    _playerTurn = true;
                }
            }
        }

        public void EnemyTurn()
        {
            _commandQueue.Enqueue(new AttackCommand(_enemy, _game.Player));
        }
        public void Draw()
        {
            _game.GameWindow.Clear(Color.Black);
            
            // Draw enemy
            SplashKit.DrawText($"{_enemy.Name}", Color.White, 350, 100);
            SplashKit.DrawText($"HP: {_enemy.HP}/{_enemy.MaxHP}",
                Color.White, 350, 130);

            // Draw player status
            SplashKit.DrawText($"{_game.Player.Name}", Color.White, 50, 450);
            SplashKit.DrawText($"HP: {_game.Player.HP}/{_game.Player.MaxHP}",
                Color.White, 50, 480);

            // Draw combat log (last 4 entries)
            int startY = 320;
            int start = Math.Max(0, _combatLog.Count - 4);
            for (int i = start; i < _combatLog.Count; i++)
            {
                SplashKit.DrawText(_combatLog[i],
                    Color.White, 50, startY + (i - start) * 20);
            }

        }
    }
}