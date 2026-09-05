using System.Numerics;
using Raylib_cs;

public class RainDrop
{
    
    public Vector2 position = new Vector2();
    public Vector2 velocity = new Vector2();
    public int width;
    public int height;
    public float angle;

    public RainDrop(int _X, int _Y, int _width, int _height, int _velX, int _velY, float _angle)
    {
        
        position.X = _X;
        position.Y = _Y;
        width = _width;
        height = _height;
        velocity.X = _velX;
        velocity.Y = _velY;
        angle = _angle;

    }

}