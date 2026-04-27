using System;
using SplashKitSDK;


namespace FirstFantasy
{
    public abstract class Entity
    {
        public static int _nextId = 0;
        public int Id { get;}
        public double Y {get; protected set;}
        public double X {get; protected set;}
        public int width {get; protected set;}
        public int height {get; protected set;}
        public bool IsActive {get; protected set;} = true;

        public Entity(double StartX, double StartY, int Width, int Height)
        {
            Id = _nextId++;
            X = StartX;
            Y = StartY;
            width = Width;
            height = Height;
        }

        public Rectangle Bounds => SplashKit.RectangleFrom(X, Y, width, height);

        public bool CollidesWith(Entity other)
        {
            return SplashKit.RectanglesIntersect(Bounds, other.Bounds);
        }

        public void MoveTo(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public abstract void Update();
        public abstract void Draw();

        
    }
}