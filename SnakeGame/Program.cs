using System.Runtime.CompilerServices;
using Raylib_cs;

const int screenWidth = 800;
const int screenHeight = 600;

Raylib.InitWindow(screenWidth, screenHeight + 200, "Snake Game");
Raylib.SetTargetFPS(60);

int cellSize = 20;

List<Snake> snake = new List<Snake>();

    snake.Add(new Snake(20, 15, Color.DarkGreen));
    snake.Add(new Snake(20, 16, Color.Green));
    snake.Add(new Snake(20, 17, Color.Lime));

float deltaTime;
float moveTimer = 0.5f;

int direction = 1;
int oldDir = direction;
int tail = 3;

bool food = false;
Food foodPiece = new Food();

int score = 0;

while(!Raylib.WindowShouldClose())
{

    if (Raylib.IsKeyPressed(KeyboardKey.W))
    {
        
        direction = 1;

    }

    if (Raylib.IsKeyPressed(KeyboardKey.D))
    {
        
        direction = 2;

    }

    if (Raylib.IsKeyPressed(KeyboardKey.S))
    {
        
        direction = 3;

    }

    if (Raylib.IsKeyPressed(KeyboardKey.A))
    {
        
        direction = 4;

    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    if (!food)
    {
        
        foodPiece.create();
        food = true;

    }

    deltaTime = Raylib.GetFrameTime();

    for (int i = 0; i < screenWidth / cellSize; i++)
    {
        for (int j = 0; j < screenHeight / cellSize; j++)
        {
            
            Raylib.DrawRectangleLines(i * cellSize, j * cellSize + 200, cellSize, cellSize, Color.LightGray);

        }

    }

    if (moveTimer <= 0)
    {

        for (int i = snake.Count() - 1; i >= 1; i--)
        {
            
            snake[i].X = snake[i - 1].X;
            snake[i].Y = snake[i - 1].Y;

        }
        
        if (tail == direction)
        {
            
            direction = oldDir;

        }

        if (direction == 1)
        {

            snake[0].Y -= 1;
            tail = 3;

        } else if (direction == 2)
        {
            
            snake[0].X += 1;
            tail = 4;

        } else if (direction == 3)
        {
            
            snake[0].Y += 1;
            tail = 1;

        } else
        {
            
            snake[0].X -= 1;
            tail = 2;

        }

        for (int i = 1; i <= snake.Count - 1; i++)
        {
            
            if ((snake[0].X == snake[i].X) && (snake[0].Y == snake[i].Y))
            {
                
                Raylib.CloseWindow();

            }

        }

        if ((snake[0].X == -1) || (snake[0].X == screenWidth / cellSize) || (snake[0].Y == 9) || (snake[0].Y == (screenHeight + 200) / cellSize))
        {
            
            Raylib.CloseWindow();

        }

        oldDir = direction;

        if ((snake[0].X == foodPiece.X) && (snake[0].Y == foodPiece.Y))
        {
            
            food = false;

            snake[snake.Count - 1].color = Color.Green;
            snake.Add(new Snake(snake[snake.Count - 1].X, snake[snake.Count - 1].Y, Color.Lime));
            score++;

        }

        moveTimer = 0.3f;

    }

    foreach (Snake snakePart in snake)
    {
        
        Raylib.DrawRectangle(snakePart.X * cellSize, snakePart.Y * cellSize, cellSize, cellSize, snakePart.color);

    }

    if (food) 
    {

        Raylib.DrawRectangle(foodPiece.X * cellSize, foodPiece.Y * cellSize, cellSize, cellSize, Color.Red);

    }

    Raylib.DrawText(score.ToString(), 400, 100, 30, Color.White);

    moveTimer -= deltaTime;

    Raylib.EndDrawing();

}

Raylib.CloseWindow();