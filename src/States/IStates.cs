using System;

namespace FirstFantasy
{
    public interface IStates
    {
        void OnEnter();
        void OnExit();
        void HandleInput();
        void Update();
        void Draw();

    }
}