using System.Numerics;
using Raylib_cs;

public class FireWork
{

    public Vector2 position;
    public Vector2 velocity;
    public Vector2 targetPos;
    public float radius;
    public float lifeTime;
    public Color color;

    public FireWork(float _X, float _Y, float _velX, float _vleY, float _target_X, float _target_Y, float _radius, float _lifeTime, Color _color)
    {
        
        position.X = _X;
        position.Y = _Y;
        velocity.X = _velX;
        velocity.Y = _vleY;
        targetPos.X = _target_X;
        targetPos.Y = _target_Y;
        radius = _radius;
        lifeTime = _lifeTime;
        color = _color;

    }

}