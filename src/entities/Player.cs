using SplashKitSDK;

namespace FirstFantasy
{
    public class Player : Character
    {
        private double _speed;

        public Player(double startX, double startY, double speed)
            : base("Hero", 100, 100, startX, startY )
        {
            _speed = speed;
        }

        public override void Update()
        {
            if (SplashKit.KeyDown(KeyCode.WKey) || SplashKit.KeyDown(KeyCode.UpKey))    Y -= _speed;
            if (SplashKit.KeyDown(KeyCode.SKey) || SplashKit.KeyDown(KeyCode.DownKey))  Y += _speed;
            if (SplashKit.KeyDown(KeyCode.AKey) || SplashKit.KeyDown(KeyCode.LeftKey))  X -= _speed;
            if (SplashKit.KeyDown(KeyCode.DKey) || SplashKit.KeyDown(KeyCode.RightKey)) X += _speed;
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color.Red, X, Y, width, height);
        }
    }
}