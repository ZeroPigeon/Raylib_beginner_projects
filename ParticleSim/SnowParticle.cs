using System.Numerics;
using Raylib_cs;

public class SnowFlake
{
    
    public Vector2 position = new Vector2();   
    public Vector2 velocity = new Vector2();
    public float flakeRadius;
    public float driftTimer;

    public SnowFlake(int _X, int _Y, int _velX, int _velY, float _radius, float _driftTimer)
    {
        
        position.X = _X;
        position.Y = _Y;
        velocity.X = _velX;
        velocity.Y = _velY;
        flakeRadius = _radius;
        driftTimer = _driftTimer;

    }

}