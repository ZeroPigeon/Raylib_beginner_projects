using Raylib_cs;

public class Ball
{

    const int maxHeight = 600;

    float velocityY;
    float gravity;
    double ballX;
    double ballY;
    int radius;

    public void initBall(float _velocityY, float _gravity, double _ballX, double _ballY, int _radius)
    {
        velocityY = _velocityY;
        gravity = _gravity;
        ballX = _ballX;
        ballY = _ballY;
        radius = _radius;

    }

    public void update(float deltaTime)
    {
        
        velocityY += gravity * deltaTime;
        ballY += velocityY * deltaTime;

        if ((ballY + radius) >maxHeight)
        {
            
            Random random = new Random();

            ballY = maxHeight - radius;
            velocityY *= -(float)(0.6f + random.NextDouble() * (0.8f - 0.6f));
            
        }

    }

    public void DrawBall()
    {
        
        Raylib.DrawCircle((int)ballX, (int)ballY, radius, Color.Red);

    }
}