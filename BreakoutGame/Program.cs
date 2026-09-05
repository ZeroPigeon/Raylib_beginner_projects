using System.Numerics;
using Raylib_cs;

const int screenWidth = 620;
const int screenHeight = 800;

Raylib.InitWindow(screenWidth, screenHeight, "Breakout Game");
Raylib.SetTargetFPS(60);

const int rowAmount = 10;
const int rows = 4;

Vector2 ballSpeed = new Vector2();
Vector2 ballPos = new Vector2();
Vector2 ballPrevPos = new Vector2();

float ballRadius = 5;

ballPos.X = 310;
ballPos.Y = 735;

ballSpeed.Y = -250;

Random random = new Random();
ballSpeed.X = random.NextSingle() * 100;

if (random.NextSingle() >= 0.5)
{
    
    ballSpeed.X *= -1;

}

ballSpeed.X = 120;

Rectangle[] bricks = new Rectangle[44];
Color[] brickColors = new Color[44];
int brickCount = 0;

int score = 0;

int brickWidth = 45;
int brickHeight = 15;

Color[] colors = new Color[]
{
    Color.Red,
    Color.Yellow,
    Color.Orange,
    Color.Blue
};

Vector2 paddlePos = new Vector2();

paddlePos.X = 290;
paddlePos.Y = 750;
float paddleSpeed = 150;
int paddleWidth = 40;
int paddleHeight = 10;

float deltaTime;

int yPos = 150;

for (int j = 0; j < rows; j++)
{
    int xPos = 10;

    for (int i = 0; i <= rowAmount; i++)
    {
        
        bricks[brickCount] = new Rectangle(xPos, yPos, brickWidth, brickHeight);
        brickColors[brickCount] = colors[j];

        brickCount++;

        xPos += 55;

    }
    yPos += 30;

}

brickCount = 0;

while (!Raylib.WindowShouldClose())
{
    
    deltaTime = Raylib.GetFrameTime();

    ballPrevPos = ballPos;

    ballPos.X += ballSpeed.X * deltaTime;
    ballPos.Y += ballSpeed.Y * deltaTime;

    if (ballPos.X + ballRadius >= screenWidth)
    {
        
        ballPos.X = screenWidth - ballRadius;
        ballSpeed.X *= -1;

    }

    if (ballPos.X - ballRadius <= 0)
    {
        
        ballPos.X = 0 + ballRadius;
        ballSpeed.X *= -1;

    }

    if (ballPos.Y - ballRadius <= 0)
    {
        
        ballPos.Y = 0 + ballRadius;
        ballSpeed.Y *= -1;

    }

    if (ballPos.Y + ballRadius >= screenHeight)
    {
        
        Raylib.CloseWindow();

    }

    if (Raylib.IsKeyDown(KeyboardKey.D))
    {
        
        paddlePos.X += paddleSpeed * deltaTime;

    }

    if (Raylib.IsKeyDown(KeyboardKey.A))
    {
        
        paddlePos.X -= paddleSpeed * deltaTime;

    }

    if (paddlePos.X <= 0)
    {
        
        paddlePos.X = 0;

    }

    if (paddlePos.X >= screenWidth - paddleWidth)
    {
        
        paddlePos.X = screenWidth - paddleWidth;

    }

    Rectangle paddle = new Rectangle(paddlePos.X, paddlePos.Y, paddleWidth, paddleHeight);

    if (Raylib.CheckCollisionCircleRec(new Vector2(ballPos.X, ballPos.Y), ballRadius, paddle))
    {
        
        float XPos = ballPos.X - ballPrevPos.X;
        float YPos = ballPos.Y - ballPrevPos.Y;

        if (MathF.Abs(XPos) > MathF.Abs(YPos))
        {

            if (XPos > 0)
            {
                
                ballPos.X = paddlePos.X - ballRadius;

            }else
            {
                
                ballPos.X = paddlePos.X + paddleWidth + ballRadius;

            }

            ballSpeed.X *= -1;

        }
        else
        {
            
            if (YPos > 0)
            {
                
                ballPos.Y = paddlePos.Y - ballRadius;

            }
            else
            {
                
                ballPos.Y = paddlePos.Y + paddleHeight + ballRadius;

            }

            ballSpeed.Y *= -1;

        }

    }

    for (int i = brickCount; i < bricks.Count(); i++)
    {
        
        if (bricks[i].X == 0 && bricks[i].Y == 0)
            continue;

        if (Raylib.CheckCollisionCircleRec(new Vector2(ballPos.X, ballPos.Y), ballRadius, bricks[i]))
        {
            
            float XPos = ballPos.X - ballPrevPos.X;
            float YPos = ballPos.Y - ballPrevPos.Y;

            if (MathF.Abs(XPos) > MathF.Abs(YPos))
            {

                if (XPos > 0)
                {
                    
                    ballPos.X = bricks[i].X - ballRadius;

                }else
                {
                
                    ballPos.X = bricks[i].X + brickWidth + ballRadius;

                }
                
                ballSpeed.X *= -1;

            }
            else
            {

                if (YPos > 0)
                {
                
                    ballPos.Y = bricks[i].Y - ballRadius;

                }
                else
                {
                
                    ballPos.Y = bricks[i].Y + brickHeight + ballRadius;

                }

                ballSpeed.Y *= -1;

            }

            bricks[i].X = 0;
            bricks[i].Y = 0;
            score++;
            break;

        }

    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    if (score == 44)
    {
        
        Raylib.DrawText("You Win!!", 305, 50, 50, Color.White);       

    } else 
    {

        Raylib.DrawText(score.ToString(), 305, 50, 50, Color.White);

    }

    for (int i = brickCount; i < bricks.Count(); i++)
    {
        
        if (bricks[i].X == 0 && bricks[i].Y == 0)
            continue;

        Raylib.DrawRectangle((int)bricks[i].X, (int)bricks[i].Y, (int)bricks[i].Width, (int)bricks[i].Height, brickColors[i]);

    }

    Raylib.DrawCircle((int)ballPos.X, (int)ballPos.Y, (int)ballRadius, Color.White);
    Raylib.DrawRectangle((int)paddle.X, (int)paddle.Y, (int)paddle.Width, (int)paddle.Height, Color.White);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();