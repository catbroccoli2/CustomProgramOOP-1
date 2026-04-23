using SplashKitSDK;

namespace FirstFantasy
{
    public class Enemy : Character
    {
        private double _speed;
        private Player _target;

        public Enemy(string name, double startX, double startY, int maxHP, double speed, Player target)
            : base(name, 100, 100, startX, startY)
        {
            _speed = speed;
            _target = target;
        }

        public override void Update()
        {
            if (!IsActive) return;

            double dx = _target.X - X;
            double dy = _target.Y - Y;
            double distance = System.Math.Sqrt(dx * dx + dy * dy);

            if (distance > 1)
            {
                X += (dx / distance) * _speed;
                Y += (dy / distance) * _speed;
            }
        }

        public override void Draw()
        {
            if (!IsActive) return;
            SplashKit.FillRectangle(Color.Green, X, Y, width, height);
        }
    }
}