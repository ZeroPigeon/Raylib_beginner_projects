using Raylib_cs;

const int maxWidth = 800;
const int maxHeight = 600;

Raylib.InitWindow(maxWidth, maxHeight, "Bouncing ball");
Raylib.SetTargetFPS(60);

float deltaTime;
float velocityY = 250f;

float gravity = 500f;

double ballX = 400;
double ballY = 300;
int radius = 25;

    Ball ball1 = new Ball();
    ball1.initBall(velocityY, gravity, ballX, ballY, radius);

    Ball ball2 = new Ball();
    ball2.initBall(velocityY - 50, gravity, ballX - 100, ballY - 50, radius - 10);

    Ball ball3 = new Ball();
    ball3.initBall(velocityY + 150, gravity, ballX + 100, ballY + 20, radius + 5);

while(!Raylib.WindowShouldClose())
{

    deltaTime = Raylib.GetFrameTime();

    ball1.update(deltaTime);
    ball2.update(deltaTime);
    ball3.update(deltaTime);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SkyBlue);

    ball1.DrawBall();
    ball2.DrawBall();
    ball3.DrawBall();

    Raylib.EndDrawing();

}

Raylib.CloseWindow();