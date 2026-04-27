using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace FirstFantasy
{
    public class GameState
    {
        public Window GameWindow { get; }
        public Player Player { get; }
        public List<Entity> Entities { get; }

        private IStates _currentState;

        public GameState(Window window)
        {
            GameWindow = window;
            Player = new Player(400, 400, 3, 15);

            Entities = new List<Entity>();
            Entities.Add(Player);
            Entities.Add(new Enemy("Goblin", 200, 200, 100, 8, 1.5, Player));
            Enemy orc = new Enemy("Orc", 600, 200, 50, 12, 1.0, Player);
            orc.strategy = new DefensiveStrategy();
            Entities.Add(orc);


            _currentState = new ExploringState(this);
            _currentState.OnEnter();



        }

        public void ChangeState(IStates newState)
        {
            _currentState.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }

        public void Tick()
        {
            _currentState.HandleInput();
            _currentState.Update();
            _currentState.Draw();
        }
    }
}