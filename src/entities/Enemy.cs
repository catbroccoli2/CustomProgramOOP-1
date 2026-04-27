using SplashKitSDK;

namespace FirstFantasy
{
    public class Enemy : Character
    {
        private double _speed;
        private Player _target;
        public IEnemyStrategy strategy {get; set;}

        public Enemy(string name, double startX, double startY, int maxHP, int attack, double speed, Player target)
            : base(name, maxHP, attack, startX, startY, 0)
        {
            _speed = speed;
            _target = target;
            strategy = new AggressiveStrategy();
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
        public override int TakeDamage(int amount)
        {
            int actualDamage = base.TakeDamage(amount);

            
            if (HP > 0 && HP <= MaxHP / 4 && !(strategy is EnragedStrategy))
            {
                Attack += 5;
                strategy = new EnragedStrategy();
            }

            return actualDamage;
        }

        public override void Draw()
        {
            if (!IsActive) return;
            SplashKit.FillRectangle(Color.Green, X, Y, width, height);
        }

        public ICommand DecideAction(Player target)
        {
            return strategy.ChooseAction(this, _target);
        }
    }
}