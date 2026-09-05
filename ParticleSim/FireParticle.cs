using System.Numerics;
using Raylib_cs;

public class FireParticle
{
    
    public Vector2 position = new Vector2();
    public Vector2 velocity = new Vector2();
    public float accelaration;
    public float lifeTime;
    public float radius;
    public float driftTimer;
    public Color fireColor;

    public FireParticle(int _X, int _Y, float _accelaration, int _velX, int _velY, float _radius, float _lifeTime, float _driftTimer, Color _color)
    {
        
        position.X = _X;
        position.Y = _Y;
        accelaration = _accelaration;
        velocity.X = _velX;
        velocity.Y = _velY;
        radius = _radius;
        lifeTime = _lifeTime;
        driftTimer = _driftTimer;
        fireColor = _color;

    }


}